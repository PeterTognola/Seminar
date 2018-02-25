app.controller("courseController", [
    "$scope", "courseService",
    function ($scope, courseService) {
        function getCourses() {
            var data = courseService.getCourses();

            data.then(function(courses) {
                $scope.courses = courses.data;
            });
        }

        getCourses();
    }
]);