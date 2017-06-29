// usersController.js

"use strict";

var dataAccess = require('../common/dataAccess.js');
var logger = require('../common/logger.js');

var crypto = require("crypto");

var usersController = {
	registerUser: function (userData){
		var result = null;
		if(!userData.name){
			result = {
				success: false,
				msg: "Missing parameter: name"
			};
		}
		
		if(!userData.email){
			result = {
				success: false,
				msg: "Missing parameter: email"
			};	
		}

		
		if(!userData.password){
			result = {
				success: false,
				msg: "Missing parameter: password"
			};	
		}

		if(!userData.lastName){
			result = {
				success: false,
				msg: "Missing parameter: lastName"
			};	
		}
		if(!result){

			userData.password = crypto.createHash('sha256').update(userData.password).digest('hex');
			result = dataAccess.insertUser(userData);
			console.log(result);
			if(result.success){
				logger.info('User registered', userData.email);

			}
			else{
				logger.error('Error adding new user', result);
			}

		}else{
			logger.error('Missing parameter', result);
		}

		return result;

	},

	login: function(loginData){

		var result = null;

		if(!loginData.email){
			result = {
				success: false,
				msg: "Missing parameter: email"
			};	
		}

		
		if(!loginData.password){
			result = {
				success: false,
				msg: "Missing parameter: password"
			};	
		}
		if(!result){
			userData.password = crypto.createHash('sha256').update(userData.password).digest('hex');
			result = dataAccess.login(loginData);

		}else{
			logger.error('Missing parameter', result);
		}

		return result;


	}
}




module.exports = usersController;


