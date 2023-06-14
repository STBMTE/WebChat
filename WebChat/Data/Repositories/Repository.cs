using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Models;

namespace WebChat.Data.Repositories;

public class Repository<T> : IRepository<T> where T: BaseModel
{
    private readonly ChatContext DbContext;

    protected Repository(ChatContext dbContext) => DbContext = dbContext;

    // /// <summary>
    // /// Проверяет существование сущности в БД
    // /// </summary>
    // /// <returns>Вернет true, если какой-то сущности нет в БД</returns>
    // public bool NotContainsEntities(params long[] args)
    // {
    //     foreach (var entityId in args)
    //     {
    //         if (GetById(entityId).Result is null)
    //             return true;
    //     }
    //
    //     return false;
    // }

    public DbSet<T> Set => DbContext.Set<T>();
    
    public async Task<T?> Add(T entity)
    {
        await DbContext.AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return await GetById(entity.Id);
    }

    public async Task<T?> Update(T entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();
        return await GetById(entity.Id);
    }

    public async Task<bool> Delete(long id)
    {
        var entity = await GetById(id);
        if (entity is null)
            return false;
        
        entity.IsDeleted = true;
        return Update(entity).IsCompletedSuccessfully;
        //return await GetById(entity.Id) is null;
    }

    public async Task<T?> GetById(long id)
    {
        return await Set.SingleOrDefaultAsync(entity => entity.Id == id && !entity.IsDeleted);
    }

    public IQueryable<T> GetAll()
    {
        return Set.AsNoTracking().Where(entity => !entity.IsDeleted);
    }
}