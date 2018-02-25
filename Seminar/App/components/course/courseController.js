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

        $scope.getCourses = function() {
            var data = courseService.getCourses();

            data.then(function(courses) {
                $scope.courses = courses.data;
            });
        };

        $scope.createCourse = function() {
            var response = courseService.createCourse($scope.viewModel);

            console.log(response);

            // todo response.status = 2 is bad.
        };

        $scope.getCourses();
    }
]);