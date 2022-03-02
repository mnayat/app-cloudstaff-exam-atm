using ATMAPI.Data;
using ATMAPI.Models;
using ATMAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public User Authenticate(string username, string password)
        {
            var user = _db.User.SingleOrDefault(a => a.Username == username && a.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
