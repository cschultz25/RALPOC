using TaskList3.Abstractions;

namespace TaskList3.Models
{
    public class TodoItem : TableData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

        public string TagId { get; set; }
    }
}
