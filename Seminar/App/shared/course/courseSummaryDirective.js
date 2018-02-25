app.directive("courseSummaryDirective", function() {
    return {
        scope: {
            title: "@",
            course: "="
        },
        templateUrl: "/App/shared/course/courseSummaryView.html",
        replace: true
    };
});