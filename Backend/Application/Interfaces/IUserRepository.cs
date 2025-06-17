using LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameOrEmailAsync(string username, string email);
        Task AddAsync(User user);

    }
}
