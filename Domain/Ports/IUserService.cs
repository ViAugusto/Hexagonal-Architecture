using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Ports
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<IActionResult> UpdateUserAsync(User user);
        Task<IActionResult> DeleteUserAsync(Guid id);

    }
}
