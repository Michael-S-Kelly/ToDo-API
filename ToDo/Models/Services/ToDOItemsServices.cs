using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models.Interfaces;
using ToDo.Data;

namespace ToDo.Models.Services
{
    public class ToDoItemsServices : IToDoItems
    {
        private ToDoDbContext _context;

        /// <summary>
        /// Connects to Database
        /// </summary>
        /// <param name="context">Database</param>
        public ToDoItemsServices(ToDoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// (Create) Adds a To Do Item
        /// </summary>
        /// <param name="toDoItems">ToDo Item</param>
        /// <returns></returns>
        public async Task AddToDoItem(ToDoItems toDoItems)
        {
            _context.ToDoItems.Add(toDoItems);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// (Read) Get all the To Do Items
        /// </summary>
        /// <returns>To Do Items</returns>
        public IEnumerable<ToDoItems> GetAll()
        {
            return _context.ToDoItems;
        }

        /// <summary>
        /// (Read) Get a To Do Item by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>To Do Item</returns>
        public ToDoItems GetByID(int id)
        {
            ToDoItems toDoItems = _context.ToDoItems.Find(id);
            return toDoItems;
        }

        /// <summary>
        /// (Update) Edit To Do Items by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="toDoItems">To Do Item</param>
        /// <returns>Update Task</returns>
        public async Task EditToDoItem(int id, ToDoItems toDoItems)
        {
            ToDoItems toDoItem = GetByID(id);
            toDoItem.ID = toDoItems.ID;
            toDoItem.ToDoListID = toDoItems.ToDoListID;
            toDoItem.Name = toDoItems.Name;
            toDoItem.IsComplete = toDoItems.IsComplete;

            _context.ToDoItems.Update(toDoItem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// (Delete) Remove a To Do Item by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Delete Task</returns>
        public async Task DeleteTodoItem(int id)
        {
            var toDoItem = GetByID(id);
            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();
        }
        
    }
}
