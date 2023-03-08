namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "PKLotID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "PKLotID", c => c.String(nullable: false));
        }
    }
}
