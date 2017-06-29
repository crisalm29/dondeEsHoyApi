// dataAccess.js



var mysql = require('mysql');
var logger = require('./logger.js');


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
		var result = null;
		sqlConnection().getConnection(function(err,conn){
	        if (err) {
	        	logger.error('Error in connection database', err)
	          	result = {"success" : false, "status" : "Error in connection database"};
	          	return;
	        	
	        }
	        
	    	var sql = "INSERT INTO users (name, password, email, lastName, imagebase64) VALUES ?";

	    	conn.query(sql, [[userData.name, userData.password, userData.email, userData.lastName, userData.image]], function (err, result){
	    		if (err) {
	    			logger.error('Error inserting user in database', err)
		          	result = {"success" : false, "status" : "Error adding user to db"};
		          	return;
		          
		        }else{
	        		logger.info('User added correctly', result);
		        	result = {success: true, msg: "User resgistered correctly." , obj: result};
		        	return;
		        }

		        console.log("User registered: " + userData.email);   
	    	});

	  	});
	  	return result;

	},

	login: function(loginData){
		return sqlConnection().getConnection(function(err, conn){
			if (err) {
	          return {"success" : false, "status" : "Error in connection database"};
	        }  

	        var sql = 'SELECT TOP 1 FROM users where email = ? AND password = ?';

	        return onn.query(sql, [mysql.escape(loginData.email), mysql.escape(loginData.password)], function(err, result){
	        	if (err) {
	    			logger.error('Error getting user in database', err)
		          	return {"success" : false, "status" : "Error adding user to db"};
		          
		        }else{
		        	logger.info('Get user successfully');
		        	return {"success": true, "result": result};
		        }
	        });

		});
	}
};




module.exports = dataAccess;



