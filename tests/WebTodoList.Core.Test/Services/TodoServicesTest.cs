using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTodoList.Core.Models;
using WebTodoList.Core.Persistence;
using WebTodoList.Core.Services;
using WebTodoList.Core.Test.Mocks;
using Xunit;

namespace WebTodoList.Core.Test.Services
{
    public class TodoServicesTest : IClassFixture<TodoDbContextMockBuilder>
    {
        private readonly TodoDbContextMockBuilder _builder;

        public TodoServicesTest(TodoDbContextMockBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        [Fact]
        public void Ctor_Should_Throw_ArgumentNullException_If_Context_Is_Null()
        {
            TodoDbContext context = null;

            var ex = Assert.Throws<ArgumentNullException>(() => new TodoServices(context));
            Assert.Equal(nameof(context), ex.ParamName);
        }

        [Fact]
        public void Find_Should_Return_All_Todo_Items()
        {
            using (var context = _builder.BuildDbContext())
            {
                var todos = new TodoItem[]
                {
                    TodoItem.NewTodo("text1"), TodoItem.NewTodo("text2"), TodoItem.NewTodo("todo2")
                };

                _builder.PrepareData(context, todos);

                var services = new TodoServices(context);
                var todosFound = services.Find();

                Assert.Equal(todos, todosFound.ToArray());

                _builder.CleanAllData(context);
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task CreateNewTodoItem_Should_Throw_ArgumentException_If_TodoItemText_Is_Empty(string todoItemText)
        {
            using (var context = _builder.BuildDbContext())
            {
                var services = new TodoServices(context);

                var ex = await Assert.ThrowsAsync<ArgumentException>(() => services.CreateNewTodoItem(todoItemText));
                Assert.Equal(nameof(todoItemText), ex.ParamName);
            }
        }

        [Fact]
        public async Task CreateNewTodoItem_Should_Add_A_Todo_Item_With_Specified_Text()
        {
            using (var context = _builder.BuildDbContext())
            {
                var services = new TodoServices(context);
                string todoItemText = "My new todo";

                await services.CreateNewTodoItem(todoItemText);

                Assert.Equal(todoItemText, context.TodoItems.FirstOrDefault()?.Text);

                _builder.CleanAllData(context);
            }
        }

        [Fact]
        public async Task DeleteTodo_Should_Throw_ArgumentException_If_TodoId_Is_Empty()
        {
            using (var context = _builder.BuildDbContext())
            {
                var services = new TodoServices(context);
                Guid todoId = Guid.Empty;

                var ex = await Assert.ThrowsAsync<ArgumentException>(() => services.DeleteTodo(todoId));
                Assert.Equal(nameof(todoId), ex.ParamName);
            }
        }

        [Fact]
        public async Task DeleteTodo_Should_Mark_The_Specified_Todo_Item_As_Deleted()
        {
            using (var context = _builder.BuildDbContext())
            {
                var todos = new TodoItem[]
                {
                    TodoItem.NewTodo("text1")
                };

                _builder.PrepareData(context, todos);

                var services = new TodoServices(context);
                Guid todoId = context.TodoItems.First().Id;

                await services.DeleteTodo(todoId);

                var todo = context.TodoItems.First(t => t.Id == todoId);
                Assert.True(todo.IsDeleted);

                _builder.CleanAllData(context);
            }
        }

        [Fact]
        public async Task MarkTodoAsDone_Should_Throw_ArgumentException_If_TodoId_Is_Empty()
        {
            using (var context = _builder.BuildDbContext())
            {
                var services = new TodoServices(context);
                Guid todoId = Guid.Empty;

                var ex = await Assert.ThrowsAsync<ArgumentException>(() => services.MarkTodoAsDone(todoId));
                Assert.Equal(nameof(todoId), ex.ParamName);
            }
        }

        [Fact]
        public async Task MarkTodoAsDone_Should_Mark_The_Specified_Todo_Item_As_Done()
        {
            using (var context = _builder.BuildDbContext())
            {
                var todos = new TodoItem[]
                {
                    TodoItem.NewTodo("text1")
                };

                _builder.PrepareData(context, todos);

                var services = new TodoServices(context);
                Guid todoId = context.TodoItems.First().Id;

                await services.MarkTodoAsDone(todoId);

                var todo = context.TodoItems.First(t => t.Id == todoId);
                Assert.True(todo.IsDone);

                _builder.CleanAllData(context);
            }
        }
    }
}
