import * as h from "./foTsHost"

try {
    if (process.argv.length < 4) {
        console.log('Arguments should be provided [0]:Http listener port; [1]: Root folder path.');
    } else {

        let host = new h.Host(process.argv[3]);
        host.start(parseInt(process.argv[2]));
    }
} catch (e) {
    console.log(e.toString());
}