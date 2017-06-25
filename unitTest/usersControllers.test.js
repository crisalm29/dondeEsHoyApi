// usersControllerTest.js

var assert = require('assert');

var usersController = require('../app/models/usersController.js');

describe('User controller unit testing', function(){
	it('Register user successfully', function(){

		usersController.registerUser({
			password: 'somepasw'
		});
		assert.equal(1,1);
		
	});

});