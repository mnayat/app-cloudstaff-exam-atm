using ATMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Repository.IRepository
{
   public interface IBankAccountRepository
    {
        BankAccount GetBankAccountDetails(long AccountNumber);
        bool UpdateBankAccountCurrentBalance(BankAccount bankAccount);

    }
}
;