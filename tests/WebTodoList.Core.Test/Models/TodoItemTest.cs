using System;
using WebTodoList.Core.Models;
using Xunit;

namespace WebTodoList.Core.Test.Models
{
    public class TodoItemTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void NewTodo_Should_Throw_ArgumentException_If_Text_Is_Empty(string value)
        {
            string text = value;
            var ex = Assert.Throws<ArgumentException>(() => TodoItem.NewTodo(text));

            Assert.Equal(nameof(text), ex.ParamName);
        }

        [Fact]
        public void NewTodo_Should_Create_A_New_Todo_Item_With_Specified_Text()
        {
            string text = "my todo";
            var todo = TodoItem.NewTodo(text);

            Assert.NotEqual(Guid.Empty, todo.Id);
            Assert.Equal(text, todo.Text);
        }

        [Fact]
        public void MarkAsDone_Should_Set_IsDone_To_True_And_DoneAt_Date()
        {
            string text = "my todo";
            var todo = TodoItem.NewTodo(text);

            todo.MarkAsDone();

            Assert.True(todo.IsDone);
            Assert.NotNull(todo.DoneAt);
        }

        [Fact]
        public void Delete_Should_Set_IsDeleted_To_True_And_DeletedAt_Date()
        {
            string text = "my todo";
            var todo = TodoItem.NewTodo(text);

            todo.Delete();

            Assert.True(todo.IsDeleted);
            Assert.NotNull(todo.DeletedAt);
        }
    }
}
