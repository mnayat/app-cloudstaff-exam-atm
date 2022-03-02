using ATMAPI.Models;
using System.Collections.Generic;

namespace ATMAPI.Repository.IRepository
{
    public interface ITransactionRepository
    {
        bool SaveTransactionDetails(Transaction transactionDetails);
        ICollection<Transaction> GetTransactionHistory();
  

    }
}
