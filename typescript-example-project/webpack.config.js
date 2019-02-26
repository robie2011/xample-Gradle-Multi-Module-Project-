const path = require('path');

module.exports = {
  entry: './build/main.js',
  output: {
    filename: '../dist/bundle.js',
    path: path.resolve(__dirname, 'build')
  }
};