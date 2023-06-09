﻿namespace TaskTracking.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public bool state { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Users_id { get; set; }
        public int Assigning_the_job { get; set; }
        public DateTime Create_on { get; set; }
        public DateTime Update_on { get; set; }
        public DateTime End_on { get; set; }

        public  int id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
    }
    public class TaskList
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public bool state { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Users_id { get; set; }
        public int Assigning_the_job { get; set; }
        public DateTime Create_on { get; set; }
        public DateTime Update_on { get; set; }
        public DateTime End_on { get; set; }

        public int id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
    }
    public class DetayList
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Create_on { get; set; }
        public List<detayCommentItem> CommentItems { get; set; }
        public List<Tasks> taskItem { get; set; }
        public List<detayUpdate> detayUpdate { get; set; }

    }
}
