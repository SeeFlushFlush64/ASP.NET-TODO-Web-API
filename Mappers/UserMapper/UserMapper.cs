using TODOWebAPI.DTO.TodoTask;
using TODOWebAPI.DTO.TodoTaskFolder;
using TODOWebAPI.DTO.User;
using TODOWebAPI.Mappers.TodoTaskMapper;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Mappers.UserMapper
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this User userModel)
        {
            return new UserDTO
            { 
                UserId = userModel.UserId,
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Tasks = userModel.Tasks?.Select(t => t.ToTodoTaskDTO()).ToList() ?? new List<TodoTaskDTO>()
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserDTO userModel)
        {
            return new User
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password
            };
        }
    }
}
