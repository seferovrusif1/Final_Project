using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Exceptions.AppUser
{
    public class PasswordOrUserNameWrongException : Exception
    {
        public PasswordOrUserNameWrongException():base("UserName Or Password is wrong")
        {
        }

        public PasswordOrUserNameWrongException(string? message) : base(message)
        {
        }
    }
}
