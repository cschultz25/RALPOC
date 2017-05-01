using TaskList2.Abstractions;

namespace TaskList2.Models
{
    public class TodoItem : TableData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}