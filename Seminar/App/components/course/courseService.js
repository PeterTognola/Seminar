app.service("courseService",
    function ($http) {
        var postConfig = {
            headers: {
                'Content-Type': "application/x-www-form-urlencoded"
            }
        };

        this.getCourses = function () {
            return $http.get("/Courses/");
        };

        this.getCourse = function (id) {
            return $http.get("/Courses/Get/" + id);
        };

        this.createCourse = function (course) {
            return $http({
                method: "POST",
                url: "/Courses/Create",
                data: $.param(course),
                headers: postConfig.headers
            });
        };
    });