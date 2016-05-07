(function () {
    var accountsService = function ($http, $q, $log) {


        var Accounts = function () {
            return $http.get("http://localhost:1949/api/Compte/getAll/")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var InsertAccount = function (user, account) {
            var strFinal = "[" + JSON.stringify(user) + "," +
                       JSON.stringify(account) + "]";
           
            return $http.post("http://localhost:1949/api/Compte/addUserV", strFinal)
            .then(function () {
                $log.info("Insert Successful");
                return;
            });
        };

        var singleAccount = function (id) {
            return $http.get("http://localhost:1949/api/Compte/getOneAccount/" + id)
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var ModifyAccount = function (account) {
            return $http.put("http://localhost:1949/api/Compte/updateAccount/" + account.id, account)
            .then(function (result) {
                $log.info("Update Successful");
                return;
            });
        };

       
        var deleteAccount = function (account) {
            return $http.delete("http://localhost:1949/api/Compte/deleteAccount/" + account.id)
            .then(function (result) {
                $log.info("Delete Successful");
                return;
            });
        };

        
        return {
            Accounts: Accounts,
            singleAccount: singleAccount,
            InsertAccount: InsertAccount,
            ModifyAccount: ModifyAccount,
            deleteAccount: deleteAccount
        };
    };
    var module = angular.module("MizaniaProjectModule");
    module.service('accountsService', ["$http", "$q", "$log", accountsService]);
}());