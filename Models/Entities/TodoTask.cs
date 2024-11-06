using System.ComponentModel.DataAnnotations;

namespace TODOWebAPI.Models.Entities
{
    public class TodoTask
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        //Foreign Key
        public Guid UserId { get; set; }
        //Navigation Property: Many to One. Many tasks, one user.
        public User User { get; set; }
    }
}
