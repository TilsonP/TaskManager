using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories;

public interface ITaskRepository
{
    Task Register(MyTask myTask);
    Task<List<MyTask>> Find();
}