"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PrintCommandResult = exports.PrintCommand = exports.ParseCommandResult = exports.ParseCommand = exports.WriteFileCommand = exports.ReadFileCommandResult = exports.ReadFileCommand = exports.PingCommand = exports.ShutdownCommand = exports.Command = exports.CommandType = exports.Host = void 0;
const http = require("http");
const fs = require("fs");
const tu = require("./astTransportUtils");
const ts = require("typescript");
const path = require("path");
const tc = require("./FullAstGenerated/TransportToAstConverter");
class Host {
    constructor() {
        this.currentServer = null;
    }
    start(port) {
        if (this.currentServer) {
            throw new Error('Host already started.');
        }
        let self = this;
        this.currentServer = http.createServer((req, res) => self.onHttpReceive(req, res));
        this.currentServer.listen(port);
    }
    stop() {
        if (this.currentServer) {
            this.currentServer.close();
            this.currentServer = null;
        }
    }
    onHttpReceive(request, response) {
        let requestPayload = '';
        let body = [];
        let self = this;
        request
            .on('data', (chunk) => {
            body.push(chunk);
        })
            .on('end', () => {
            requestPayload = Buffer.concat(body).toString();
            let command = null;
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
    writeError(response, errorMessage) {
        response.writeHead(400);
        response.write(errorMessage);
        response.end();
    }
    readCommand(requestPayload) {
        var rawCommand = JSON.parse(requestPayload);
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
    processCommand(command) {
        if (command.CommandType === CommandType.Ping) {
            return {};
        }
        if (command.CommandType === CommandType.Shutdown) {
            //// Finalization code here.
            return {};
        }
        if (command.CommandType === CommandType.ReadFile) {
            let readFileCommand = command;
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
            }
            else {
                throw new Error('File not found.');
            }
        }
        if (command.CommandType === CommandType.WriteFile) {
            let writeFileCommand = command;
            var data = JSON.parse(writeFileCommand.AstPayload);
            var converter = new tc.Converter();
            var statements = converter.ConvertNodes(data);
            var tsSourceFile = ts.createSourceFile(writeFileCommand.FileName, '', ts.ScriptTarget.Latest);
            tsSourceFile.statements = ts.createNodeArray(statements);
            var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
            var outputPayload = printer.printFile(tsSourceFile);
            fs.writeFileSync(writeFileCommand.Path, outputPayload);
            return {};
        }
        if (command.CommandType === CommandType.Parse) {
            let parseCommand = command;
            let sourceFile = ts.createSourceFile('DummyFileName.ts', parseCommand.Payload, ts.ScriptTarget.Latest, false, parseCommand.ScriptKind);
            let converter = new tu.TransportConverter();
            let resultPayload = converter.StatementsToString(sourceFile.statements);
            let result = new ParseCommandResult();
            result.AstPayload = resultPayload;
            return result;
        }
        if (command.CommandType === CommandType.Print) {
            let printCommand = command;
            var data = JSON.parse(printCommand.AstPayload);
            var converter = new tc.Converter();
            var statements = converter.ConvertNodes(data);
            var tsSourceFile = ts.createSourceFile('DummyFileName.ts', '', ts.ScriptTarget.Latest, undefined, printCommand.ScriptKind);
            tsSourceFile.statements = ts.createNodeArray(statements);
            var printer = ts.createPrinter({ newLine: ts.NewLineKind.CarriageReturnLineFeed });
            var outputPayload = printer.printFile(tsSourceFile);
            let result = new PrintCommandResult();
            result.Payload = outputPayload;
            return result;
        }
    }
}
exports.Host = Host;
var CommandType;
(function (CommandType) {
    CommandType[CommandType["Shutdown"] = 0] = "Shutdown";
    CommandType[CommandType["Ping"] = 1] = "Ping";
    CommandType[CommandType["ReadFile"] = 2] = "ReadFile";
    CommandType[CommandType["WriteFile"] = 3] = "WriteFile";
    CommandType[CommandType["Parse"] = 4] = "Parse";
    CommandType[CommandType["Print"] = 5] = "Print";
})(CommandType = exports.CommandType || (exports.CommandType = {}));
class Command {
}
exports.Command = Command;
class ShutdownCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Shutdown;
    }
}
exports.ShutdownCommand = ShutdownCommand;
class PingCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Ping;
    }
}
exports.PingCommand = PingCommand;
class ReadFileCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.ReadFile;
    }
}
exports.ReadFileCommand = ReadFileCommand;
class ReadFileCommandResult {
}
exports.ReadFileCommandResult = ReadFileCommandResult;
class WriteFileCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.WriteFile;
    }
}
exports.WriteFileCommand = WriteFileCommand;
class ParseCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Parse;
    }
}
exports.ParseCommand = ParseCommand;
class ParseCommandResult {
}
exports.ParseCommandResult = ParseCommandResult;
class PrintCommand extends Command {
    constructor() {
        super();
        this.CommandType = CommandType.Print;
    }
}
exports.PrintCommand = PrintCommand;
class PrintCommandResult {
}
exports.PrintCommandResult = PrintCommandResult;
//# sourceMappingURL=foTsHost.js.map