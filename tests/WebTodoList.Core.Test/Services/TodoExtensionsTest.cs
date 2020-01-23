using System;
using System.Linq;
using WebTodoList.Core.Models;
using WebTodoList.Core.Services;
using Xunit;

namespace WebTodoList.Core.Test.Services
{
    public class TodoExtensionsTest
    {
        [Fact]
        public void NotDeleted_Should_Throw_ArgumentNullException_If_Items_Is_Null()
        {
            IQueryable<TodoItem> items = null;

            var ex = Assert.Throws<ArgumentNullException>(() => TodoExtensions.NotDeleted(items));
            Assert.Equal(nameof(items), ex.ParamName);
        }

        [Fact]
        public void NotDeleted_Should_Returns_Only_Items_Not_Deleted()
        {
            var todo1 = TodoItem.NewTodo("text1");
            var todo2 = TodoItem.NewTodo("text2");
            var todo3 = TodoItem.NewTodo("text3");
            todo3.Delete();

            IQueryable<TodoItem> items = new[] { todo1, todo2, todo3 }.AsQueryable();

            var notDeletedItems = TodoExtensions.NotDeleted(items);

            Assert.True(notDeletedItems.All(t => !t.IsDeleted));
        }
    }
}
