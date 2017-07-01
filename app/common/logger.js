// logger.js

var winston = require('winston');


var logger = new (winston.Logger)({
  transports: [
    new (winston.transports.File)({
      name: 'INFO',
      filename: 'D:\\log\\dondeEsHoy\\dondeEsHoy-info.log',
      level: 'info'
    }),
    new (winston.transports.File)({
      name: 'ERROR',
      filename: 'D:\\log\\dondeEsHoy\\dondeEsHoy-error.log',
      level: 'error'
    })
  ]
});


module.exports = logger;

