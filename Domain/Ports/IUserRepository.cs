

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Ports
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid id);
        Task<User> CreateUser(User user);
        Task<IActionResult> UpdateUser(User user);
        Task<IActionResult> DeleteUser(Guid id);
    }
}
