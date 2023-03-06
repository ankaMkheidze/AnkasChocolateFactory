﻿using AnkasChocolateFactory.Contracts;
using AnkasChocolateFactory.Data;
using AnkasChocolateFactory.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AnkasChocolateFactory.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration) {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

           if(user == null || isValidUser == false)
            {
                return null;
            }

            var token = await GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id
            };
            
            

        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");  
            }

            return result.Errors;
            
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var cridentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            //Es imitoa sachro ro ar deb dbshi claims
          
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims  = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>
            {
                //Stuff that should be here by default
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer : _configuration["JwtSettings: Issuer"],
                audience : _configuration["JwtSettings: Audience"],
                claims : claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings: DurationInMinutes"])),
                signingCredentials : cridentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}