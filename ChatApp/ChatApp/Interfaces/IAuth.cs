using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
