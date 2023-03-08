namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
