using Library.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem;

namespace Library.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterUserAsync(RegisterUserDto userDto);
    }
}
