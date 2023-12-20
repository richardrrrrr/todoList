using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoList.Models
{
    public class todolist
    {
        [Key]
        public int Id { get; set; } = 0;
        [ForeignKey("Account")]
        public int Account_ID { get; set; } = 0;
        [StringLength(100)]
        public string Name { get; set; } = "";
        public bool IsComplete { get; set; } = false;
        public DateTime? Created_at { get; set; } 
        public DateTime? Complete_at { get; set; } 
        public int Priority { get; set; } = 0;
        public account Account { get; set; }
    }
}
