var path = require('path');

var webpack = require('webpack');

module.exports = function (env) {
    env = env || {};
    var isProd = env.NODE_ENV === 'production';
    var config = {
    entry: {
        main: './wwwroot/Appjs/EntryPoint.js'

    },
    output: {
        path: path.join(__dirname, 'wwwroot/Appjs/dist'),
        filename: 'SaleInvoice.js'
    },
    devtool: 'eval-source-map',
    resolve: {
        
        extensions: [".jsx", ".js", ".json"]
    },

    devServer: {
        contentBase: './wwwroot',
        compress: true,
        watchContentBase: true,
        publicPath: '/dist',
        inline: true,
        port: 9000
   },

    plugins: [
      new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' })
    ],
 
    module: {
        rules: [
            { test: /\.js$/, exclude: /node_modules/, use: ['babel-loader'] },
            { test: /\.jsx$/, exclude: /node_modules/, use: ['babel-loader']},
            { test: /\.css?$/, exclude: /node_modules/,use: ['style-loader', 'css-loader']},
        { test: /\.(png|jpg|jpeg|gif|svg)$/,exclude: /node_modules/, use: 'url-loader?limit=25000' },
        { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, exclude: /node_modules/,use: 'url-loader?limit=100000' }
        ]
    }
}

// Alter config for prod environment
if (isProd) {
    config.devtool = 'source-map';
    config.plugins = config.plugins.concat([
      new webpack.optimize.UglifyJsPlugin({
        sourceMap: true
        })
    ]);
}

return config;
};
