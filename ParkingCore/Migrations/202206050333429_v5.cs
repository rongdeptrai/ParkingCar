namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInvoids", "PkID", c => c.String(nullable: false));
            AddColumn("dbo.OrderInvoids", "PkName", c => c.String(nullable: false));
            AddColumn("dbo.OrderInvoids", "PkSlotID", c => c.String(nullable: false));
            DropColumn("dbo.OrderInvoids", "PKLotName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInvoids", "PKLotName", c => c.String(nullable: false));
            DropColumn("dbo.OrderInvoids", "PkSlotID");
            DropColumn("dbo.OrderInvoids", "PkName");
            DropColumn("dbo.OrderInvoids", "PkID");
        }
    }
}
