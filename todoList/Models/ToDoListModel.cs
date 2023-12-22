using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using todoList.Entity;

namespace todoList.Models
{
	public class ToDoListModel
	{
		
		public int Id { get; set; } = 0;		
		public int Account_ID { get; set; } = 0;		
		public string Name { get; set; } = "";
		public bool IsComplete { get; set; } = false;
		public DateTime? Created_at { get; set; }
		public DateTime? Complete_at { get; set; }
		public int Priority { get; set; } = 0;

	
}
}
