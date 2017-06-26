// usersControllerTest.js

var assert = require('assert');
var sinon = require('sinon');

var usersController = require('../app/models/usersController.js');
var dataAccess = require('../app/common/dataAccess.js');
var logger = require('../app/common/logger.js');

describe('User controller unit testing', function(){
	it('Register user successfully', function(){


		var userData = {
			password: 'testpwd',
			email: 'test@dondeeshoy.com',
			name: 'userName',
			lastName: 'userLastName'
		};


		var stub = sinon.stub(dataAccess, "insertUser").callsFake(function(userData){ return {success: true, msg: ""}});

		var loggerMock = sinon.mock(logger);
		loggerMock.expects('info').withArgs('User registered', 'test@dondeeshoy.com').exactly(1);

		result = usersController.registerUser(userData);
		
		assert(result.success, 'Result got an error');
		loggerMock.verify();

	});

	it('Register user missing name error', function(){

		var userData = {
			password: 'testpwd',
			email: 'test@dondeeshoy.com',
			lastName: 'userLastName'
		};

		var loggerMock = sinon.mock(logger);
		loggerMock.expects('error').withArgs('Missing parameter', {success: false, msg: "Missing parameter: name"}).exactly(1);
		result = usersController.registerUser(userData);

		assert(!result.success, 'Error not raised');
		
		loggerMock.verify();
	});


	it('Register user missing email error', function(){

		var userData = {
			password: 'testpwd',
			name: 'userName',
			lastName: 'userLastName',
		};

		var loggerMock = sinon.mock(logger);
		loggerMock.expects('error').withArgs('Missing parameter', {success: false, msg: "Missing parameter: email"}).exactly(1);
		result = usersController.registerUser(userData);

		assert(!result.success, 'Error not raised');
		
		loggerMock.verify();
	});


	it('Register user missing password error', function(){

		var userData = {
			email: 'test@dondeeshoy.com',
			name: 'userName',
			lastName: 'userLastName'
		};

		var loggerMock = sinon.mock(logger);
		loggerMock.expects('error').withArgs('Missing parameter', {success: false, msg: "Missing parameter: password"}).exactly(1);
		result = usersController.registerUser(userData);

		assert(!result.success, 'Error not raised');
		
		loggerMock.verify();
	});


	it('Register user missing lastName error', function(){

		var userData = {
			password: 'testpwd',
			email: 'test@dondeeshoy.com',
			name: 'userName'
		};

		var loggerMock = sinon.mock(logger);
		loggerMock.expects('error').withArgs('Missing parameter', {success: false, msg: "Missing parameter: lastName"}).exactly(1);
		result = usersController.registerUser(userData);

		assert(!result.success, 'Error not raised');
		
		loggerMock.verify();
	});

});