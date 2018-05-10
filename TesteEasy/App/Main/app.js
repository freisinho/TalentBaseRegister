(function() {
    var app = angular.module("candidate", ["ngRoute"]);

    $(document).ready(function() {
        $(".sidenav").sidenav();
    });
    $(".dropdown-trigger").dropdown();

    app.service("servi",
        function ($http) {

            var currentLanguage = "";

            this.getResources = function() {
                var response = $http.get('http://localhost:54805/api/accessresources/"current"');
                return response;
            };
        });

    app.service("serv",
        function($http) {
            this.currentLanguage = "";

            this.getResources = getResources;

            this.getResourcesIndex = getResourcesIndex;


            function getResources(culture) {
                this.currentLanguage = culture;

                return $http.get("http://localhost:54805/api/accessresources/" + culture);
            }

            function getResourcesIndex() {

                return $http.get("http://localhost:54805/api/accessresources/" + this.currentLanguage);
            }
        });

    app.filter("lowerCamelCase",
        function() {
            var camelCaseFilter = function(input) {
                var words = input.split(" ");
                for (var i = 0, len = words.length; i < len; i++)
                    words[i] = words[i].charAt(0).toLowerCase() + words[i].slice(1);
                return words.join(" ");
            };
            return camelCaseFilter;
        });
    app.config(function($routeProvider) {

        $routeProvider
            .when("/",
                {
                    templateUrl: "/App/Main/views/index/candidates.html",
                    controller: "app.views.index"
                })
            .when("/candidate/:candidateId",
                {
                    templateUrl: "/App/Main/views/candidate/candidate.html",
                    controller: "app.views.candidate"
                })
            .when("/candidate",
                {
                    templateUrl: "/App/Main/views/candidate/candidate.html",
                    controller: "app.views.candidate"
                })
            .when("/candidate/:language",
                {
                    templateUrl: "/App/Main/views/candidate/candidate.html",
                    controller: "app.views.candidate"
                })
            .otherwise(
                { redirecTo: "/" });
    });

})();