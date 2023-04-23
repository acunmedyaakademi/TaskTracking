namespace TaskTracking.Models
{
    public class TaskListModel
    {
        public List<Tasks> Tasks { get; set; }
        public List<TaskList> TaskList { get; set; }
        public List<Users> Users { get; set; }
    
        public List<Comment> Comment { get; set; }
    }
}
