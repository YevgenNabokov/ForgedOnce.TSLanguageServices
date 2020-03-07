"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
const man = require("./generationManager");
const path = require("path");
try {
    if (process.argv.length < 5) {
        console.log('Arguments should be provided [0]:Path to the task json file; [1]:Output folder path; [2]:Output json status path.');
    }
    else {
        if (fs.existsSync(process.argv[2])) {
            var readResult = fs.readFileSync(process.argv[2]);
            var payload = readResult.toString('utf8');
            var generationTask = JSON.parse(payload);
            var manager = new man.GenerationManager();
            var result = manager.executeTask(generationTask);
            var outputBasePath = process.argv[3];
            for (var i = 0; i < result.files.length; i++) {
                var filePath = path.join(outputBasePath, result.files[i].fileName);
                if (!path.isAbsolute(filePath)) {
                    filePath = path.join(path.dirname(require.main.filename), filePath);
                }
                var fileDir = path.dirname(filePath);
                if (!fs.existsSync(fileDir)) {
                    createDirectoryRecursively(fileDir);
                }
                fs.writeFileSync(filePath, result.files[i].payload);
            }
            fs.writeFileSync(process.argv[4], JSON.stringify(result.metadata));
        }
        else {
            console.log('Task file does not exist ' + process.argv[2]);
        }
    }
}
catch (e) {
    console.log(e.toString());
}
function createDirectoryRecursively(dirPath) {
    var normalized = path.normalize(dirPath);
    var parts = normalized.split(path.sep);
    var currentPath = parts[0];
    for (var i = 1; i < parts.length; i++) {
        currentPath = path.join(currentPath, parts[i]);
        if (!fs.existsSync(currentPath)) {
            fs.mkdirSync(currentPath);
        }
    }
}
//# sourceMappingURL=generationLauncher.js.map