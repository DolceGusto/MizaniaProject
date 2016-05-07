﻿(function () {
    var AccountBDController = function ($scope, accountsService, $log, $routeParams) {
        var Accounts = function (data) {
            $scope.Accounts = data;
        };

        var TotalAccounts = function (data) {
            $scope.TotalAccounts = data;
        };

        var singleAccount = function (data) {
            $scope.existingAccount = data;
            $log.info(data);
        };


        $scope.init = function () {
            accountsService.singleAccount($routeParams.id)
                .then(singleAccount, errorDetails);
        };
      
        var account = {
            id: null,
            designation: null,
            descript: null,
            solde: null,
            idUtilisateur: 2
        };
        $scope.account = account;

        var user = {
            id: null,
            nom: null,
            prenom: null,
            nomDeCompte: null,
            roleUtilisateur: null,
            idFacebook : 123456,
            idPorteFeuille: 1
        };
        $scope.user = user;

        accountsService.Accounts().then(Accounts, errorDetails);
        accountsService.TotalAccounts().then(TotalAccounts, errorDetails);

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.InsertAccount = function (user,account) {
            accountsService.InsertAccount(user,account);
        };

        $scope.ModifyAccount = function (existingAccount) {
            $log.info(existingAccount);
            accountsService.ModifyAccount(existingAccount).then(accountsService.Accounts().then(Accounts, errorDetails));
        };

        $scope.deleteAccount = function (account) {
            $log.info(account);
            if (confirm("Etes-vous sûr de vouloir supprimer ce compte ?")) {
                accountsService.deleteAccount(account)
                    .then(Accounts, errorDetails);
                return true; 
            }
        };


        $scope.Title = "Accounts";
        $scope.AccountName = null;
    };
    app.controller("AccountBDController", ["$scope", "accountsService", "$log", "$routeParams", AccountBDController]);
}());