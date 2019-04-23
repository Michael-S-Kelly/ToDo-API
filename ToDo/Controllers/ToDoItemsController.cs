using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models.Interfaces;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItems _toDoItems;

        /// <summary>
        /// Pulls in the database
        /// </summary>
        /// <param name="toDoItems">To Do Items Interface</param>
        public ToDoItemsController(IToDoItems toDoItems)
        {
            _toDoItems = toDoItems;
        }

        /// <summary>
        /// (Get) Gets all the To Do Items
        /// </summary>
        /// <returns>GetAll ActionResult</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItems>> Get()
        {
            return _toDoItems.GetAll().ToList();
        }

        /// <summary>
        /// (Get) Gets a To Do Item by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>ActionResult</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ToDoItems toDoItems = _toDoItems.GetByID(id);
            if (toDoItems == null)
            {
                return NotFound();
            }
            return Ok(toDoItems);
        }

        /// <summary>
        /// (Post) Post To Do Item Row
        /// </summary>
        /// <param name="userRatings">To Do Item Row</param>
        /// <returns>Action Result Task</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItems toDoItems)
        {
            if (toDoItems.ID <= 0)
            {
                await _toDoItems.AddToDoItem(toDoItems);
            }
            else
            {
                await Put(toDoItems.ID, toDoItems);
            }
            return RedirectToAction("Get", new { id = toDoItems.ID });
        }

        /// <summary>
        /// (Put) Edit To Do Item
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="userRatings">To Do Item row</param>
        /// <returns>Put Action Result</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoItems toDoItems)
        {
            ToDoItems toDoItem = _toDoItems.GetByID(id);
            if (toDoItem != null)
            {
                await _toDoItems.EditToDoItem(id, toDoItem);
            }
            else
            {
                await Post(toDoItem);
            }
            return RedirectToAction("Get", new { id = toDoItem.ID });
        }

        /// <summary>
        /// (Delete) Delete To Do Item by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Action Result</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _toDoItems.DeleteTodoItem(id);
            return Ok();
        }

    }
}