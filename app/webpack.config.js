var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
module.exports = {
    context: __dirname,
    resolve: {
        extensions: ['', '.js', '.ts']
    },
    entry: 
    {
        app: "./src/app.ts",
        vendor: "./src/vendor.ts"
    },
    module:{
        loaders: [
            {
                test: /\.ts$/,
                loader: 'ts'
            },
            {
                test: /\.html$/,
                loader: "html-loader"
            }]
    },
    output: 
    {
        path: __dirname + "/js",
        filename: "[name].js"
    },
    plugins: [
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app', 'vendor']
        })
    ]
};