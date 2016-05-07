using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaSilProjet.App_Start.RoutesAnnuaire
{
    public class RoutesUtilisateur
    {
        public static void addRoutesUtilisateur(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
             name: "GetAllUsers",
             routeTemplate: "api/User/getAll/",
             defaults: new
             {
                 controller = "User",
                 action = "getAllUsers"
             }
          );

            config.Routes.MapHttpRoute(
               name: "GetUser",
               routeTemplate: "api/User/getOneUser/{id}",
               defaults: new
               {
                   controller = "User",
                   action = "getOneUser"

               },
               constraints: new { id = @"\d+" }

            );

            config.Routes.MapHttpRoute(
                 name: "PostUser",
                 routeTemplate: "api/User/addUser",
                 defaults: new
                 {
                     controller = "User",
                     action = "addUser"
                 }
              );

            config.Routes.MapHttpRoute(
                  name: "DeleteUser",
                  routeTemplate: "api/User/deleteUser/{id}",
                  defaults: new
                  {
                      controller = "User",
                      action = "deleteUser",

                  },
                   constraints: new
                   {
                       id = @"\d+",
                   }
               );

            config.Routes.MapHttpRoute(
                 name: "PutUser",
                 routeTemplate: "api/User/updateUser/{id}",
                 defaults: new
                 {
                     controller = "User",
                     action = "updateUser"
                 },
              constraints: new { id = @"\d+" }
              );

            config.Routes.MapHttpRoute(
              name: "GetUserByNom",
              routeTemplate: "api/User/getUserByNom/{name}",
              defaults: new
              {
                  controller = "User",
                  action = "getUserByNom"
              }
           );

            config.Routes.MapHttpRoute(
             name: "GetUserByPrenom",
             routeTemplate: "api/User/getUserByPrenom/{prenom}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserByPrenom"
             }
          );


            config.Routes.MapHttpRoute(
             name: "GetUserPortefeuille",
             routeTemplate: "api/User/getUserPortefeuille/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserPortefeuille",

             },
               constraints: new { id = @"\d+" }
          );

            config.Routes.MapHttpRoute(
             name: "GetUserAccounts",
             routeTemplate: "api/User/getUserAccounts/{id}",
             defaults: new
             {
                 controller = "User",
                 action = "getUserAccounts"

             },
               constraints: new { id = @"\d+" }
          );

        }

    }
}