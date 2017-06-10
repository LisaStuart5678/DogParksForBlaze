using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogParksForBlaze
{
    // enum is a way to create your own set of value types, allows user to pick from the list, coded just before and outside of class
    // that way it can be available globally, can only put strings here with no spaces or special chars, behind the scenes
    // assigns a number to it though (hover to see, can give it a specific value if want to), then in properties, need to
    // change accountType from string return type to this enum name as the new return type, this restricts choices user can enter
    // if using overload that I create instead of C# automatically, need to change return type in params to this enum name also
    // now also need to go to Program.cs and change instantiation of 'var account' from "Checking" (highlight, space bar, gives new avail options)
    // see second line of commented out code where replaced "Checking" with 'AccountTypes.Checking', did same for Account2
    public enum AccountTypes
    {
        Free,
        HappyDog
    }
    /// <summary>
    /// This is an account that holds information of an account for a particular dog owner
    /// </summary>
    class DogParkDateAccount
    {
        // static means that there's only one copy vs an instance which can be many copies of an object
        // by making it static, the instances of 'account' can share/access the variable when necessary
        private static int lastAccountNumber = 0;

        // A. created properties:
        #region Properties

        /// <summary>
        /// Triple slash then enter gives multi-line commments; to create properties, type prop then tab, tab
        /// accessModifier dataType NameOfProperty
        /// </summary>
        // private set lets you control who is able to access
        public int AccountNumber { get; private set; } // 1. Created first, originally not private
        public string UserName { get; set; } // 2. created second
        public string EmailAddress { get; set; } // 3. created third
        public string DogName { get; set; }
        public decimal BarkBucks { get; private set; } // 4. created fourth; private means user cannot set, only those with access to this class (webmaster)
        public AccountTypes TypeOfAccount { get; set; } // 5. created fifth, then added region specifying these are all the Properties (by naming the region that) which can then collapse
        #endregion

        // C2. a constructor is a special method that doesn't require a return type and is called with the keyword 'new'
        // it's already there, it's just hidden and only need to add to it if something else needs doing besides default
        // the method that is created just after needs to be given the same name as the class name followed by parentheses
        // if looking at someone else's code and see a method name that is same as class name, know it's a constructor
        #region Constructor 
        public DogParkDateAccount()
        {
            lastAccountNumber++;
            AccountNumber = lastAccountNumber;
        }

        // D1. Overloading a constructor, using the same method with different parameters (although now C# helps so no 
        // need to create all possible combinations (see Program.cs)
        public DogParkDateAccount(string userName) : this() // this refers to the current construction, here the person creating
                                                    // the new account wants a certain account name, so this overload allows to set the property as what
                                                    // the person is telling you they want
        {
            UserName = userName;
        }
        public DogParkDateAccount(string userName, string emailAddress) : this(userName) // want to add parameter to 'this' of previous overload which in turn does previous code
        {
            // so if you are given an account name and email address, the last account number code is fired recursively after the one that follows it and so on (here setting email)
            EmailAddress = emailAddress;
        }
        public DogParkDateAccount(string userName, string emailAddress, AccountTypes typeOfAccount) : this(userName, emailAddress)
        {
            TypeOfAccount = typeOfAccount;
        }
        public DogParkDateAccount(string userName, string emailAddress, AccountTypes typeOfAccount, decimal amount) : this(userName, emailAddress, typeOfAccount)
        {
            Earn(amount); // earn bark bucks based on amount of shares, spend them to set up dates or earn dog treats/toys
        }
        #endregion
        #region Methods
        /// <summary>
        /// Added this region with Methods after adding Properties methods (first) above
        /// Adds deposit to existing balance
        /// accessModifier returnType [void for nothing returned] NameOfMethod(dataType paramName) paramName is only
        /// accessible within the method in which it is defined, so it's local to the scope of that method
        /// </summary>
        /// <param name="amount"></param>
        public void Earn(decimal amount)
        {
            BarkBucks += amount; // what does this method do? always end statements with a semi-colon (;)
        }
        public void Use(decimal amount)
        {
            BarkBucks -= amount;
        }

        #endregion
    }
}
