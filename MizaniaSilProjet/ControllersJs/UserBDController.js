﻿(function () {
    var UserBDController = function ($scope, usersService, $log, $routeParams) {
        var Users = function (data) {
            $scope.Users = data;
        };

        var singleUser = function (data) {
            $scope.existingUser = data;
            $log.info(data);
        };


        $scope.init = function () {
            usersService.singleUser($routeParams.id)
                .then(singleUser, errorDetails);
        };

        $scope.SearchUsers = function (UserName) {
            usersService.SearchUsers(UserName)
            .then(Users, errorDetails);
            $log.info('Found user which contains - ' + UserName);
        };


        var account = {
            id: null,
            designation: null,
            descript: null,
            solde: null,
            idUtilisateur: 13
        };
        $scope.account = account;

        var user = {
            id: null,
            nom: null,
            prenom: null,
            nomDeCompte: null,
            roleUtilisateur: null,
            idFacebook: 123456,
            idPorteFeuille: 1
        };
        $scope.user = user;

        usersService.Users().then(Users, errorDetails);

        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.InsertUser = function (user, account) {
            usersService.InsertUser(user, account);
        };

        $scope.ModifyUser = function (existingUser) {
            $log.info(existingUser);
            usersService.ModifyUser(existingUser).then(usersService.Users().then(Users, errorDetails));
        };

        $scope.deleteUser = function (user) {
            $log.info(user);
            if (confirm("Etes-vous sûr de vouloir supprimer cet utilisateur ?"))
                 {
            usersService.deleteUser(user)
                .then(Users, errorDetails);}
        };


        //  var UserAccounts =function (data) {


        $scope.UserAccounts = function (user) {
            $log.info(user);
            usersService.UserAccounts(user).then(usersService.Users().then(Users, errorDetails));

        };
        // };


        $scope.Title = "Users";
        $scope.UserName = null;
    };
    app.controller("UserBDController", ["$scope", "usersService", "$log", "$routeParams", UserBDController]);
}());