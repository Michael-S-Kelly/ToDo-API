using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models.Interfaces
{
    public interface IToDoItems
    {
        Task AddToDoItem(ToDoItems toDoItems);

        IEnumerable<ToDoItems> GetAll();

        ToDoItems GetByID(int id);

        Task EditToDoItem(int id, ToDoItems toDoItem);

        Task DeleteTodoItem(int id);
    }
}
