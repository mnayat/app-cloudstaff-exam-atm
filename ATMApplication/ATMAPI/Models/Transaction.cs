
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long BankAccountNoFrom { get; set; }
        [Required]
        public long BankAccountNoTo { get; set; }

        public enum TransactionType { Deposit, Withdrawal };

        public  TransactionType TransactionTypes { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
