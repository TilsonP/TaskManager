using LiteDB.Async;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Infrastructure.Repositories;

public class MyTaskRepository : IMyTaskRepository
{
    private readonly ILiteCollectionAsync<MyTask> _collection;

    public MyTaskRepository(ILiteDatabaseAsync liteDatabaseAsync)
    {
        _collection = liteDatabaseAsync.GetCollection<MyTask>("Tasks");
    }

    public async Task Register(MyTask myTask)
    {
        await _collection.InsertAsync(myTask);
    }

    public async Task<IEnumerable<MyTask>> Find()
    {
        return await _collection.FindAllAsync();
    }

    public async Task Delete(string name)
    {
        await _collection.DeleteManyAsync(task => task.Title == name);
    }

    public async Task<IEnumerable<MyTask>> FindByDate(DateTime date)
    {
        return await _collection.FindAsync(task => task.Date == date);
    }
}