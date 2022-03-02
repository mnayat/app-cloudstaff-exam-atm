using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string FullName { get; set; }
        [Required]
        public long AccountNumber { get; set; }
        [Required]
        public long CardNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }

    }
}
