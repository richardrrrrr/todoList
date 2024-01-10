using System.ComponentModel.DataAnnotations;

namespace todoList.Models
{
	public class AccountModel
	{
		public int Account_ID { get; set; }		
		public string UserName { get; set; }		
		public string Password { get; set; }
		public int? Role { get; set; } // 1: 管理者 2: 普通用戶
		
	}
}
