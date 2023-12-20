using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoList.Models
{
    public class account
    {
        [Key]
        public int Account_ID { get; set; } 
        
        [StringLength(100)]
        public string UserName { get; set; }
        
        [StringLength(100)]
        public string Password { get; set; } 
        public int? Role { get; set; } // 1: 管理者 2: 普通用戶
        [InverseProperty("Account")]
        public ICollection<todolist> TodoList { get; set; }

    }
}