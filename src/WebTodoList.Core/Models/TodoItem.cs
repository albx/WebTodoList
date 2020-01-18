using System;

namespace WebTodoList.Core.Models
{
    public class TodoItem
    {
        public Guid Id { get; protected set; }

        public string Text { get; protected set; }

        public bool IsDone { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public DateTime? DoneAt { get; protected set; }

        public DateTime? DeletedAt { get; protected set; }

        public void MarkAsDone()
        {
            this.IsDone = true;
            this.DoneAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeletedAt = DateTime.UtcNow;
        }

        public static TodoItem NewTodo(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("value cannot be null", nameof(text));
            }

            var todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Text = text
            };

            return todo;
        }
    }
}
