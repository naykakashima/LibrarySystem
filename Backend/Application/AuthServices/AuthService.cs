using Library.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interfaces;


namespace LibrarySystem.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
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
    }
}
