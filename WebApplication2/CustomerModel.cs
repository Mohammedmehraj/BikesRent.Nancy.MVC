namespace WebApplication2
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CustomerModel : DbContext
    {
        // Your context has been configured to use a 'CustomerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication2.CustomerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomerModel' 
        // connection string in the application configuration file.
        public CustomerModel()
            : base("name=CustomerModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Bikes> Bikes { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}