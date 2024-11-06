using Microsoft.EntityFrameworkCore;
using TODOWebAPI.Data;
using TODOWebAPI.Interfaces;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TodoTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoTask> CreateAsync(TodoTask todoTaskModel)
        {
            await _context.Tasks.AddAsync(todoTaskModel);
            await _context.SaveChangesAsync();
            return todoTaskModel;
        }

        public async Task<List<TodoTask>?> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            if (tasks == null)
            {
                return null;
            }
            return tasks;
        }

        public async Task<List<TodoTask>?> GetByIdAsync(Guid id)
        {
            var task = await _context.Tasks.Where(t => t.UserId == id).ToListAsync();
            if (task == null)
            { 
                return null;
            }
            return task;
        }
    }
}
