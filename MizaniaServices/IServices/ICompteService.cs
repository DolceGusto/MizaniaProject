using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaData.IGenericRepository;
using MizaniaData.Data; 


namespace MizaniaServices
{
    public interface ICompteService
    {
        Compte GetAccountById(int AccountId);
        IEnumerable<Compte> GetAllAccounts();
        bool AddAccount(Compte compte);
        bool DeleteAccount(int id);
        bool UpdateAccount(Compte compte);
        IEnumerable<Compte> FindAccountsByUserID(int id);
        bool CreerUtilisateur(Utilisateur user, Compte compte);
        double totalPortefeuille(); 
       
    }
}
