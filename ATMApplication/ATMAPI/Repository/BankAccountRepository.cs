using ATMAPI.Data;
using ATMAPI.Models;
using ATMAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDBContext _db;
        public BankAccountRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public BankAccount GetBankAccountDetails(long accountNumber)
        {
            return _db.BankAccount.FirstOrDefault(b => b.AccountNumber == accountNumber);
        }
        public  bool UpdateBankAccountCurrentBalance(BankAccount bankAccount)
        {
           
            _db.BankAccount.Update(bankAccount);
            return Save();
        }
         public  bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
