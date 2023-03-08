namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Parking_PkID", "dbo.Parkings");
            DropForeignKey("dbo.Bookings", "ParkingSlot_PkSlotID", "dbo.ParkingSlots");
            DropIndex("dbo.Bookings", new[] { "Parking_PkID" });
            DropIndex("dbo.Bookings", new[] { "ParkingSlot_PkSlotID" });
            RenameColumn(table: "dbo.Bookings", name: "Parking_PkID", newName: "PkID");
            RenameColumn(table: "dbo.Bookings", name: "ParkingSlot_PkSlotID", newName: "PkSlotID");
            AlterColumn("dbo.Bookings", "PkID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Bookings", "PkSlotID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Bookings", "PkID");
            CreateIndex("dbo.Bookings", "PkSlotID");
            AddForeignKey("dbo.Bookings", "PkID", "dbo.Parkings", "PkID", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "PkSlotID", "dbo.ParkingSlots", "PkSlotID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PkSlotID", "dbo.ParkingSlots");
            DropForeignKey("dbo.Bookings", "PkID", "dbo.Parkings");
            DropIndex("dbo.Bookings", new[] { "PkSlotID" });
            DropIndex("dbo.Bookings", new[] { "PkID" });
            AlterColumn("dbo.Bookings", "PkSlotID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bookings", "PkID", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Bookings", name: "PkSlotID", newName: "ParkingSlot_PkSlotID");
            RenameColumn(table: "dbo.Bookings", name: "PkID", newName: "Parking_PkID");
            CreateIndex("dbo.Bookings", "ParkingSlot_PkSlotID");
            CreateIndex("dbo.Bookings", "Parking_PkID");
            AddForeignKey("dbo.Bookings", "ParkingSlot_PkSlotID", "dbo.ParkingSlots", "PkSlotID");
            AddForeignKey("dbo.Bookings", "Parking_PkID", "dbo.Parkings", "PkID");
        }
    }
}
