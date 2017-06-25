// usersController.js

"use strict";

var dataAccess = require('../common/dataAccess.js');

var crypto = require("crypto");

var dataAccess = {
	registerUser: function (userData){

		if(userData.name)
			return {
				success: false;
				msg: "Missing parameter: name"
			};
		
		if(userData.email)
			return {
				success: false;
				msg: "Missing parameter: name"
			};	


		userData.password = crypto.createHash('sha256').update(userData.password).digest('hex');
		console.log(userData);


	}
}




module.exports = dataAccess;


