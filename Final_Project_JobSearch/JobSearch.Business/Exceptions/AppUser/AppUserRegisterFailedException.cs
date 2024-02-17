using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Exceptions.AppUser
{
    public class AppUserRegisterFailedException : Exception
    {
        public AppUserRegisterFailedException():base("Registration failed")
        {
        }

        public AppUserRegisterFailedException(string? message) : base(message)
        {
        }
    }
}
