it('should map routes to controllers', function () {
    module('MizaniaProjectModule');

    inject(function ($route) {
        expect($route.routes['/Accounts']).toBeDefined();
        expect($route.routes['/Accounts'].controller).toBe('AccountBDController');
        expect($route.routes['/Accounts'].templateUrl).toEqual('ListeComptes.html');

    });
});