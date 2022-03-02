using ATMAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ATMAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<User> User { get; set; }
    }
}
