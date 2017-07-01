// usersController.js

"use strict";

var dataAccess = require('../common/dataAccess.js');
var logger = require('../common/logger.js');

var crypto = require("crypto");

var usersController = {
	registerUser: function (userData, callback){
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
		if(!userData.imagebase64){
			userData.imagebase64 = "";
		}
		if(!result){

			userData.password = crypto.createHash('sha256').update(userData.password).digest('hex');
			dataAccess.insertUser(userData, callback);
				
		}else{
			callback(null, result);
			logger.error('Missing parameter', result);
		}

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


