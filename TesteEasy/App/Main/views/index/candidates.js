(function() {
        "use strict";

        angular
            .module("candidate")
            .controller("app.views.index", candidatesController);

        candidatesController.$inject =
        [
            "$scope",
            "$http",
            "serv"
        ];

        function candidatesController(
            $scope,
            $http,
            languageService) {

            /* jshint validthis:true */
            var vm = this;

            $scope.L = {};

            vm.tableParams = [];

            vm.selectedCandidateId = undefined;

            vm.candidates = [];

            vm.setSelected = setSelected;

            vm.remove = remove;

            vm.language = "";

            activate();

            function loadCandidates() {
                $http.get("/api/candidate")
                    .then(fillCandidates);

                function fillCandidates(result) {
                    vm.candidates = result.data;
                }
            }

            function activate() {
                loadCandidates();
                getResources();
            }

            function getResources() {

                languageService.getResourcesIndex().then(response);

                function response(resp) {
                    $scope.L = resp.data;
                    vm.language = languageService.currentLanguage;
                }
            }


            function setSelected(objectId) {
                vm.selectedCandidateId = objectId;
            }

            function remove() {
                $http.delete("/api/candidate/" + vm.selectedCandidateId)
                    .then(loadCandidates)
                    .then(successfulyDeleted);

                function successfulyDeleted() {
                    M.toast({ html: "Candidato removido com sucesso!" }, 3000);
                    vm.selectedCandidateId = 0;
                }
            }
        }
    }
)();