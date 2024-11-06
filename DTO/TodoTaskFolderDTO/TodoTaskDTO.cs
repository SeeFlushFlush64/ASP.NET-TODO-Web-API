using System.ComponentModel.DataAnnotations;

namespace TODOWebAPI.DTO.TodoTask
{
    public class TodoTaskDTO
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        //Foreign Key
        public Guid? UserId { get; set; }
    }
}
