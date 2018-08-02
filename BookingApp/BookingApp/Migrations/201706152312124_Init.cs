namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accommodations", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.RoomReservations", "User_Id", "dbo.AppUsers");
            DropIndex("dbo.Accommodations", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.RoomReservations", new[] { "User_Id" });
            AddColumn("dbo.Accommodations", "AppUser_Id", c => c.Int());
            AddColumn("dbo.Comments", "AppUser_Id", c => c.Int());
            AddColumn("dbo.RoomReservations", "AppUser_Id", c => c.Int());
            AlterColumn("dbo.Accommodations", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RoomReservations", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Accommodations", "User_Id");
            CreateIndex("dbo.Accommodations", "AppUser_Id");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "AppUser_Id");
            CreateIndex("dbo.RoomReservations", "User_Id");
            CreateIndex("dbo.RoomReservations", "AppUser_Id");
            AddForeignKey("dbo.Accommodations", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.Comments", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.RoomReservations", "AppUser_Id", "dbo.AppUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomReservations", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Accommodations", "AppUser_Id", "dbo.AppUsers");
            DropIndex("dbo.RoomReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.RoomReservations", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "AppUser_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Accommodations", new[] { "AppUser_Id" });
            DropIndex("dbo.Accommodations", new[] { "User_Id" });
            AlterColumn("dbo.RoomReservations", "User_Id", c => c.Int());
            AlterColumn("dbo.Comments", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Accommodations", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.RoomReservations", "AppUser_Id");
            DropColumn("dbo.Comments", "AppUser_Id");
            DropColumn("dbo.Accommodations", "AppUser_Id");
            CreateIndex("dbo.RoomReservations", "User_Id");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Accommodations", "User_Id");
            AddForeignKey("dbo.RoomReservations", "User_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AppUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Accommodations", "User_Id", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
