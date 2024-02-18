using JobSearch.Business.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenDTO> Login(LoginDTO dto);
        public Task CreateAsync(RegisterDTO dto);

    }
}
