"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const http = require("http");
const fs = require("fs");
const tu = require("./astTransportUtils");
const ts = require("typescript");
const path = require("path");
class Host {
    constructor(rootFolder) {
        this.currentServer = null;
        this.rootFolder = rootFolder;
    }
    start(port) {
        if (this.currentServer) {
            throw new Error('Host already started.');
        }
        this.currentServer = http.createServer(this.onHttpReceive);
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
        request
            .on('data', (chunk) => {
            body.push(chunk);
        })
            .on('end', () => {
            requestPayload = Buffer.concat(body).toString();
            let command = null;
            try {
                command = this.readCommand(requestPayload);
                if (command.CommandType == CommandType.Shutdown) {
                    response.writeHead(200);
                    response.end();
                    this.stop();
                }
                let responseObject = this.processCommand(command);
                let responsePayload = JSON.stringify(responseObject);
                response.writeHead(200);
                response.write(responsePayload);
                response.end();
            }
            catch (e) {
                this.writeError(response, `Error occurred while executing command: ${e}`);
            }
        })
            .on('error', (err) => {
            this.writeError(response, `Error occurred on receive: ${err}`);
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
    }
}
exports.Host = Host;
var CommandType;
(function (CommandType) {
    CommandType[CommandType["Shutdown"] = 0] = "Shutdown";
    CommandType[CommandType["Ping"] = 1] = "Ping";
    CommandType[CommandType["ReadFile"] = 2] = "ReadFile";
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
//# sourceMappingURL=foTsHost.js.map