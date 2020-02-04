using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTodoList.ViewModels.Todo
{
    public class ListItemViewModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool IsDone { get; set; }
    }
}
