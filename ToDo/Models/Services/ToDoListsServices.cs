using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models.Interfaces;
using ToDo.Data;

namespace ToDo.Models.Services
{
    public class ToDoListsServices : IToDoLists
    {
        private ToDoDbContext _context;

        /// <summary>
        /// Connects to Database
        /// </summary>
        /// <param name="context">Database</param>
        public ToDoListsServices(ToDoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// (Create) Adds a new To Do List to the database
        /// </summary>
        /// <param name="toDoLists">To Do List</param>
        /// <returns>Add Task</returns>
        public async Task CreateToDoList(ToDoLists toDoLists)
        {
            _context.ToDoLists.Add(toDoLists);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// (Read) Gets all the To Do Lists
        /// </summary>
        /// <returns>List of To Do Lists</returns>
        public IEnumerable<ToDoLists> GetAll()
        {
            return _context.ToDoLists;
        }

        /// <summary>
        /// (Read) Gets a To Do List by ID
        /// </summary>
        /// <param name="id">To Do List ID</param>
        /// <returns>a To Do List</returns>
        public ToDoLists GetByID(int id)
        {
            ToDoLists toDoLists = _context.ToDoLists.Find(id);
            return toDoLists;
        }

        /// <summary>
        /// (Update) Edits the columns of the ToDoLists
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="toDoLists">To Do List</param>
        /// <returns></returns>
        public async Task EditToDoList(int id, ToDoLists toDoLists)
        {
            ToDoLists toDoList = GetByID(id);
            toDoList.ID = toDoLists.ID;
            toDoList.UserName = toDoLists.UserName;
            toDoList.Name = toDoLists.Name;

            _context.ToDoLists.Update(toDoList);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// (Delete) Removes a To Do List by ID and all To Do Items associated with the List
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Delete Task</returns>
        public async Task DeleteTodoList(int id)
        {
            var toDoLists = GetByID(id);
            var toDoItems = _context.ToDoItems;
            foreach (ToDoItems toDoItem in _context.ToDoItems)
            {
                if (toDoItem.ToDoListID == toDoLists.ID)
                {
                    _context.ToDoItems.Remove(toDoItem);
                    await _context.SaveChangesAsync();
                }
            }
            _context.ToDoLists.Remove(toDoLists);
            await _context.SaveChangesAsync();
        }
    }
}
