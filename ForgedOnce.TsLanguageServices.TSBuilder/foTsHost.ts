import * as http from "http"

import * as fs from "fs"

export class Host {
    private currentServer: http.Server | null = null;

    private rootFolder: string;

    constructor(rootFolder: string) {
        this.rootFolder = rootFolder;
    }

    public start(port: number) {
        if (this.currentServer) {
            throw new Error('Host already started.');
        }

        this.currentServer = http.createServer(this.onHttpReceive);
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
        request
            .on('data', (chunk) => {
                body.push(chunk);
            })
            .on('end', () => {
                requestPayload = Buffer.concat(body).toString();

                let command: Command | null = null;
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
                    this.writeError(response, `Error occurred while reading command from request: ${e}`);
                }
            })
            .on('error', (err) => {
                this.writeError(response, `Error occurred on receive: ${err}`);
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
    }
}

export enum CommandType {
    Shutdown,
    Ping
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