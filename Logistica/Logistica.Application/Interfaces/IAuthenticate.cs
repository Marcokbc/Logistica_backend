using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string usernamE, string password);
        Task<bool> RegisterUser(string username, 
            string email, string password);
        Task Logout();
    }
}
