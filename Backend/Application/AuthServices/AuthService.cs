using Library.Application.DTO;
using Library.Application.Interfaces;
using LibrarySystem;
using Library.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;




namespace LibrarySystem.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<User> RegisterUserAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByUsernameOrEmailAsync(dto.Username, dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Username or email is already in use");
            }

            var hashedPassword = _passwordHasher.HashPassword(dto.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddAsync(newUser);

            return newUser;
        }

        public async Task<AuthResponseDto> LoginUserAsync(LoginUserDto dto)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(dto.UsernameOrEmail, dto.UsernameOrEmail);
            if (user == null)
                throw new Exception("User not found");

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, dto.Password))
                throw new Exception("Invalid password");

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
