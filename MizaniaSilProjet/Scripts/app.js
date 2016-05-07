var app = angular.module('MizaniaProjectModule', ['ngRoute']);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/Home", {
            templateUrl: "Home.html",
            controller: "UserBDController"
        })
        .when("/Users", {
            templateUrl: "ListeUsers.html",
            controller: "UserBDController"
        })
        .when("/ModifyAccount/:id", {
            templateUrl: "EditCompte.html",
            controller: "AccountBDController"
        })
        .when("/NewAccount", {
            templateUrl: "AjouterCompte.html",
            controller: "AccountBDController"
        })
         .when("/UserAccounts/:id", {
             templateUrl: "ListeComptesUser.html",
             controller: "UserBDController"
         })
        .when("/Accounts", {
            templateUrl: "ListeComptes.html",
            controller: "AccountBDController"
        })
        .when("/CategoriesList", {
            templateUrl: "ListeCategories.html",
            controller: "CategorieBDController"
        })
        .when("/NewCategorie", {
            templateUrl: "AjouterCategorie.html",
            controller: "CategorieBDController"
        })
        .when("/ModifyCategorie/:id", {
            templateUrl: "EditCategorie.html",
            controller: "CategorieBDController"
        })
        .when("/TransactionsDepenses", {
            templateUrl: "ListeTransactionsDepenses.html",
            controller: "TransactionBDController"
        })
        .when("/ajouterTransaction", {
            templateUrl: "AjouterTransaction.html",
            controller: "TransactionBDController"
        })


        
    .otherwise({ redirectTo: "/Home" })
});
