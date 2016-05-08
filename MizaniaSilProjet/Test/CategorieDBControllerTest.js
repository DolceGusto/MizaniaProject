describe('CategorieBDController', function () {
    beforeEach(module('MizaniaProjectModule'));

    var categorie1 = {
        id: 1,
        idPorteFeuille: 1,
        designation: 'Courses',
        descript: 'Courses'
    };

    var categorie2 = {
        id: 2,
        idPorteFeuille: 1,
        designation: 'Courses',
        descript: 'Courses'
    };

    it('scopeCategorieTestSpec',
        inject(function ($controller, $rootScope) {
            var $scope = $rootScope.$new();
            $controller('CategorieBDController', {
                $scope: $scope
            });
            expect($scope.categorie.idPorteFeuille).toEqual(1);

        }));

   it('scopeDelteCategorieTestSpec',
        inject(function ($controller, $rootScope) {
            var $scope = $rootScope.$new();
            $controller('CategorieBDController', {
                $scope: $scope
            });
            expect($scope.deleteCategorie(categorie1)).toEqual(true);
        }));
       
    it('scopeModifyCategorieTestSpec',
       inject(function ($controller, $rootScope) {
           var $scope = $rootScope.$new();
           $controller('CategorieBDController', {
               $scope: $scope
           });
           var categorie3 = {
               id: 1,
               idPorteFeuille: 1,
               designation: 'Etudes',
               descript: 'Courses'
           };

           $scope.ModifyCategorie(categorie3);
           //expect($scope.Categories[0].designation).toEqual('Etudes');

       }));

    it('scopeCategoriesTestSpec',
       inject(function ($controller, $rootScope) {
           var $scope = $rootScope.$new();
           $controller('CategorieBDController', {
               $scope: $scope
           });
           $scope.Categories = [categorie1,categorie2];
           expect($scope.Categories.length).toBe(2);
           expect($scope.Categories[0].descript).toEqual('Courses');

       }));

});