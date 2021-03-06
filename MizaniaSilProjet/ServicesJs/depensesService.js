﻿(function () {
    var depensesService = function ($http, $q, $log) {


        var Depenses = function () {
            return $http.get("http://localhost:1949/api/Transaction/getTransactDepenses/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var TotalDepenses = function () {
            return $http.get("http://localhost:1949/api/Transaction/getTotalDepenses/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var TotalRevenus = function () {
            return $http.get("http://localhost:1949/api/Transaction/getTotalRevenus/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var Revenus = function () {
            return $http.get("http://localhost:1949/api/Transaction/getTransactEntrees/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var NomCategorie = function (id, idCompte) {
            return $http.get("http://localhost:1949/api/Transaction/getNomCategorie/" + id + "/" + idCompte)
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var Categories = function () {
            return $http.get("http://localhost:1949/api/Categorie/getAll/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var Accounts = function () {
            return $http.get("http://localhost:1949/api/Compte/getAll/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };


        var InsertDepense = function (depense) {
            return $http.post("http://localhost:1949/api/Transaction/addTransaction", depense)
            .then(function () {
                $log.info("Insert Successful");
                return;
            });
        };

        var singleCategorie = function (id) {
            return $http.get("http://localhost:1949/api/Categorie/getCategorieById/" + id)
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var ModifyCategorie = function (categorie) {
            return $http.put("http://localhost:1949/api/Categorie/updateCategorie/" + categorie.id, categorie)
            .then(function (result) {
                $log.info("Update Successful");
                return;
            });
        };



        var deleteDepense = function (depense) {
            return $http.delete("http://localhost:1949/api/Transaction/deleteTransaction/" + depense.id + "/" + depense.idCompte)
            .then(function (result) {
                $log.info("Delete Successful");
                return;
            });
        };

        return {
            Depenses: Depenses,
            NomCategorie : NomCategorie,
            Revenus: Revenus,
            TotalDepenses: TotalDepenses,
            TotalRevenus : TotalRevenus,
            Categories: Categories,
            Accounts : Accounts,
            singleCategorie: singleCategorie,
            InsertDepense: InsertDepense,
            ModifyCategorie: ModifyCategorie,
            deleteDepense:  deleteDepense
        };
    };
    var module = angular.module("MizaniaProjectModule");
    module.factory("depensesService", ["$http", "$q", "$log", depensesService]);
}());