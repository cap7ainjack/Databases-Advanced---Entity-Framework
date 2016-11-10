namespace _1GringottsDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class GringottsContextVB : DbContext
    {
        // Your context has been configured to use a 'GringottsContextVB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_1GringottsDB.GringottsContextVB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GringottsContextVB' 
        // connection string in the application configuration file.
        public GringottsContextVB()
            : base("name=GringottsContextVB")
        {
            
        }

        public IDbSet<WizardsDepositsVB> WizzardDeposits { get; set; }

    }

}