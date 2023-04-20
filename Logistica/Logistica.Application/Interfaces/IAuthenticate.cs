using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string firstName, string lastName, 
            string email, string password);
        Task Logout();
    }
}
