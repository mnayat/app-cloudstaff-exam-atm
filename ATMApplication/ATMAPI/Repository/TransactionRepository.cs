using ATMAPI.Data;
using ATMAPI.Models;
using ATMAPI.Repository.IRepository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ATMAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _db;
        public TransactionRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public bool SaveTransactionDetails(Transaction transactionDetails)
        {
            _db.Transaction.Add(transactionDetails);
            return Save();
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public ICollection<Transaction> GetTransactionHistory()
        {
            return _db.Transaction.OrderByDescending(a => a.TransactionDate).ToList();
        }

    }
}
