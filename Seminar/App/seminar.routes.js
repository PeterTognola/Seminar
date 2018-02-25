// Configure routes
var configFunction = function ($routeProvider) {
    $routeProvider
        .when("/course",
            {
                templateUrl: "/App/components/course/courseView.html",
                controller: "courseController"
            })
        .when("/course/create",
            {
                templateUrl: "/App/components/course/courseCreateView.html",
                controller: "courseController"
            })
        .when("/courseParticipant/create/:id",
            {
                templateUrl: "/App/components/courseParticipant/courseParticipantCreateView.html",
                controller: "courseParticipantController"
            })
        .when("/courseParticipant/:id",
            {
                templateUrl: "/App/components/courseParticipant/courseParticipantView.html",
                controller: "courseParticipantController"
            })
        .otherwise({ redirectTo: "/course", controller: "courseController" }); // todo <component>.routes.js file for each component.
};

configFunction.$inject = ["$routeProvider"];