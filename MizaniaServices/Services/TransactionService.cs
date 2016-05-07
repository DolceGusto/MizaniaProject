using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaData.IGenericRepository;
using MizaniaData.Data;
using System.Transactions; 



namespace MizaniaServices
{
    public class TransactionService : ITransactionService
    {

        private IGenericRepository<Transactions> _transactionRepository;
        private IGenericRepository<Compte> _compteRepository;

        private const string DEPENSE = "DEPENSE";
        private const string ENTREE = "ENTREE";

       public TransactionService(IGenericRepository<Transactions> transactionRepository, IGenericRepository<Compte> compteRepository)
       {
           this._transactionRepository = transactionRepository;
           this._compteRepository = compteRepository; 
       }

       public bool CreateTransaction(Transactions transaction)
       {
           using (var scope = new TransactionScope())
           {
               if (_transactionRepository.Insert(transaction))
               {

                   Compte ancienCompte = _compteRepository.GetByID(transaction.idCompte);
                   Compte nouveauCompte = new Compte();
                   nouveauCompte.id = ancienCompte.id;
                   nouveauCompte.idUtilisateur = ancienCompte.idUtilisateur;
                   nouveauCompte.designation = ancienCompte.designation;
                   nouveauCompte.descript = ancienCompte.descript;
                   if (transaction.typeTransact.ToUpper().Equals(DEPENSE))
                   {
                       nouveauCompte.solde = ancienCompte.solde - transaction.montant;
                   }
                   else if (transaction.typeTransact.ToUpper().Equals(ENTREE))
                   {
                       nouveauCompte.solde = ancienCompte.solde + transaction.montant;
                   }
                   else return false;
                   _compteRepository.Detach(ancienCompte);
                   if (_compteRepository.Update(nouveauCompte))
                   {  
                       scope.Complete(); 
                        return true;
                   }
                   else return false;
               }
               return false; 
    
               
           }
          
    
       }
    
       public IEnumerable<Transactions> GetAllTransactions()
       {
           return _transactionRepository.GetAll();
       }

       public Transactions GetTransactionById(int TransactionId, int idCompte)
       {
           return _transactionRepository.GetByID(TransactionId,idCompte);
       }

       public IEnumerable<Transactions> FindTransactionsEntree()
       {
          return _transactionRepository.FindBy(d => d.typeTransact.ToUpper().Equals(ENTREE)).ToList(); 
       }

       public IEnumerable<Transactions> FindTransactionsDepense()
       {
           return _transactionRepository.FindBy(d => d.typeTransact.ToUpper().Equals(DEPENSE)).ToList();
       }



       public bool DeleteTransaction(int id, int idCompte)
       {
           using (var scope = new TransactionScope())
           {
               Transactions transaction = _transactionRepository.GetByID(id, idCompte);
               if (_transactionRepository.Delete(id, idCompte))
               {
                   Compte ancienCompte = _compteRepository.GetByID(transaction.idCompte);
                   Compte nouveauCompte = new Compte();
                   nouveauCompte.id = ancienCompte.id;
                   nouveauCompte.idUtilisateur = ancienCompte.idUtilisateur;
                   nouveauCompte.designation = ancienCompte.designation;
                   nouveauCompte.descript = ancienCompte.descript;
                   if (transaction.typeTransact.ToUpper().Equals(DEPENSE))
                   {
                       nouveauCompte.solde = ancienCompte.solde + transaction.montant;
                   }
                   else if (transaction.typeTransact.ToUpper().Equals(ENTREE))
                   {
                       nouveauCompte.solde = ancienCompte.solde - transaction.montant;
                   }
                   else return false;
                   _compteRepository.Detach(ancienCompte);
                   if (_compteRepository.Update(nouveauCompte))
                   {
                       scope.Complete();
                       return true;
                   }
                   else return false;

               }
               return false;
           }
    
       }
        

       public bool UpdateTransaction(Transactions transaction)
       {
           using (var scope = new TransactionScope())
           {
               Compte ancienCompte = _compteRepository.GetByID(transaction.idCompte);
               Compte nouveauCompte = new Compte();
               nouveauCompte.id = ancienCompte.id;
               nouveauCompte.idUtilisateur = ancienCompte.idUtilisateur;
               nouveauCompte.designation = ancienCompte.designation;
               nouveauCompte.descript = ancienCompte.descript;


               Transactions ancienneTransaction = _transactionRepository.GetByID(transaction.id, transaction.idCompte);
               if (ancienneTransaction.typeTransact.ToUpper().Equals(DEPENSE))
               {
                   nouveauCompte.solde = ancienCompte.solde + ancienneTransaction.montant;
               }
               else if (ancienneTransaction.typeTransact.ToUpper().Equals(ENTREE))
               {
                   nouveauCompte.solde = ancienCompte.solde - ancienneTransaction.montant;
               }

               if (ancienneTransaction.typeTransact.Equals(transaction.typeTransact))
               {
                   _transactionRepository.Detach(ancienneTransaction);
                   if (_transactionRepository.Update(transaction))
                   {

                       if (transaction.typeTransact.ToUpper().Equals(DEPENSE))
                       {
                           nouveauCompte.solde -= transaction.montant;
                       }
                       else if (transaction.typeTransact.ToUpper().Equals(ENTREE))
                       {
                           nouveauCompte.solde += transaction.montant;
                       }
                       else return false;
                       _compteRepository.Detach(ancienCompte);
                       if (_compteRepository.Update(nouveauCompte))
                       {
                           scope.Complete();
                           return true;
                       }
                       else return false;
                   }
               }
               return false;
           }
       } 

     
       
    }

}