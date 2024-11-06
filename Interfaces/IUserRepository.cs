using TODOWebAPI.DTO.User;
using TODOWebAPI.DTO.UserFolderDTO;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> CreateUserAsync(User user);
        Task<User?> DeleteUserAsync(Guid id);
        Task<User?> UpdateUserAsync(Guid id, UpdateUserDTO updateDTO);
        Task<bool> UserExists(Guid id);
    }
}
