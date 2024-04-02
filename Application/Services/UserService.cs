using Domain.Entities;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var userCreated = await _userRepository.CreateUser(user);
            return userCreated;
        }

        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetUser(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsers();
            return users;
        }

        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}
