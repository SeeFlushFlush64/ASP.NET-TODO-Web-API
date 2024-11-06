using TODOWebAPI.DTO.TodoTask;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.DTO.TodoTaskFolder
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Navigation Property: One to many. One user, many tasks.
        public List<TodoTaskDTO>? Tasks { get; set; }
    }
}
