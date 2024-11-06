using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Interfaces
{
    public interface ITodoTaskRepository
    {
        Task<List<TodoTask>?> GetAllAsync();
        Task<List<TodoTask>?> GetByIdAsync(Guid id);
        Task<TodoTask> CreateAsync(TodoTask todoTaskModel);
    }
}
