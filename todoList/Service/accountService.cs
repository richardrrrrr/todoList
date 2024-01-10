using Microsoft.Identity.Client;
using System.Data;
using todoList.Entity;
using todoList.Models;

namespace todoList.Service
{
    public class AccountService
    {
        public readonly TodolistDbContext _context;
        public AccountService(TodolistDbContext context) 
        {
            _context = context;
        }


        public IEnumerable<Account> GetAccounts() 
        {
            return _context.Accounts.ToList();
        }


        public Account GetAccountId(int account_id) 
        {
            return _context.Accounts.Find(account_id);
        }


        public Account AddAccount(AccountModel accountModel)
        {
            var account = new Account
            {
                Account_ID = accountModel.Account_ID,
                UserName = accountModel.UserName,
                Password = accountModel.Password,
                Role = accountModel.Role,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }


        public void UpdateAccount(int accound_id, AccountModel accountModel)
        {
            var existingAccount = _context.Accounts.Find(accound_id);
            if (existingAccount == null) 
            {
				throw new KeyNotFoundException("Cannot find the specified Account");
			}
            existingAccount.UserName = accountModel.UserName;
            existingAccount.Password = accountModel.Password;
            existingAccount.Role = accountModel.Role;
			_context.SaveChanges();
		}


        public void DeleteAccount(int accound_id) 
        {
            var accounts = _context.Accounts.Find(accound_id);
            if (accounts == null)
            {
				throw new KeyNotFoundException("Cannot find the specified Account");
			}
            _context.Accounts.Remove(accounts);
            _context.SaveChanges();
        }
    }
}
