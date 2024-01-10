using Microsoft.AspNetCore.Mvc;
using todoList.Entity;
using todoList.Service;
using todoList.Models;
namespace todoList.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class AccountController :ControllerBase
	{
		private readonly AccountService _accountService;
		public AccountController (AccountService accountService)
		{
			_accountService = accountService;
		}


		[HttpGet]
		public ActionResult<IEnumerable<Account>> GetAccount()
		{
			var account = _accountService.GetAccounts();
			return Ok(account);
		}


		[HttpGet("{account_id}")]
		public ActionResult<Account> GetAccountById(int accout_id)
		{
			var account = _accountService.GetAccountId(accout_id);
			if (account == null) 
			{
				return NotFound();
			}
			return account;
		}


		[HttpPost]
		public ActionResult<Account> Post(AccountModel accountModel)
		{
			if (accountModel == null) 
			{
				return BadRequest("Invalid input data.");
			}
			Account addAccount = _accountService.AddAccount(accountModel);
			return CreatedAtAction(nameof(GetAccountById), new { id = addAccount.Account_ID }, addAccount);
		}


		[HttpPut("aaccount_id")]
		public IActionResult Put(int account_id,AccountModel accountModel) 
		{
			if (accountModel == null)
			{
				return BadRequest("Invalid input data.");
			}
			try
			{
				_accountService.UpdateAccount(account_id, accountModel);
				return NoContent();
			}
			catch(KeyNotFoundException)
			{
				return NotFound("Cannot find the specified Account.");
			}

		}


		[HttpDelete]
		public IActionResult Delete(int account_id) 
		{
			try
			{
				_accountService.DeleteAccount(account_id);
				return NoContent();  // 返回204 No Content
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Cannot find the specified TodoList.");
			}
		}
	}
}
