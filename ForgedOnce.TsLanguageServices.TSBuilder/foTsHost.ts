import * as http from "http"

import * as fs from "fs"

import * as tu from "./astTransportUtils";

import * as ts from "typescript";

import * as path from "path"

import * as tc from "./FullAstGenerated/TransportToAstConverter";

export class Host {
    private currentServer: http.Server | null = null;

    private syntheticNewLinePrefix = 'THIS IS UGLY HACK TO ADD NEW LINE WHERE NEEDED';

    constructor() {
    }

    public start(port: number) {
        if (this.currentServer) {
            throw new Error('Host already started.');
        }

        let self = this;
        this.currentServer = http.createServer((req, res) => self.onHttpReceive(req, res));
        this.currentServer.listen(port);
    }

    public stop() {
        if (this.currentServer) {
            this.currentServer.close();
            this.currentServer = null;
        }
    }

    private onHttpReceive(request: http.IncomingMessage, response: http.ServerResponse) {
        let requestPayload = '';
        let body = [];
        let self = this;
        request
            .on('data', (chunk) => {
                body.push(chunk);
            })
            .on('end', () => {
                requestPayload = Buffer.concat(body).toString();

                let command: Command | null = null;
                try {
                    command = self.readCommand(requestPayload);

                    if (command.CommandType == CommandType.Shutdown) {
                        response.writeHead(200);
                        response.end();

                        self.stop();
                        return;
                    }

                    let responseObject = self.processCommand(command);
                    let responsePayload = JSON.stringify(responseObject);

                    response.writeHead(200);
                    response.write(responsePayload);
                    response.end();
                }
                catch (e) {
                    self.writeError(response, `Error occurred while executing command: ${e}`);
                }
            })
            .on('error', (err) => {
                self.writeError(response, `Error occurred on receive: ${err}`);
            });
    }

    private writeError(response: http.ServerResponse, errorMessage: string) {
        response.writeHead(400);
        response.write(errorMessage);
        response.end();
    }

    private readCommand(requestPayload: string): Command {
        var rawCommand = JSON.parse(requestPayload) as Command;

        if (rawCommand.CommandType === CommandType.Shutdown) {
            return rawCommand;
        }

        if (rawCommand.CommandType === CommandType.Ping) {
            return rawCommand;
        }

        if (rawCommand.CommandType === CommandType.ReadFile) {
            return rawCommand;
        }

        if (rawCommand.CommandType === CommandType.WriteFile) {
            return rawCommand;
        }

        if (rawCommand.CommandType === CommandType.Parse) {
            return rawCommand;
        }

        if (rawCommand.CommandType === CommandType.Print) {
            return rawCommand;
        }

        throw new Error(`Unrecognized command type=${rawCommand.CommandType}`);
    }

    private processCommand(command: Command): any {
        if (command.CommandType === CommandType.Ping) {
            return {};
        }

        if (command.CommandType === CommandType.Shutdown) {
            //// Finalization code here.
            return {};
        }

        if (command.CommandType === CommandType.ReadFile) {
            let readFileCommand = command as ReadFileCommand;

            if (fs.existsSync(readFileCommand.FilePath)) {
                let fileName = path.basename(readFileCommand.FilePath);

                let readResult = fs.readFileSync(readFileCommand.FilePath);
                let payload = readResult.toString('utf8');
                let sourceFile = ts.createSourceFile(fileName, payload, ts.ScriptTarget.Latest, false);
                let converter = new tu.TransportConverter();
                let resultPayload = converter.StatementsToString(sourceFile.statements);

                let result = new ReadFileCommandResult();
                result.FileName = fileName;
                result.AstPayload = resultPayload;
                return result;
            } else {
                throw new Error('File not found.');
            }
        }

        if (command.CommandType === CommandType.WriteFile) {
            let writeFileCommand = command as WriteFileCommand;

            var data = JSON.parse(writeFileCommand.AstPayload) as any[];
            var converter = new tc.Converter();
            var statements = converter.ConvertNodes(data) as ts.Statement[];

            var tsSourceFile = ts.createSourceFile(writeFileCommand.FileName, '', ts.ScriptTarget.Latest);
            tsSourceFile.statements = ts.createNodeArray(statements);
            var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
            var outputPayload = printer.printFile(tsSourceFile);

            fs.writeFileSync(writeFileCommand.Path, outputPayload);
            return {};
        }

        if (command.CommandType === CommandType.Parse) {
            let parseCommand = command as ParseCommand;

            let sourceFile = ts.createSourceFile('DummyFileName.ts', parseCommand.Payload, ts.ScriptTarget.Latest, false, parseCommand.ScriptKind);
            let converter = new tu.TransportConverter();
            let resultPayload = converter.StatementsToString(sourceFile.statements);

            let result = new ParseCommandResult();
            result.AstPayload = resultPayload;
            return result;
        }

        if (command.CommandType === CommandType.Print) {
            let printCommand = command as PrintCommand;

            var data = JSON.parse(printCommand.AstPayload) as any[];
            var converter = new tc.Converter();
            var statements = converter.ConvertNodes(data) as ts.Statement[];

            var tsSourceFile = ts.createSourceFile('DummyFileName.ts', '', ts.ScriptTarget.Latest, undefined, printCommand.ScriptKind);
            tsSourceFile.statements = ts.createNodeArray(statements);

            tsSourceFile = this.formatSyntaxTree(tsSourceFile);

            var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
            var outputPayload = printer.printFile(tsSourceFile);

            let formattingChanges = this.getTsFileFormattingChanges(tsSourceFile, outputPayload);
            outputPayload = this.formatCode(outputPayload, formattingChanges);

            var key = new RegExp(`\\s\\/\\/${this.syntheticNewLinePrefix}`, 'g');
            outputPayload = outputPayload.replace(key, '');

            let result = new PrintCommandResult();
            result.Payload = outputPayload;
            return result;
        }
    }

