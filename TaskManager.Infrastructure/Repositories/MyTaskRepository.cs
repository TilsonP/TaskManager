using LiteDB.Async;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Infrastructure.Repositories;

public class MyMyTaskRepository : IMyTaskRepository
{
    private readonly ILiteCollectionAsync<MyTask> _collection;

    public MyMyTaskRepository(ILiteCollectionAsync<MyTask> collection)
    {
        _collection = collection;
    }

    public async Task Register(MyTask myTask)
    {
        await _collection.InsertAsync(myTask);
    }

    public async Task<IEnumerable<MyTask>> Find()
    {
        return await _collection.FindAllAsync();
    }
}