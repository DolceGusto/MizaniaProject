using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaData.IGenericRepository;
using MizaniaData.Data;
using System.Transactions; 


namespace MizaniaServices
{
    public class CompteService: ICompteService
    {
        private IGenericRepository<Utilisateur> _userRepository;
        private IGenericRepository<Compte> _compteRepository;
        private IGenericRepository<Transactions> _transactionRepository;

        public CompteService(IGenericRepository<Utilisateur> userRepository, IGenericRepository<Compte> compteRepository, IGenericRepository<Transactions> transactionRepository)
        {
            this._userRepository = userRepository;
            this._compteRepository = compteRepository;
            this._transactionRepository = transactionRepository;
        }


       public bool CreerUtilisateur(Utilisateur user, Compte compte)
       {
           if (_userRepository.Insert(user) && _compteRepository.Insert(compte))
               return true;
           else return false;
       }

       public IEnumerable<Compte> GetAllAccounts()
       {
           return _compteRepository.GetAll();
       }

       public Compte GetAccountById(int AccountId)
       {
           return _compteRepository.GetByID(AccountId);
       }
        
       public bool AddAccount(Compte compte)
       {
           if (_compteRepository.Insert(compte))
               return true;
           else return false;
       }


       public bool DeleteAccount(int id)
       {
           using (var scope = new TransactionScope())
           {
               List<Transactions> transactionsDuCompte = _transactionRepository.FindBy(d => d.idCompte == id).ToList();
               if (transactionsDuCompte.Count() != 0)
               {
                   foreach (Transactions t in transactionsDuCompte)
                   {
                       _transactionRepository.Delete(t.id, t.idCompte);
                   }
               }

               if (_compteRepository.Delete(id))
               {
                   {
                       scope.Complete();
                       return true;
                   }
               }
               else return false;
           }
          

       }
        
        

       public bool UpdateAccount(Compte compte)
       {
           if (_compteRepository.Update(compte))
               return true;
           else return false; 
       }

       public IEnumerable<Compte> FindAccountsByUserID(int id)
       {
           return _compteRepository.FindBy(d => d.idUtilisateur ==id);
       }

       public double totalPortefeuille()
       {
           double montant=0;
           IEnumerable<Compte> listeDesComptes = GetAllAccounts();
           foreach (Compte account in listeDesComptes)
           {
               montant += account.solde; 
           }

           return montant; 
       }

       
       
    }
}