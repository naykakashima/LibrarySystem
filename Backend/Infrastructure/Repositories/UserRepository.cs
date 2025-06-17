using Library.Application.Interfaces;
#nullable enable

using LibrarySystem;
using LibrarySystem.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;
        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByUsernameOrEmailAsync(string username, string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower() || u.Email.ToLower() == email.ToLower());
        }
        public async Task AddAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
