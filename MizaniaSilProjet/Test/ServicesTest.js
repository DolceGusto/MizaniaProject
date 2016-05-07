// Avec describe on définit ce qu'on doit tester ! dans notre cas c'est un service angular 
describe('accountsService', function () {
    var accountsService, httpBackend;
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

    beforeEach(function () { //Avant d'exécuter n'importe quel test spec, on exécute d'abord le code qui va suivre 
       
        module('MizaniaProjectModule'); //A savoir : Charger le module se trouvant dans App.js 
         
        // Obtenir l'objet du test en question (service dans notre cas) 
        // $httpBackend c'est un mock, il permet d'implémenter un fake http afin qu'on puisse faire les tests angulars des services par la suite.
        inject(function ($httpBackend, _accountsService_) { 
            accountsService = _accountsService_;
            httpBackend = $httpBackend;
        });
    });
 
    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
        httpBackend.verifyNoOutstandingRequest();
    });

// Définir la spécification de test
it('ServiceSingleAccountTestSpec', function () {

    var returnData = {};

    // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 
    httpBackend.expectGET("http://localhost:1949/api/Compte/getOneAccount/7").respond(returnData);

   
    // Appeler la fonction singleAccount(id) du service accountsService
    var returnedPromise = accountsService.singleAccount(7);

    //Result contiendra le résultat obtenu lors de l'appel de la fonction du service
    var result;
    returnedPromise.then(function (response) {
        result = response;
    });

    httpBackend.whenGET('Home.html').respond(200, '');

    httpBackend.flush();  //Permet d'exécuter la requête expectGet 

    expect(result).toEqual(returnData); // Vérification des résultats 

});

it('ServiceAccountsTestSpec', function () {

    var returnData = {};

    // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 
    httpBackend.expectGET("http://localhost:1949/api/Compte/getAll/").respond(returnData);

    var returnedPromise = accountsService.Accounts();

    //Result contiendra le résultat obtenu lors de l'appel de la fonction du service
    var result;
    returnedPromise.then(function (response) {
        result = response;
    });

    httpBackend.whenGET('Home.html').respond(200, '');

    httpBackend.flush();  //Permet d'exécuter la requête expectGet 

    expect(result).toEqual(returnData); // Vérification des résultats 

});

it('ServiceDeleteAccountTestSpec', function () {

    var returnData = {};

    // Définir expectGet sur le fake httpBackend qui fait un appel du service voulu en utilisant l'url 
  
    httpBackend.expectDELETE("http://localhost:1949/api/Compte/deleteAccount/"+account1.id).respond(returnData);
    
    var returnedPromise = accountsService.deleteAccount(account1);

    httpBackend.whenGET('Home.html').respond(200, '');

    httpBackend.flush();  //Permet d'exécuter la requête expectGet 


});





});
