namespace ToDoListApi.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }

        public DateTime? Timestamp { get; set; }

        public string? Text { get; set; }
        public bool Done { get; set; }
    }
}