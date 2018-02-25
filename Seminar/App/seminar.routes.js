// Configure routes
var configFunction = function ($routeProvider, $httpProvider) {
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
        .otherwise({ redirectTo: "/course", controller: "courseController" });

    //
    // Because we are using ASP.NET MVC Actions we need to
    // tell them we are a safe client.
    var antiForgeryToken = document.getElementById("antiForgeryForm").childNodes[1].value;
    $httpProvider.defaults.headers.post["__RequestVerificationToken"] = antiForgeryToken;

};

configFunction.$inject = ["$routeProvider", "$httpProvider"];