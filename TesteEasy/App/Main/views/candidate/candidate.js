(function() {
        "use strict";

        angular
            .module("candidate")
            .controller("app.views.candidate", candidatesController);

        candidatesController.$inject =
        [
            "$scope",
            "$http",
            "$routeParams",
            "serv"
        ];

        function candidatesController(
            $scope,
            $http,
            $routeParams,
            languageService) {

            /* jshint validthis:true */
            var vm = this;

            $scope.L = {};
            vm.progress = 0;
            vm.candidateId = $routeParams.candidateId;
            vm.timesToWork = [];
            vm.accountTypes = [];
            vm.technologies = [];
            vm.changeSelectedValueTechnology = changeSelectedValueTechnology;

            vm.candidate = {
                id: 0,
                email: { address: "" },
                name: "",
                skype: { name: "" },
                phone: { number: "" },
                linkedin: "",
                address: {
                    city: {
                        state: { name: "" },
                        name: ""
                    }
                },
                portifolio: "",
                salary: 0,
                bank: {
                    name: "",
                    cpf: "",
                    agency: "",
                    account: ""
                },
                crudLink: "",
                timeToWork: "",
                willingness: "",
                accountType: "",
                otherKnowledge: "",
                candidateKnowledge: []
            };

            vm.actualPage = 0;

            vm.backPage = backPage;
            vm.nextPage = nextPage;
            vm.submit = submit;

            vm.willingnessList = [];

            function init() {

                vm.actualPage = 1;
                vm.progress = vm.actualPage * 25;
                getResources();
                getTypesAndFillsCandidate();
            }

            function getTypesAndFillsCandidate() {
                $http.get("/api/type/")
                    .then(fillsType)
                    .then(operationVerify)
                    .then(loadSelect)
                    .then(fillsKnowledge);

                function fillsType(result) {
                    vm.timesToWork = result.data.timesToWork;
                    vm.willingnessList = result.data.willingness;
                    vm.accountTypes = result.data.accountTypes;
                    vm.technologies = result.data.technologies;
                }

                function fillsKnowledge() {
                    for (var aux = 0; aux < vm.technologies.length; aux++) {
                        vm.candidate.candidateKnowledge.push({
                            technologyId: vm.technologies[aux].id,
                            name: vm.technologies[aux].name,
                            evaluation: 0
                        });
                    }
                }

                function operationVerify() {
                    if (vm.candidateId) {
                        $http.get("/api/candidate/" + vm.candidateId)
                            .then(fillsCandidate)
                            .then(loadSelect);
                    }

                    function fillsCandidate(result) {
                        vm.candidate = result.data;
                    }
                }

                function loadSelect() {
                    $(document).ready(function() {
                        $("select").formSelect();
                    });
                }
            }

            function backPage() {
                if (vm.actualPage > 1) {
                    vm.actualPage--;
                    vm.progress = vm.actualPage * 25;
                }
            }

            function nextPage() {
                if (validate())
                    if (vm.actualPage < 4)
                        vm.actualPage++;
                vm.progress = vm.actualPage * 25;
            }

            function submit() {
                if (validate()) {

                    if (!vm.candidateId) {
                        $http.post("/api/candidate", vm.candidate)
                            .then(successCreatedToast);
                    } else {
                        $http.put("/api/candidate/" + vm.candidateId, vm.candidate)
                            .then(successUpdatedToast);
                    }
                }

                function successCreatedToast() {
                    M.toast({ html: "Candidato cadastrado com sucesso!" }, 3000);
                }

                function successUpdatedToast() {
                    M.toast({ html: "Candidato atualizado com sucesso!" }, 3000);
                }
            }

            function changeSelectedValueTechnology(option, item) {
                vm.candidate.candidateKnowledge[option.id - 1].evaluation = item;
            }

            function validate() {
                if (vm.actualPage === 1) {

                    var formOne = $("#candidateFormOne").parsley();

                    if (!formOne.isValid()) {
                        $("#candidateFormOne").submit();
                        return false;
                    }
                    return true;
                }

                if (vm.actualPage === 2) {

                    var formTwo = $("#candidateFormTwo").parsley();

                    if (!formTwo.isValid()) {
                        $("#candidateFormTwo").submit();
                        return false;
                    }
                    return true;
                }

                if (vm.actualPage === 3) {

                    var formThree = $("#candidateFormThree").parsley();

                    if (!formThree.isValid()) {
                        $("#candidateFormThree").submit();
                        return false;
                    }
                    return true;
                }

                if (vm.actualPage === 4) {

                    var formFour = $("#candidateFormFour").parsley();

                    if (!formFour.isValid()) {
                        $("#candidateFormFour").submit();
                        return false;
                    }
                    return true;
                }
                return true;
            }

            function getResources() {

                languageService.getResourcesIndex().then(response);

                function response(resp) {
                    $scope.L = resp.data;
                }
            }

            init();
        }
    }
)();