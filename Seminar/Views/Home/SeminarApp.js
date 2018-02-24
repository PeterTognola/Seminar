// Register application
var app = angular.module("Seminar", ["ngRoute"]);

// Configure routes
var configFunction = function ($routeProvider) {
	$routeProvider.
		when('/home', { templateUrl: 'Home/Home', controller: 'HomeCtrl'}).
		otherwise({ redirectTo: '/home', controller: 'HomeCtrl' });
};
configFunction.$inject = ['$routeProvider'];

// Configure application
app.config(configFunction);