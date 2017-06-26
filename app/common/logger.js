// logger.js

var winston = require('winston');


var logger = new (winston.Logger)({
  transports: [
    new (winston.transports.File)({
      name: 'INFO',
      filename: '/var/log/dondeEsHoy/dondeEsHoy-info.log',
      level: 'info'
    }),
    new (winston.transports.File)({
      name: 'ERROR',
      filename: '/var/log/dondeEsHoy/dondeEsHoy-error.log',
      level: 'error'
    })
  ]
});


module.exports = logger;