    private formatSyntaxTree(sourceFile: ts.SourceFile) {
        const transformer = (ctx: ts.TransformationContext) => {
            return (src: ts.SourceFile) => {
                const visit = <T extends ts.Node>(node: T): T => {
                    if (ts.isSourceFile(node)) return ts.visitEachChild(node, visit, ctx);
                    let resultNode = node;
                    if (ts.isExpressionStatement(node)) {
                        resultNode = ts.getMutableClone(node);
                        resultNode = ts.addSyntheticTrailingComment(resultNode, ts.SyntaxKind.SingleLineCommentTrivia, this.syntheticNewLinePrefix, true);
                    }

                    return ts.visitEachChild(resultNode, visit, ctx);
                };
                return visit(src);
            };
        };

        const { transformed } = ts.transform(sourceFile, [transformer], ts.getDefaultCompilerOptions());

        return transformed[0];
    }

    private formatCode(orig: string, changes: ts.TextChange[]): string {
        var result = orig;
        for (var i = changes.length - 1; i >= 0; i--) {
            var change = changes[i];
            var head = result.slice(0, change.span.start);
            var tail = result.slice(change.span.start + change.span.length)
            result = head + change.newText + tail;
        }
        return result;
    }

    private getTsFileFormattingChanges(file: ts.SourceFile, fileText: string) {
        let formatOptions: ts.FormatCodeOptions = {
            BaseIndentSize: 0,
            IndentSize: 4,
            TabSize: 4,
            NewLineCharacter: ts.sys.newLine,
            ConvertTabsToSpaces: true,
            IndentStyle: ts.IndentStyle.Smart,
            InsertSpaceAfterCommaDelimiter: true,
            InsertSpaceAfterSemicolonInForStatements: true,
            InsertSpaceBeforeAndAfterBinaryOperators: true,
            InsertSpaceAfterConstructor: true,
            InsertSpaceAfterKeywordsInControlFlowStatements: false,
            InsertSpaceAfterFunctionKeywordForAnonymousFunctions: true,
            InsertSpaceAfterOpeningAndBeforeClosingNonemptyParenthesis: false,
            InsertSpaceAfterOpeningAndBeforeClosingNonemptyBrackets: false,
            InsertSpaceAfterOpeningAndBeforeClosingNonemptyBraces: true,
            InsertSpaceAfterOpeningAndBeforeClosingTemplateStringBraces: true,
            InsertSpaceAfterOpeningAndBeforeClosingJsxExpressionBraces: true,
            InsertSpaceAfterTypeAssertion: true,
            InsertSpaceBeforeFunctionParenthesis: false,
            PlaceOpenBraceOnNewLineForFunctions: false,
            PlaceOpenBraceOnNewLineForControlBlocks: true,
            insertSpaceBeforeTypeAnnotation: false

        };

        let langSvc = this.inMemoryLanguageService(file, fileText);
        return langSvc.getFormattingEditsForDocument(file.fileName, formatOptions);
    }

    private inMemoryLanguageService(file: ts.SourceFile, fileText: string): ts.LanguageService {
        var host: ts.LanguageServiceHost = {
            getScriptFileNames: () => [file.fileName],
            getScriptVersion: filename => '0',
            getScriptSnapshot: filename => ts.ScriptSnapshot.fromString(fileText),
            log: message => undefined,
            trace: message => undefined,
            error: message => undefined,
            getCurrentDirectory: () => '',
            getDefaultLibFileName: () => "lib.d.ts",
            getCompilationSettings: () => { return {}; },
        };
        
        return ts.createLanguageService(host, ts.createDocumentRegistry())
    }
}

export enum CommandType {
    Shutdown,
    Ping,
    ReadFile,
    WriteFile,
    Parse,
    Print
}

export abstract class Command {
    CommandType: CommandType;
}

export class ShutdownCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Shutdown;
    }
}

export class PingCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Ping;
    }
}

export class ReadFileCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.ReadFile;
    }

    public FilePath: string;
}

export class ReadFileCommandResult {
    public AstPayload: string;

    public FileName: string;
}

export class WriteFileCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.WriteFile;
    }

    public AstPayload: string;

    public FileName: string;

    public Path: string;
}

export class ParseCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Parse;
    }

    public Payload: string;

    public ScriptKind: ts.ScriptKind;
}

export class ParseCommandResult {
    public AstPayload: string;
}

export class PrintCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Print;
    }

    public AstPayload: string;

    public ScriptKind: ts.ScriptKind;
}

export class PrintCommandResult {
    public Payload: string;
}