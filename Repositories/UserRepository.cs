using Microsoft.EntityFrameworkCore;
using TODOWebAPI.Data;
using TODOWebAPI.DTO.User;
using TODOWebAPI.DTO.UserFolderDTO;
using TODOWebAPI.Interfaces;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var deleteEmployee = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (deleteEmployee == null)
            {
                return null;    
            }
            _context.Users.Remove(deleteEmployee);
            await _context.SaveChangesAsync();
            return deleteEmployee;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.Include(u => u.Tasks).ToListAsync(); 
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.Include(u => u.Tasks).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            { 
                return null;
            }
            return user;
        }

        public async Task<User?> UpdateUserAsync(Guid id, UpdateUserDTO updateDTO)
        {
            var updateEmployee = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (updateEmployee == null)
            {
                return null;
            }
            updateEmployee.Name = updateDTO.Name;
            updateEmployee.Email = updateDTO.Email;
            updateEmployee.Password = updateDTO.Password;
            await _context.SaveChangesAsync();
            return updateEmployee;

        }

        public async Task<bool> UserExists(Guid id)
        {
            var user = await _context.Users.AnyAsync(u => u.UserId == id);
            return user;
        }
    }
}
