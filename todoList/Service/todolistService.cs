using todoList.Entity;
using todoList.Models;

namespace todoList.Service
{
    public class TodolistService 
    {
        public readonly TodolistDbContext _context;
        public TodolistService(TodolistDbContext context)
        {
            _context = context;
        }

        public IEnumerable<todolist> GetTodolists()
        {
            return _context.Todolists.ToList();
        }

        public todolist GetTodoById(int id) 
        {
            return _context.Todolists.Find(id);
        }

        public todolist AddToDoList(todolist todolist) 
        {
            _context.Todolists.Add(todolist);
            _context.SaveChanges();
            return todolist;
        }

        public void UpdateTodoList(int id, todolist todolist) 
        {
            var existingTodoList = _context.Todolists.Find(id);
            if (existingTodoList != null)
            {
                throw new KeyNotFoundException("Cannot find the specified TodoList");
            }

            _context.Entry(existingTodoList).CurrentValues.SetValues(UpdateTodoList);
            _context.SaveChanges();
        }

        public void DeleteTodoList(int id) 
        {
            var todolist = _context.Todolists.Find(id);
            if (todolist != null)
            {
                throw new KeyNotFoundException("Cannot find the specified TodoList");
            }

            _context.Todolists.Remove(todolist);
            _context.SaveChanges();
        }
    }
}
