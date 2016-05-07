using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http; 

namespace MizaniaSilProjet.App_Start.RoutesAnnuaire
{
    public class RoutesCategorie
    {
        public static void addRoutesCategories(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
              name: "GetAllCategories",
              routeTemplate: "api/Categorie/getAll/",
              defaults: new
              {
                  controller = "Categorie",
                  action = "getAllCategories"
              }
           );

            config.Routes.MapHttpRoute(
               name: "GetCategorie",
               routeTemplate: "api/Categorie/getOneCategorie/{id}",
               defaults: new
               {
                   controller = "Categorie",
                   action = "getOneCategorie"

               },
               constraints: new { id = @"\d+" }

            );

            config.Routes.MapHttpRoute(
                 name: "PostCategorie",
                 routeTemplate: "api/Categorie/addCategorie",
                 defaults: new
                 {
                     controller = "Categorie",
                     action = "addCategorie"
                 }
              );

            config.Routes.MapHttpRoute(
                  name: "DeleteCategorie",
                  routeTemplate: "api/Categorie/deleteCategorie/{id}",
                  defaults: new
                  {
                      controller = "Categorie",
                      action = "deleteCategorie",

                  },
                   constraints: new
                   {
                       id = @"\d+",
                   }
               );

            config.Routes.MapHttpRoute(
                 name: "PutCategorie",
                 routeTemplate: "api/Categorie/updateCategorie/{id}",
                 defaults: new
                 {
                     controller = "Categorie",
                     action = "updateCategorie"
                 },
              constraints: new { id = @"\d+" }
              );
        }

    }
}