using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;

namespace WebChat.Server.Services;

public class UserService : IService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<User>> GetAllUser()
    {
        return await _userRepository.GetUsers();
    }

    public async Task<User?> GetUserById(long userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task<User?> CreateUser(User user)
    {
        return _userRepository.GetUser(user.Id).Result is null ? await _userRepository.AddUser(user) : null;
    }
    
    public async Task<User?> UpdateUser(User user)
    {
        return await _userRepository.UpdateUser(user);
    }
    
    public async Task<bool> DeleteUser(long userId)
    {
        return await _userRepository.DeleteUser(userId);
    }

}