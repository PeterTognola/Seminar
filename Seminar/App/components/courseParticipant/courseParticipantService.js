app.service("courseParticipantService",
    function ($http) {
        var postConfig = {
            headers: {
                'Content-Type': "application/x-www-form-urlencoded"
            }
        };

        this.getCourseParticipants = function (courseId) {
            return $http.get("/CourseParticipants/Get/" + courseId);
        };

        this.createCourseParticipant = function (courseParticipant) {
            return $http({
                method: "POST",
                url: "/CourseParticipants/Create",
                data: $.param(courseParticipant),
                headers: postConfig.headers
            });
        };
    });