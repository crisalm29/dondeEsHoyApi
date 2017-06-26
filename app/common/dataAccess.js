// dataAccess.js



var mysql = require('mysql');


function sqlConnection(){
	return mysql.createPool({
	    connectionLimit : 100, //important
	    host     : 'sql10.freemysqlhosting.net',
	    user     : 'sql10181811',
	    password : '2qAGpxXHfi',
	    database : 'sql10181811',
	    debug    :  false
	});

}



var dataAccess = {
	insertUser:  function(userData){
		console.log('dataAccess');
		sqlConnection().getConnection(function(err,conn){
	        if (err) {
	          res.json({"success" : false, "status" : "Error in connection database"});
	          return;
	        }   

	        console.log('connected as id ' + conn.threadId);
	        
	    	var sql = "INSERT INTO users (name, password, email, lastName, imagebase64) VALUES ?";


	    	conn.query(sql, [[userData.name, userData.password, userData.email, userData.lastName, userData.image]], function (err, result){
	    		if (err) {
		          res.json({"success" : false, "status" : "Error in connection database"});
		          return;
		        }

		        console.log("User registered: " + userData.email);   
	    	});

	  	});

	}
};




module.exports = dataAccess;



