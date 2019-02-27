const path = require('path');

module.exports = {
  entry: './src/main.ts',
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      }
    ]
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js']
  },
  output: {
    filename: '../dist/bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
  
  devServer: {
    publicPath: "/",
    contentBase: "./dist",
    hot: true,
    watchContentBase: true
  }
};