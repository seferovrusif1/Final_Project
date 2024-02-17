using AutoMapper;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Exceptions.AppUser;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Implements
{
    public class AuthService:IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        IMapper _mapper { get; }

        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task CreateAsync(RegisterDTO dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                ///TODO: belke strbuilderi liste deyisdim
                StringBuilder sb = new();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new AppUserRegisterFailedException(sb.ToString().TrimEnd());
            }
        }

        public async Task Login(LoginDTO dto)
        {
            AppUser user;
            if (dto.UserNameOrEmail.Contains("@"))
            {
                user= await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            }
            if (user == null) throw new PasswordOrUserNameWrongException();
            var result =await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new PasswordOrUserNameWrongException();
        
        }
    }
}
