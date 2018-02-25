app.controller("courseController", [
    "$scope", "courseService",
    function ($scope, courseService) {
        $scope.viewModel = {
            Id: "",
            Name: "",
            Instructor: "",
            Room: "",
            From: "",
            To: ""
        };

        $scope.courses = {};

        $scope.getCourses = function() {
            var data = courseService.getCourses();

            data.then(function(courses) {
                $scope.courses = courses.data;
            });
        };

        $scope.createCourse = function() {
            var response = courseService.createCourse($scope.viewModel);

            if (response.$$state.status === 2) {
                console.log("failed");
                return;
            }

            // redirect user.
        };

        $scope.getCourses();
    }
]);