using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models.Interfaces
{
    public interface IToDoLists
    {
        Task CreateToDoList(ToDoLists toDoLists);

        IEnumerable<ToDoLists> GetAll();

        ToDoLists GetByID(int id);

        Task EditToDoList(int id, ToDoLists toDoLists);

        Task DeleteTodoList(int id);
    }
}
