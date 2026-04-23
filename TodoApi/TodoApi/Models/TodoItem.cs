namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }   
        public string? content { get; set; }
        public bool isComplete { get; set; }

    }
}
