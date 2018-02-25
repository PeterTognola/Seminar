app.controller("courseController", [
    "$scope", "$window", "courseService",
    function ($scope, $window, courseService) {
        function load() {
            $scope.viewModel = {
                Id: "",
                Name: "",
                Instructor: "",
                Room: "",
                From: "",
                To: ""
            };

            $scope.courses = {};

            $scope.getCourses();
        }

        $scope.getCourses = function() {
            var data = courseService.getCourses();

            data.then(function(courses) {
                $scope.courses = courses.data;
            });
        };

        $scope.createCourse = function() {
            var response = courseService.createCourse($scope.viewModel);

            if (response.$$state.status === 2) {
                toastr.error("Unable to create course!", "Error!");
                return;
            }

            toastr.success("Course created successfully!", "Success!");
            $window.location.href = "#!course";
        };

        $scope.$on("$routeChangeUpdate", load);
        $scope.$on("$routeChangeSuccess", load);

        load();
    }
]);