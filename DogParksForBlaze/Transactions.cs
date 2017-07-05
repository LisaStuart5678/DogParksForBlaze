using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogParksForBlaze
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        // have to say in paren which table FK is tied to
        // says that, from Transactions table, this is tied to one DogParkDateAccount and this AccountNum is the FK
        // but an account has many transactions so go to account class to define that side of the rel'ship
        // the argument name passed to the FK MUST be the same as the virtual name below (2nd "DogParkDateAccount")
        [ForeignKey("DogParkDateAccount")]
        public int AccountNumber { get; set; }

        // virtual relationship between Transaction class to the DogParkDateAccount class
        public virtual DogParkDateAccount DogParkDateAccount { get; set; }
    }
}
