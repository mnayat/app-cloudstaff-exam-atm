
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ATMAPI.Models.Transaction;

namespace ATMAPI.Models.DTOs
{
    public class TransactionDTO
    {
       
        public int Id { get; set; }
        [Required]
        public long BankAccountNoFrom { get; set; }
        [Required]
        public long BankAccountNoTo { get; set; }
        public TransactionType TransactionTypes { get; set; }
        [Required]
        public decimal TransactionAmount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
