using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Models.Interfaces;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoLists _toDoLists;

        /// <summary>
        /// Pulls in the database
        /// </summary>
        /// <param name="toDoItems">To Do Lists Interface</param>
        public ToDoListsController(IToDoLists toDoLists)
        {
            _toDoLists = toDoLists;
        }

        /// <summary>
        /// (Get) Gets all the To Do Lists
        /// </summary>
        /// <returns>GetAll ActionResult</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ToDoLists>> Get()
        {
            return _toDoLists.GetAll().ToList();
        }

        /// <summary>
        /// (Get) Gets a To Do List by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>ActionResult</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ToDoLists toDoLists = _toDoLists.GetByID(id);
            if (toDoLists == null)
            {
                return NotFound();
            }
            return Ok(toDoLists);
        }

        /// <summary>
        /// (Post) Post To Do List Row
        /// </summary>
        /// <param name="userRatings">To Do List Row</param>
        /// <returns>Action Result Task</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoLists toDoLists)
        {
            if (toDoLists.ID <= 0)
            {
                await _toDoLists.CreateToDoList(toDoLists);
            }
            else
            {
                await Put(toDoLists.ID, toDoLists);
            }
            return RedirectToAction("Get", new { id = toDoLists.ID });
        }

        /// <summary>
        /// (Put) Edit To Do List
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="userRatings">To Do List row</param>
        /// <returns>Put Action Result</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoLists toDoLists)
        {
            ToDoLists toDoList = _toDoLists.GetByID(id);
            if (toDoList != null)
            {
                await _toDoLists.EditToDoList(id, toDoList);
            }
            else
            {
                await Post(toDoList);
            }
            return RedirectToAction("Get", new { id = toDoList.ID });
        }

    }
}