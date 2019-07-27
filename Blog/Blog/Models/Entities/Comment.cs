using System;

namespace Blog.Models.Entities
{
    public class Comment
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
