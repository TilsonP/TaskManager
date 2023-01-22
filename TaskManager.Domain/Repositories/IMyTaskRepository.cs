using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories;

public interface IMyTaskRepository
{
    Task Register(MyTask myTask);
    Task<IEnumerable<MyTask>> Find();
    Task Delete(string name);
    Task<IEnumerable<MyTask>> FindByDate(DateTime date);
}