// Configure routes
var configFunction = function ($routeProvider) {
    $routeProvider
        .when("/home",
            {
                templateUrl: "/App/components/home/homeView.html",
                controller: "homeController"
            })
        .when("/course",
            {
                templateUrl: "/App/components/course/courseView.html",
                controller: "courseController"
            })
        .otherwise({ redirectTo: "/home", controller: "homeController" }); // todo <component>.routes.js file for each component.
};

configFunction.$inject = ["$routeProvider"];