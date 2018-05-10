(function() {
        "use strict";

        angular
            .module("candidate")
            .controller("app.views.layout", layoutController);

        layoutController.$inject =
        [
            "$scope",
            "$http",
            "serv"
        ];

        function layoutController(
            $scope,
            $http,
            languageService) {

            /* jshint validthis:true */
            var vm = this;

            vm.changeCulture = changeCulture;
            $scope.L = {};
            vm.currentLanguage = "";
            init();

            function init() {
                getResources("current");
            }

            function changeCulture(culture) {
                getResources(culture);
            }

            function getResources(culture) {

                languageService.getResources(culture).then(response);

                function response(resp) {
                    $scope.L = resp.data;
                    vm.currentLanguage = languageService.currentLanguage;
                }
            }
        }
    }
)();