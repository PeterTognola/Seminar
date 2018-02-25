app.controller("courseParticipantController", [
    "$scope", "$window", "$routeParams", "courseParticipantService", "courseService",
    function ($scope, $window, $routeParams, courseParticipantService, courseService) {
        function load() {
            $scope.viewModel = {
                Name: "",
                Email: "",
                CourseId: $routeParams.id
            };

            $scope.course = {};

            $scope.courseParticipants = {};

            $scope.getCourseParticipants();
            $scope.getCourse();
        }

        $scope.getCourse = function() {
            var data = courseService.getCourse($routeParams.id);

            data.then(function (course) {
                $scope.course = course.data;
            });
        };

        $scope.getCourseParticipants = function() {
            var data = courseParticipantService.getCourseParticipants($routeParams.id);

            data.then(function(courseParticipant) {
                $scope.courseParticipants = courseParticipant.data;
            });
        };

        $scope.createCourseParticipant = function() {
            var response = courseParticipantService.createCourseParticipant($scope.viewModel);

            if (response.$$state.status === 2) {
                toastr.error("Unable to add participant to " + $scope.course.Name + ".", "Error!");
                return;
            }

            toastr.success("Participant has been added to " + $scope.course.Name + ".", "Success!");
            $window.location.href = "#!courseParticipant/" + $scope.course.Id;
        };

        $scope.$on("$routeChangeUpdate", load);
        $scope.$on("$routeChangeSuccess", load);

        load();
    }
]);