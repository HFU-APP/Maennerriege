using System;
using System.Collections.Generic;
using System.Text;

namespace Wettkampf.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }

        public Account(string password, string accountName)
        {
            Password = password;
            AccountName = accountName;
        }

        public bool CorrectInformation()
        {
            if (string.IsNullOrEmpty(AccountName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
    

