namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkingSlots", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkingSlots", "Status", c => c.Boolean());
        }
    }
}
