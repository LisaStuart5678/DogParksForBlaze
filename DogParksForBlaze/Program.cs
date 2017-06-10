using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogParksForBlaze
{
    class Program
    {
        static void Main(string[] args)
        {
            // E. code a menu to display choices to user
            Console.WriteLine("************Welcome to Doggy Play Date******************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create a new account");
            //Console.WriteLine("2. ");
            //Console.WriteLine("3. ");
            //Console.WriteLine("4. ");

            // ask user to select something from list
            // readline puts cursor on screen and stays until user types a selection and presses enter
            var choice = Console.ReadLine(); // takes user input and stores as variable called 'choice'

            // if checking for equality, instead of using if/else if stmt, use a switch (explanation on video from
            // 5/21 at 39 minutes); if need to check > or <, need to use if/else stmt
            switch (choice)
            {
                case "0":
                    return;
                case "1":
                    Console.Write("User Name: "); // .Write instead of writeLine keeps cursor on same line instead of moving to next line
                    var userName = Console.ReadLine();
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("Dog's Name: ");
                    var dogName = Console.ReadLine();
                    Console.WriteLine("Type of Account: ");
                    var accountTypes = Enum.GetNames(typeof(AccountTypes)); // this sets up ability to add an account to enum so is dynamic
                    // so this tells Enum to get the names of account types by passing the enum name of 'AccountTypes' as a param to typeof method
                    // if hover over 'GetNames' tool tip has string[] indicating giving back string array of AccountTypes given to variable names accountTypes
                    for (int i = 0; i < accountTypes.Length; i++) // for tab tab; for from 0 to length of accountTypes variable array
                    {
                        Console.WriteLine($"{i}. {accountTypes[i]}"); // curly braces prints what is inside it, the index num first and then the value at that index
                    }
                    Console.Write("Pick an account type: ");
                    var accountType = Convert.ToInt32(Console.ReadLine()); // b/c ReadLine gives a string, need to use convert function
                    Console.Write("Amount: ");
                    var amount = Convert.ToDecimal(Console.ReadLine());

                    // now that have everything from user, time to actually create the account by passing what user gave
                    var dogParkDateAccount = new DogParkDateAccount
                    {
                        UserName = userName,
                        EmailAddress = emailAddress,
                        TypeOfAccount = (AccountTypes)accountType // type conversion by using name want to custom convert to (explanation
                        // in 5/21 video at 37 minutes)
                    };
                    dogParkDateAccount.Earn(amount);
                    Console.WriteLine($"AN: , {dogParkDateAccount.AccountNumber}, BarkBucks Balance: {dogParkDateAccount.BarkBucks}");
                    break; // when done with this case, need to get out of it, otherwise will see squiggly line under 'Case 1' above
                //case "2":
                //case "3":
                //case "4":
                //default:
                    //break;
            }
        }
    }
}
