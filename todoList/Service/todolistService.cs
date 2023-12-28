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

        public IEnumerable<ToDolist> GetTodolists()
        {
            return _context.Todolists.ToList();
        }

        public ToDolist GetTodoById(int id) 
        {
            return _context.Todolists.Find(id);
        }

        public ToDolist AddToDoList(ToDoListModel toDoListModel) 
        { 
            var Todolist = new ToDolist
            {
				Id = toDoListModel.Id,
				Name = toDoListModel.Name,
				IsComplete = toDoListModel.IsComplete,
				Created_at = toDoListModel.Created_at,
				Complete_at = toDoListModel.Complete_at,
				Priority = toDoListModel.Priority,
				Account_ID = toDoListModel.Account_ID
			};
            _context.Todolists.Add(Todolist);
            _context.SaveChanges();
            return Todolist;
        }

        public void UpdateTodoList(int id, ToDoListModel toDoListModel) 
        {

			var existingTodoList = _context.Todolists.Find(id);

			if (existingTodoList == null)
			{
				throw new KeyNotFoundException("Cannot find the specified TodoList");
			}

			
			existingTodoList.Name = toDoListModel.Name;
			existingTodoList.IsComplete = toDoListModel.IsComplete;
			existingTodoList.Created_at = toDoListModel.Created_at;
			existingTodoList.Complete_at = toDoListModel.Complete_at;
			existingTodoList.Priority = toDoListModel.Priority;
			existingTodoList.Account_ID = toDoListModel.Account_ID;
			_context.SaveChanges();
		}
			
			
        

        public void DeleteTodoList(int id) 
        {
            var todolist = _context.Todolists.Find(id);
            if (todolist == null)
            {
                throw new KeyNotFoundException("Cannot find the specified TodoList");
            }

            _context.Todolists.Remove(todolist);
            _context.SaveChanges();
        }
    }
}
