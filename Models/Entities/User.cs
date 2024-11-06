namespace TODOWebAPI.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Navigation Property: One to many. One user, many tasks.
        public List<TodoTask>? Tasks { get; set; } = new List<TodoTask>();
    }
}
