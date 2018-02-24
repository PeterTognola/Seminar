(function () {
    "use strict";

    angular
        .module("app.courses")
        .run(appRun);

    appRun.$inject = ["routerHelper"];

    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [];
    }
})();