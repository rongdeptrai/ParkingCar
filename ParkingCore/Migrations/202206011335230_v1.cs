namespace ParkingCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adminstrators",
                c => new
                    {
                        AdminID = c.String(nullable: false, maxLength: 128),
                        PkID = c.String(maxLength: 128),
                        Pass = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.Parkings", t => t.PkID)
                .Index(t => t.PkID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.String(nullable: false, maxLength: 128),
                        CusID = c.String(nullable: false, maxLength: 128),
                        CusName = c.String(),
                        Phone = c.String(nullable: false),
                        CarNo = c.String(nullable: false),
                        PKLotID = c.String(nullable: false),
                        SlotNo = c.String(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        ExpOut = c.DateTime(nullable: false),
                        Status = c.Boolean(),
                        ExpTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentStatus = c.Boolean(nullable: false),
                        Parking_PkID = c.String(maxLength: 128),
                        ParkingSlot_PkSlotID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Customers", t => t.CusID, cascadeDelete: true)
                .ForeignKey("dbo.Parkings", t => t.Parking_PkID)
                .ForeignKey("dbo.ParkingSlots", t => t.ParkingSlot_PkSlotID)
                .Index(t => t.CusID)
                .Index(t => t.Parking_PkID)
                .Index(t => t.ParkingSlot_PkSlotID);
            
            CreateTable(
                "dbo.OrderInvoids",
                c => new
                    {
                        OrdID = c.String(nullable: false, maxLength: 128),
                        BookingID = c.String(nullable: false, maxLength: 128),
                        CusName = c.String(),
                        Phone = c.String(nullable: false),
                        CarNo = c.String(nullable: false),
                        PKLotName = c.String(nullable: false),
                        SlotNo = c.String(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        ExpOut = c.DateTime(nullable: false),
                        DateOut = c.DateTime(nullable: false),
                        Status = c.Boolean(),
                        ExpTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.String(nullable: false, maxLength: 128),
                        CusID = c.String(nullable: false, maxLength: 128),
                        CusName = c.String(nullable: false, maxLength: 200),
                        CarNo = c.String(nullable: false),
                        CarType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Customers", t => t.CusID, cascadeDelete: true)
                .Index(t => t.CusID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CusID = c.String(nullable: false, maxLength: 128),
                        CusName = c.String(nullable: false, maxLength: 200),
                        Pass = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CusID);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        PkID = c.String(nullable: false, maxLength: 128),
                        PkName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        Slot = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        PkAddress = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PkID);
            
            CreateTable(
                "dbo.ParkingSlots",
                c => new
                    {
                        PkSlotID = c.String(nullable: false, maxLength: 128),
                        PkID = c.String(nullable: false),
                        SlotNo = c.String(nullable: false, maxLength: 200),
                        Status = c.Boolean(),
                        Floor = c.Int(nullable: false),
                        PkTID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PkSlotID)
                .ForeignKey("dbo.ParkingTypes", t => t.PkTID, cascadeDelete: true)
                .Index(t => t.PkTID);
            
            CreateTable(
                "dbo.ParkingTypes",
                c => new
                    {
                        PkTID = c.String(nullable: false, maxLength: 128),
                        PkTName = c.String(nullable: false, maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PkTID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkingSlots", "PkTID", "dbo.ParkingTypes");
            DropForeignKey("dbo.Bookings", "ParkingSlot_PkSlotID", "dbo.ParkingSlots");
            DropForeignKey("dbo.Bookings", "Parking_PkID", "dbo.Parkings");
            DropForeignKey("dbo.Adminstrators", "PkID", "dbo.Parkings");
            DropForeignKey("dbo.Cars", "CusID", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "CusID", "dbo.Customers");
            DropForeignKey("dbo.OrderInvoids", "BookingID", "dbo.Bookings");
            DropIndex("dbo.ParkingSlots", new[] { "PkTID" });
            DropIndex("dbo.Cars", new[] { "CusID" });
            DropIndex("dbo.OrderInvoids", new[] { "BookingID" });
            DropIndex("dbo.Bookings", new[] { "ParkingSlot_PkSlotID" });
            DropIndex("dbo.Bookings", new[] { "Parking_PkID" });
            DropIndex("dbo.Bookings", new[] { "CusID" });
            DropIndex("dbo.Adminstrators", new[] { "PkID" });
            DropTable("dbo.ParkingTypes");
            DropTable("dbo.ParkingSlots");
            DropTable("dbo.Parkings");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
            DropTable("dbo.OrderInvoids");
            DropTable("dbo.Bookings");
            DropTable("dbo.Adminstrators");
        }
    }
}
