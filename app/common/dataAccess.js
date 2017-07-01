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
	insertUser:  function(userData, callback){
		return sqlConnection().getConnection(function(err,conn){
	        if (err) {
	        	logger.error('Error in connection database', err);
	        	callback(null, {success:false, error: err.code});
	        	
	        }else{
	        
		    	var sql = "INSERT INTO users SET ?";
		    	query = conn.query(sql, userData, function (err, result){
		    		if (err) {
		    			logger.error('Error inserting user in database', err);
		    			console.log(err.code);
		    			console.log(err);
	        			callback(null, {success:false, error: err.code});
			          
			        }else{
			        	result = {success: true, msg: "User resgistered correctly." , user: userData.email};
		        		logger.info('User added correctly', result);
			        	console.log("User registered: " + userData.email);  
			        	callback(result, null); 
			        }

		    	});
	    	}
	  	});

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



