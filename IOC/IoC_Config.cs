using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaData.GenericRepository;
using MizaniaData.IGenericRepository;
using MizaniaData.Data;
using MizaniaServices; 

namespace IOC
{
    public class IoC_Config
    {
        static IoC_Config()
        {
            Configure();
        }

        public static void Configure()
        {
            Container = new UnityContainer();
            Container.RegisterType<IGenericRepository<Utilisateur>, GenericRepository<Utilisateur>>();
            Container.RegisterType<IGenericRepository<Compte>, GenericRepository<Compte>>();
            Container.RegisterType<IGenericRepository<Categorie>, GenericRepository<Categorie>>();
            Container.RegisterType<IGenericRepository<Transactions>, GenericRepository<Transactions>>();
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<ICompteService, CompteService>();
            Container.RegisterType<ICategorieService, CategorieService>();
            Container.RegisterType<ITransactionService, TransactionService>();
        }

        public static IUnityContainer Container { get; private set; }

    
    }
}