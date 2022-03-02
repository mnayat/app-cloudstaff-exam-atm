using ATMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
