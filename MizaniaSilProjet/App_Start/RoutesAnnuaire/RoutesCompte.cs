using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaSilProjet.App_Start.RoutesAnnuaire
{
    public class RoutesCompte
    {
        public static void addRoutesCompte(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
            name: "GetAllAccounts",
            routeTemplate: "api/Compte/getAll/",
            defaults: new
            {
                controller = "Compte",
                action = "getAllAccounts"
            }
         );

            config.Routes.MapHttpRoute(
            name: "GetTotalAccounts",
            routeTemplate: "api/Compte/getTotalAccounts/",
            defaults: new
            {
                controller = "Compte",
                action = "getTotalAccounts"
            }
         );

            config.Routes.MapHttpRoute(
               name: "GetAccount",
               routeTemplate: "api/Compte/getOneAccount/{id}",
               defaults: new
               {
                   controller = "Compte",
                   action = "getOneAccount"

               },
               constraints: new { id = @"\d+" }

            );

            config.Routes.MapHttpRoute(
                 name: "PostAccount",
                 routeTemplate: "api/Compte/addAccount",
                 defaults: new
                 {
                     controller = "Compte",
                     action = "addAccount"
                 }
              );

            config.Routes.MapHttpRoute(
                  name: "DeleteAccount",
                  routeTemplate: "api/Compte/deleteAccount/{id}",
                  defaults: new
                  {
                      controller = "Compte",
                      action = "deleteAccount",

                  },
                   constraints: new
                   {
                       id = @"\d+",
                   }
               );

            config.Routes.MapHttpRoute(
                 name: "PutAccount",
                 routeTemplate: "api/Compte/updateAccount/{id}",
                 defaults: new
                 {
                     controller = "Compte",
                     action = "updateAccount"
                 },
              constraints: new { id = @"\d+" }
              );


            config.Routes.MapHttpRoute(
                name: "PostUser2",
                routeTemplate: "api/Compte/addUserV",
                defaults: new
                {
                    controller = "Compte",
                    action = "addUserV"
                }
             );

        }

    }
}