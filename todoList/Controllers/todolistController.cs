using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoList.Entity;
using todoList.Models;
using todoList.Service;

namespace todoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class todolistController : ControllerBase
    {
        private readonly TodolistService _todoService;

        public todolistController(TodolistService todoService)
        {
            _todoService = todoService;
        }

        // GET api/todolists
        [HttpGet]
        public ActionResult<IEnumerable<ToDolist>> GetTodolists()
        {
            var todolist = _todoService.GetTodolists();
            return Ok(todolist);
        }

        // GET api/todolists/{id}
        [HttpGet("{id}")]
        public ActionResult<ToDolist> GetTodolistById(int id) 
        {
            var todolist = _todoService.GetTodoById(id);
            if (todolist == null) 
            {
                return NotFound();
            }
            return todolist;
        }

        // POST api/todolists
        [HttpPost]
        public ActionResult<ToDolist> Post(ToDoListModel toDoListModel) 
        {
            if (toDoListModel == null) 
            {
                return BadRequest("Invalid input data.");
            }
            ToDolist addTodoList = _todoService.AddToDoList(toDoListModel);
            return CreatedAtAction(nameof(GetTodolistById), new {id = addTodoList.Id}, addTodoList);
        }

        // PUT api/todolists/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, ToDoListModel toDoListModel)
        {
            if (toDoListModel == null)
            {
                return BadRequest("Invalid input data.");
            }
            try
            {
                _todoService.UpdateTodoList(id, toDoListModel);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cannot find the specified TodoList.");
            }
        }

        // DELETE api/todolists/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _todoService.DeleteTodoList(id);
                return NoContent();  // 返回204 No Content
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Cannot find the specified TodoList.");
            }
        }
    }
}
