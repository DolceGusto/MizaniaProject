﻿(function () {
    var TransactionBDController = function ($scope, depensesService, $log, $routeParams) {
        var Depenses = function (data) {
            $scope.Depenses = data;
        };

     /*  var NomCategorie2 = function (data) {
            $scope.NomCategorie2 = data;
       };*/
       

        var TotalDepenses = function (data) {
            $scope.TotalDepenses = data;
        };

        var Revenus = function (data) {
            $scope.Revenus = data;
        };

        var TotalRevenus = function (data) {
            $scope.TotalRevenus = data;
        };

        var Categories = function (data) {
            $scope.Categories = data;
        };

        var Accounts = function (data) {
            $scope.Accounts = data;
        };

        var singleDepense = function (data) {
            $scope.existingDepense = data;
            $log.info(data);
        };


        $scope.init = function () {
            depensesService.singleDepense($routeParams.id)
                .then(singleDepense, errorDetails);
        };

        var depense = {
            id: null,
            idCompte: null,
            desination: null,
            montant: null,
            typeTransact: null,
            idCategorie: null,
            dateCreation: null
        };

        $scope.depense = depense;

        depensesService.Depenses().then(Depenses, errorDetails);
      //  depensesService.NomCategorie(depense.id,depense.idCompte).then(NomCategorie, errorDetails);
        depensesService.Revenus().then(Revenus, errorDetails);
        depensesService.TotalDepenses().then(TotalDepenses, errorDetails);
        depensesService.TotalRevenus().then(TotalRevenus, errorDetails);
        depensesService.Accounts().then(Accounts, errorDetails);
        depensesService.Categories().then(Categories, errorDetails);

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.InsertDepense = function (depense) {
            depensesService.InsertDepense(depense).then(depensesService.Depenses().then(Depenses, errorDetails));

        };

   /*    $scope.NomCategorie = function (id, idCompte) {
            depensesService.NomCategorieDepense(id,idCompte).then(NomCategorie2, errorDetails));
    };*/

        $scope.ModifyDepense = function (existingDepense) {
            $log.info(existingDepense);
            depensesService.ModifyDepense(existingDepense).then(depensesService.Depenses().then(Depenses, errorDetails));
        };

        $scope.deleteDepense = function (depense) {
            $log.info(depense);
            if (confirm("Etes-vous sûr de vouloir supprimer cette dépense ?")) {
                depensesService.deleteDepense(depense)
                    .then(Depenses, errorDetails);
                return true;
            }
        };
    };
    app.controller("TransactionBDController", ["$scope", "depensesService", "$log", "$routeParams", TransactionBDController]);
}());