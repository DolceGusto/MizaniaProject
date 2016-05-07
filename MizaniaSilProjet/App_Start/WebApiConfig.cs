using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MizaniaSilProjet.App_Start.RoutesAnnuaire; 

namespace MizaniaSilProjet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

           
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            RoutesUtilisateur.addRoutesUtilisateur(config); 
            RoutesCompte.addRoutesCompte(config); 
            RoutesCategorie.addRoutesCategories(config);
            RoutesTransaction.addRoutesTransactions(config);
           

        }
    }
}
