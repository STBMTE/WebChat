using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class UserRepository: Repository<User>
{
    public UserRepository(ChatContext dbContext) : base(dbContext) { }
        
    public async ValueTask<User?> GetUser(long id) => await GetById(id);
    
    public async ValueTask<IReadOnlyCollection<User>> GetUsers()
    {
        return await GetAll()
            .ToListAsync(); 
    }

    public async ValueTask<User?> AddUser(User user) => await Add(user);
    public async ValueTask<User?> UpdateUser(User user) => await Update(user);

    public async ValueTask<bool> DeleteUser(long id) => await Delete(id);
}