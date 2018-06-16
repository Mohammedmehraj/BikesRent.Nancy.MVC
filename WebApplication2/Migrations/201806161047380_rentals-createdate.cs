namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentalscreatedate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Createddate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "Createddate");
        }
    }
}
