const path = require('path');
const glob = require('glob');

module.exports = {
    entry:  {
        js: glob.sync("./src/**/*.js"),
    },
    output: {
        filename: 'main.js',
        path: path.resolve(__dirname, 'dist'),
    },
    devServer: {
        writeToDisk: true
    },
    devtool: 'source-map'
};
