describe('AccountBDController', function () {
    beforeEach(module('MizaniaProjectModule'));

    var account1 = {
        id: 1,
        designation: 'WissCCP',
        descript: 'CompteCCP',
        solde: 0,
        idUtilisateur: 1
    };
    var account2 = {
        id: 1,
        designation: 'WissCCP2',
        descript: 'CompteCCP2',
        solde: 0,
        idUtilisateur: 1
    };

    it('scopeAccountTestSpec',
        inject(function ($controller, $rootScope) {
            var $scope = $rootScope.$new();
            $controller('AccountBDController', {
                $scope: $scope
            });
            expect($scope.account.idUtilisateur).toEqual(2);
           
        }));

    it('scopeDelteAccountTestSpec',
        inject(function ($controller, $rootScope) {
            var $scope = $rootScope.$new();
            $controller('AccountBDController', {
                $scope: $scope
            });
            expect($scope.deleteAccount(account1)).toEqual(true);   
        }));

    it('scopeModifyAccountTestSpec',
       inject(function ($controller, $rootScope) {
           var $scope = $rootScope.$new();
           $controller('AccountBDController', {
               $scope: $scope
           });
           $scope.ModifyAccount(account1);
       }));

    it('scopeAccountsTestSpec',
       inject(function ($controller, $rootScope) {
           var $scope = $rootScope.$new();
           $controller('AccountBDController', {
               $scope: $scope
           });
           $scope.Accounts = [account1, account2];
           expect($scope.Accounts.length).toBe(2);
           expect($scope.Accounts[0].descript).toEqual('CompteCCP');

       }));
   
});