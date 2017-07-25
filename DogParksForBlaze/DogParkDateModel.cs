namespace DogParksForBlaze
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DogParkDateModel : DbContext
    {
        // to update changes to schema, go to View>Other Windows>Package Manager Console
        // and type in Enable-Migrations>Enter (only need to run once per project)
        // then type in Add-Migration and give it a name (such as CreatedDate)
        // Apply changes by typing in Update-Database
        // must run the 2nd and 3rd commands each time schema changes

        // Your context has been configured to use a 'DogParkDateModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DogParksForBlaze.DogParkDateModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DogParkDateModel' 
        // connection string in the application configuration file.
        public DogParkDateModel()

            // same name as class name, no return type, means this is a constructor for the class
            : base("name=DogParkDateModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // this creates a new table called DogParkDateAccounts by looking at the schema
        // of the DogParkDateAccount class; DogParkDateAccounts has red squiggly under it
        // until go to DogParkDateAccount class and type 'public' in front of account class
        // to make it accessible
        public virtual DbSet<dogParkDateAccount> DogParkDateAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}