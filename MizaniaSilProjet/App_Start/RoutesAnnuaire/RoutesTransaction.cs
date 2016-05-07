﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MizaniaSilProjet.App_Start.RoutesAnnuaire
{
    public class RoutesTransaction
    {
        public static void addRoutesTransactions(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
             name: "GetAllTransactions",
             routeTemplate: "api/Transaction/getAll/",
             defaults: new
             {
                 controller = "Transaction",
                 action = "getAllTransactions"
             }
          );

            config.Routes.MapHttpRoute(
              name: "GetAllTransactionsEntrees",
              routeTemplate: "api/Transaction/getTransactEntrees/",
              defaults: new
              {
                  controller = "Transaction",
                  action = "getAllTransactionsEntrees"
              }
           );

            config.Routes.MapHttpRoute(
              name: "GetAllTransactionsDepenses",
              routeTemplate: "api/Transaction/getTransactDepenses/",
              defaults: new
              {
                  controller = "Transaction",
                  action = "getAllTransactionsDepenses"
              }
           );

            config.Routes.MapHttpRoute(
                name: "GetTransaction",
                routeTemplate: "api/Transaction/getOneTransaction/{id}/{idCompte}",
                defaults: new
                {
                    controller = "Transaction",
                    action = "getOneTransaction"
                },
                constraints: new { id = @"\d+", idCompte = @"\d+" }

            );

            config.Routes.MapHttpRoute(
                name: "PostTransaction",
                routeTemplate: "api/Transaction/addTransaction",
                defaults: new
                {
                    controller = "Transaction",
                    action = "addTransaction"
                }
             );


            config.Routes.MapHttpRoute(
                  name: "DeleteTransaction",
                  routeTemplate: "api/Transaction/deleteTransaction/{id}/{idCompte}",
                  defaults: new
                  {
                      controller = "Transaction",
                      action = "deleteTransaction",

                  },
                   constraints: new
                   {
                       id = @"\d+",
                       idCompte = @"\d+",
                   }
               );

            config.Routes.MapHttpRoute(
                 name: "PutTransaction",
                 routeTemplate: "api/Transaction/updateTransaction/{id}/{idCompte}",
                 defaults: new
                 {
                     controller = "Transaction",
                     action = "updateTransaction"
                 },
              constraints: new
              {
                  id = @"\d+",
                  idCompte = @"\d+",
              }
              );
        }
    }
}