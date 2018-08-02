namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Address = c.String(),
                    AvrageGrade = c.Int(nullable: false),
                    Latitude = c.Double(nullable: false),
                    Longitude = c.Double(nullable: false),
                    ImageURL = c.String(),
                    Approved = c.Boolean(nullable: false),
                    AccomodationType_Id = c.Int(),
                    User_Id = c.String(maxLength: 128),
                    Place_Id = c.Int(),
                    AppUser_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccomodationType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Places", t => t.Place_Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AccomodationType_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Place_Id)
                .Index(t => t.AppUser_Id);

            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Grade = c.Int(nullable: false),
                    Text = c.String(),
                    Accomodation_Id = c.Int(),
                    User_Id = c.String(maxLength: 128),
                    AppUser_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Accomodation_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.Accomodation_Id)
                .Index(t => t.User_Id)
                .Index(t => t.AppUser_Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.RoomReservations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StartDate = c.String(),
                    EndDate = c.String(),
                    Timestamp = c.String(),
                    Room_Id = c.Int(),
                    User_Id = c.String(maxLength: 128),
                    AppUser_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.Room_Id)
                .Index(t => t.User_Id)
                .Index(t => t.AppUser_Id);

            CreateTable(
                "dbo.Rooms",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RoomNumber = c.Int(nullable: false),
                    BedCount = c.Int(nullable: false),
                    Description = c.String(),
                    PricePerNight = c.Double(nullable: false),
                    Accomodation_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accommodations", t => t.Accomodation_Id)
                .Index(t => t.Accomodation_Id);

            CreateTable(
                "dbo.Places",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Region_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.Region_Id);

            CreateTable(
                "dbo.Regions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Country_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Code = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AppUsers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FullName = c.String(),
                    Username = c.String(),
                    Email = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RoomReservations", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Accommodations", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Places", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Regions", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Accommodations", "Place_Id", "dbo.Places");
            DropForeignKey("dbo.RoomReservations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RoomReservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Accomodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accommodations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Accomodation_Id", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "AccomodationType_Id", "dbo.AccommodationTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Regions", new[] { "Country_Id" });
            DropIndex("dbo.Places", new[] { "Region_Id" });
            DropIndex("dbo.Rooms", new[] { "Accomodation_Id" });
            DropIndex("dbo.RoomReservations", new[] { "AppUser_Id" });
            DropIndex("dbo.RoomReservations", new[] { "User_Id" });
            DropIndex("dbo.RoomReservations", new[] { "Room_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "AppUser_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Accomodation_Id" });
            DropIndex("dbo.Accommodations", new[] { "AppUser_Id" });
            DropIndex("dbo.Accommodations", new[] { "Place_Id" });
            DropIndex("dbo.Accommodations", new[] { "User_Id" });
            DropIndex("dbo.Accommodations", new[] { "AccomodationType_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Countries");
            DropTable("dbo.Regions");
            DropTable("dbo.Places");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomReservations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.AccommodationTypes");
            DropTable("dbo.Accommodations");
        }
    }
}
