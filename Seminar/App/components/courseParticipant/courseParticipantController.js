app.controller("courseParticipantController", [
    "$scope", "$routeParams", "courseParticipantService", "courseService",
    function ($scope, $routeParams, courseParticipantService, courseService) {
        $scope.viewModel = {
            Name: "",
            Email: "",
            CourseId: $routeParams.id
        };

        $scope.course = {};

        $scope.courseParticipants = {};

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

            console.log(response);

            // todo response.status = 2 is bad.
        };

        $scope.getCourseParticipants();
        $scope.getCourse();
    }
]);