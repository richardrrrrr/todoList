using todoList.Entity;

namespace todoList.Service
{
    public class TodolistService 
    {
        public readonly TodolistDbContext _context;
        public TodolistService(TodolistDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDolist> GetTodolists()
        {
            return _context.Todolists.ToList();
        }

        public ToDolist GetTodoById(int id) 
        {
            return _context.Todolists.Find(id);
        }

        public ToDolist AddToDoList(ToDolist todolist) 
        {
            _context.Todolists.Add(todolist);
            _context.SaveChanges();
            return todolist;
        }

        public void UpdateTodoList(int id, ToDolist todolist) 
        {
            var existingTodoList = _context.Todolists.Find(id);

            if (existingTodoList != null)
            {
                throw new KeyNotFoundException("Cannot find the specified TodoList");
            }

			_context.Todolists.Update(existingTodoList);
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
