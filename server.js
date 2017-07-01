// server.js


// Call the packages we need

var express = require('express');
var usersController = require('./app/models/usersController.js');

var app = express();


var bodyParser =  require('body-parser');

// Configure app to user body parser 
// This will let get data from a POST

app.use(bodyParser.urlencoded({extended: true}));


app.use(bodyParser.json());



var port = process.env.PORT || 8080;



function handle_database(req,res) {
    
    pool.getConnection(function(err,connection){
        if (err) {
          res.json({"code" : 100, "status" : "Error in connection database"});
          return;
        }   

        console.log('connected as id ' + connection.threadId);
        
        /*connection.query("select * from user",function(err,rows){
            connection.release();
            if(!err) {
                res.json(rows);
            }           
        });*/

        connection.on('error', function(err) {      
              res.json({"code" : 100, "status" : "Error in connection database"});
              return;     
        });
  });
}




// Routing 


var router = express.Router();


router.get('/', function(req, res){
	res.json({message: 'Welcome to our dondeEsHoy API!'});
    handle_database(req,res);
});


router.route('/users').post(function(req, res){
  var userData = req.body;
  usersController.registerUser(userData, function(result, err){
    if(err){
      res.json({data: err})
      return err;
    }else{
      res.json({data: result});
      return result;
    }
  });

});

router.route('/login').post(function(req,res){
  var loginData = req.body;
  usersController.login(loginData, function(result, err){
    if(err){
      res.json(err);
    }else{
      res.json(result);
    }
  });
});

app.use('/api', router);


// START SERVER

app.listen(port);

console.log('Things are going to happens on port ' + port);