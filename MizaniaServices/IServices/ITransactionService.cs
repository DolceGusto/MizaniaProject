using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaData.IGenericRepository;
using MizaniaData.Data; 

namespace MizaniaServices
{
    public interface ITransactionService
    {
        Transactions GetTransactionById(int TransactionId, int idCompte);

        IEnumerable<Transactions> GetAllTransactions();
       
        bool DeleteTransaction(int id, int idCompte);
        bool UpdateTransaction(Transactions transaction);
        bool CreateTransaction(Transactions transaction);
        IEnumerable<Transactions> FindTransactionsEntree();
        IEnumerable<Transactions> FindTransactionsDepense();
        double totalDepenses();
        double totalRevenus();
        string nomCatgorieTransaction(int idTransaction,int idCompte); 
    }
}
