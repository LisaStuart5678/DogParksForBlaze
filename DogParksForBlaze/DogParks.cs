using DogParksForBlaze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogParksForBlaze
{
    // application of static to class makes it the only instance of this class so keyword 'new' is not required
    // to use it since, like a bank, it already exists for you to go to, it doesn't need created every time 
    // like a new account does
    /// <summary>
    /// This holds information about dog parks
    /// </summary>
    static class DogParkDate
    {
        // create a list data type to store account numbers from the class DogParkDateAccount (which is the data type)
        // in and then call it accounts (plural); assigning a value to a value type such as a variable like int i = 10
        // is different than a reference type which requires the 'new' keyword in order to allocate the memory
        // space; you must create a space before you can put things in it; so here 'accounts' is a pointer
        // to the List of the type DogParkDateAccount

        // no longer need following line of code for temp storage of list, creating db
        // private static List<DogParkDateAccount> accounts = new List<DogParkDateAccount>();

        // this now creates connection to db DogParkDateModel
        private static DogParkDateModel db = new DogParkDateModel();

        private static int lastDogParkNumber = 0;

        #region Properties
        // if do no see keyword static, that means it is an instance by default, but b/c we've made this class static
        // need to add that keyword to all properties
        public static string DogParkName { get; set; }
        public static string DogParkAddress { get; set; }
        public static string DogParkCity { get; set; }
        public static string DogParkState { get; set; }
        public static string DogParkZip { get; set; }
        public static int DogParkNumber { get; set; }
        #endregion

        #region Methods
        // get items from user account that are not set to private
        public static DogParkDateAccount CreateAccount(string userName, string emailAddress, string dogName, 
            AccountTypes typeOfAccount, int amount)
        {
            // any time use 'new' keyword means it is a reference type creating to put values into
            // just use curly braces allows for not having to use a constructor
            var account = new DogParkDateAccount
            {
                // property name equal to variable name so no need to use a constructor, left side is property in 
                // account class and right side is variable accepting as parameters
                UserName = userName,
                EmailAddress = emailAddress,
                DogName = dogName,
                TypeOfAccount = typeOfAccount
            };
            // if new user is buying bark bucks or earning them by sharing the app:
            if (amount > 0)
            {
                account.Buy(amount);
            }
            // return the name of the variable, not the class (it is a blueprint, not an instance)
            db.DogParkDateAccounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static List<DogParkDateAccount> GetAllAccounts()
        {
            return db.DogParkDateAccounts.ToList();
        }

        public static List<Transaction> GetAllTransactionsForAccount(int accountNumber)
        {
            // based on accountNum passed as param in Method, return tx for that account
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).ToList();
        }

        public static DogParkDateAccount GetAccountByAccountNumber(int accountNumber)
        {
            // this says in my list of accounts, get the account number where it is equal to that passed
            // by user starting with the 'a'th row and continuing until found; the Where stmt is the LINQ
            // and the stmt inside paren is the lambda
            return db.DogParkDateAccounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
        }
        public static void Buy(int accountNumber, decimal amount)
        {
            var account = db.DogParkDateAccounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentOutOfRangeException("Account number is not valid.");
            account.Buy(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Purchase BarkBucks",
                TransactionType = TransactionType.Credit,
                Amount = amount,
                AccountNumber = accountNumber
            };

            // this adds row to table and commits the changes
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Use(int accountNumber, decimal amount)
        {

            var account = db.DogParkDateAccounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentOutOfRangeException("Account number is not found.");

            account.Use(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Use BarkBucks to set up a DoggyDate",
                TransactionType = TransactionType.Debit,
                Amount = amount,
                AccountNumber = accountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        #endregion

    }
}
