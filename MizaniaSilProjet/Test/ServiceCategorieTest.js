// Avec describe on définit ce qu'on doit tester ! dans notre cas c'est un service angular 
describe('categoriesService', function () {
    var categoriesService, httpBackend;
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

    beforeEach(function () { //Avant d'exécuter n'importe quel test spec, on exécute d'abord le code qui va suivre 

        module('MizaniaProjectModule'); //A savoir : Charger le module se trouvant dans App.js 

        // Obtenir l'objet du test en question (service dans notre cas) 
        // $httpBackend c'est un mock, il permet d'implémenter un fake http afin qu'on puisse faire les tests angulars des services par la suite.
        inject(function ($httpBackend, _categoriesService_) {
            categoriesService = _categoriesService_;
            httpBackend = $httpBackend;
        });
    });

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

    // Définir la spécification de test
    it('ServiceSingleCategorieTestSpec', function () {

        var returnData = {};

        // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 
        httpBackend.expectGET("http://localhost:1949/api/Categorie/getCategorieById/1").respond(returnData);


        // Appeler la fonction singleAccount(id) du service accountsService
        var returnedPromise = categoriesService.singleCategorie(1);

        //Result contiendra le résultat obtenu lors de l'appel de la fonction du service
        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        httpBackend.whenGET('Home.html').respond(200, '');

        httpBackend.flush();  //Permet d'exécuter la requête expectGet 

        expect(result).toEqual(returnData); // Vérification des résultats 

    });

    it('ServiceCategoriesTestSpec', function () {

        var returnData = {};

        // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 
        httpBackend.expectGET("http://localhost:1949/api/Categorie/getAll/").respond(returnData);

        var returnedPromise = categoriesService.Categories();

        //Result contiendra le résultat obtenu lors de l'appel de la fonction du service
        var result;
        returnedPromise.then(function (response) {
            result = response;
        });

        httpBackend.whenGET('Home.html').respond(200, '');

        httpBackend.flush();  //Permet d'exécuter la requête expectGet 

        expect(result).toEqual(returnData); // Vérification des résultats 

    });

    it('ServiceDeleteCategorieTestSpec', function () {

        var returnData = {};

        // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 

        httpBackend.expectDELETE("http://localhost:1949/api/Categorie/deleteCategorie/" + categorie1.id).respond(returnData);

        var returnedPromise = categoriesService.deleteCategorie(categorie1);

        httpBackend.whenGET('Home.html').respond(200, '');

        httpBackend.flush();  //Permet d'exécuter la requête expectGet 


    });


    it('ServiceAddCategorieTestSpec', function () {

        var returnData = {};
        var categorie3 = {
            id: 3,
            idPorteFeuille: 1,
            designation: 'Courses',
            descript: 'Courses'
        };


        // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 

        httpBackend.expectPOST("http://localhost:1949/api/Categorie/addCategorie" ,categorie3).respond(returnData);

        var returnedPromise = categoriesService.InsertCategorie(categorie3);

        httpBackend.whenGET('Home.html').respond(200, '');

        httpBackend.flush();  //Permet d'exécuter la requête expectGet 


    });


  /*  it('ServiceUpdateCategorieTestSpec', function () {

        var returnData = {};
        var categorieToUpdate = {
            id: 1,
            idPorteFeuille: 1,
            designation: 'Etudes',
            descript: 'Etudes'
        };


        // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 

        httpBackend.expect('PUT', "http://localhost:1949/api/Categorie/updateCategorie" + categorieToUpdate.id, categorieToUpdate).respond(returnData);

        var returnedPromise = categoriesService.ModifyCategorie(categorieToUpdate);

        httpBackend.whenGET('Home.html').respond(200, '');

        httpBackend.flush();  //Permet d'exécuter la requête expectGet 


    });*/





});
