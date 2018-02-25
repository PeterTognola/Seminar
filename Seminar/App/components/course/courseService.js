app.service("courseService",
    function($http) {
        this.getCourses = function () {
            return $http.get("/Courses/");
        };
    });