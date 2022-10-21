namespace ToDoListApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public DateTime? Timestamp { get; set; } = DateTime.Now;

        public string? Text { get; set; }
        public bool Done { get; set; }

        public override bool Equals(Object obj)
        {
            // Performs an equality check on two points (integer pairs).
            if (obj == null || GetType() != obj.GetType()) return false;
            ToDoItem toDoItem = (ToDoItem)obj;
            return this.Id==toDoItem.Id&&this.Timestamp==toDoItem.Timestamp&&this.Text==toDoItem.Text&&this.Done==toDoItem.Done;
        }
    }
}