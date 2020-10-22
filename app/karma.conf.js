// Karma configuration file, see link for more information
// https://karma-runner.github.io/1.0/config/configuration-file.html

var baseConfig = require('./karma.conf')
module.exports = function (config) {
  baseConfig(config);
  config.browsers = ['ChromeHeadlessNoSandbox'];
  config.singleRun = true;
};