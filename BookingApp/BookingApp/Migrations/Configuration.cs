using BookingApp.Models;

namespace BookingApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingApp.Models.BAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookingApp.Models.BAContext context)
        {




            /****/

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }


            var userStore = new UserStore<BAIdentityUser>(context);
            var userManager = new UserManager<BAIdentityUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "mitja"))
            {
                var user1 = new BAIdentityUser() { Id = "mitja", UserName = "mitja", Email = "mitja@yahoo.com", PasswordHash = BAIdentityUser.HashPassword("mitja") };
                userManager.Create(user1);
                userManager.AddToRole(user1.Id, "Admin");
            }

            BAIdentityUser user = new BAIdentityUser() { Id = "stefan", UserName = "stefan", Email = "stefan@gmail.com", PasswordHash = BAIdentityUser.HashPassword("stefan") };

            if (!context.Users.Any(u => u.UserName == "stefan"))
            {
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "user"))
            {
                var user1 = new BAIdentityUser() { Id = "user", UserName = "user", Email = "user@gmail.com", PasswordHash = BAIdentityUser.HashPassword("user") };
                userManager.Create(user1);
                userManager.AddToRole(user1.Id, "AppUser");
            }

            user.Accomodations = new List<Accommodation>();
            user.Comments = new List<Comment>();
            user.RoomReservations = new List<RoomReservations>();



            var accomod = new Accommodation();
            var accomod2 = new Accommodation();
            var accomods = new List<Accommodation>() { accomod, accomod2 };

            var accomType = new AccommodationType();
            accomType.Name = "Motel";
            // accomType.Accommodations = accomods;

            var accomType2 = new AccommodationType();
            accomType2.Name = "Hotel";
            // accomType2.Accommodations = accomods;

            var place = new Place();
            var place2 = new Place();

            var room = new Room();
            var room2 = new Room();
            var rooms = new List<Room>() { room, room2 };

            var country = new Country();
            country.Name = "Serbia";
            //country.Regions = new List<Region>() { region, region2 };
            country.Code = 43;
            //region.Country = country;

            var country2 = new Country();
            country2.Name = "Serbia";
            //country2.Regions = new List<Region>() { region2 };
            country2.Code = 44;
            //region2.Country = country2;


            var region = new Region();
            region.Name = "Zlatibor";
            region.Country = country;
            //region.Places = new List<Place>() { place, place2 };

            var region2 = new Region();
            region2.Name = "Jahorina";
            region2.Country = country2;
            // region2.Places = new List<Place>() { place, place2 };

            place.Name = "place1";
            place.RegionId = 1;
            //place.Accommodations = new List<Accommodation>() { accomod, accomod2 };

            place2.Name = "place2";
            place2.RegionId = 1;
            //place2.Accommodations = new List<Accommodation>() { accomod, accomod2 };

            accomod.Address = "Jovana Subotica";
            accomod.Approved = true;
            accomod.User = user;
            //accomod.Comments = comments;
            accomod.AvrageGrade = 50;
            accomod.Description = "opisAccom";
            accomod.AccomodationType = accomType;
            accomod.ImageURL = "http://arhiva.alo.rs/resources/img/10-07-2014/single_news/1300330-sako1.jpg";
            accomod.Latitude = 41.9271155;
            accomod.Longitude = 19.2364064;
            accomod.Place = place;
            accomod.Name = "Vila Rijana";
            //accomod.Rooms = rooms;

            accomod2.Address = "Nikole Pasica";
            accomod2.Approved = true;
            accomod2.User = user;
            //accomod2.Comments = comments;
            accomod2.AvrageGrade = 40;
            accomod2.Description = "opisAccom2";
            accomod2.AccomodationType = accomType2;
            accomod2.ImageURL = "https://s-ec.bstatic.com/images/hotel/max1024x768/741/74116567.jpg";
            accomod2.Latitude = 42.286238;
            accomod2.Longitude = 18.8327733;
            accomod2.Place = place2;
            accomod2.Name = "Hotel Moskva";
            //accomod.Rooms = rooms;

            var comment = new Comment() { User = user, Text = "dobar", Grade = 10, Accomodation = accomod };
            var comment2 = new Comment() { User = user, Text = "los", Grade = 2, Accomodation = accomod2 };

            room.Description = "opisSobe1";
            room.PricePerNight = 100;
            room.RoomNumber = 4;
            room.BedCount = 3;
            room.Accomodation = accomod;
            //room.RoomReservations = new List<RoomReservations>() { roomReservations, roomReservations2 };

            room2.Description = "opisSobe12";
            room2.PricePerNight = 97;
            room2.RoomNumber = 6;
            room2.BedCount = 3;
            room2.Accomodation = accomod2;
            //room2.RoomReservations = new List<RoomReservations>() { roomReservations, roomReservations2 };

            var roomReservations = new RoomReservations();
            var roomReservations2 = new RoomReservations();

            roomReservations.Room = room;
            roomReservations.User = user;
            roomReservations.Timestamp = DateTime.Now.ToString();
            roomReservations.StartDate = new DateTime(2017, 1, 1).ToString();
            roomReservations.EndDate = new DateTime(2017, 2, 2).ToString();

            roomReservations2.Room = room2;
            roomReservations2.User = user;
            roomReservations2.Timestamp = DateTime.Now.ToString();
            roomReservations2.StartDate = new DateTime(2017, 3, 3).ToString();
            roomReservations2.EndDate = new DateTime(2017, 4, 4).ToString();

            context.Accommodations.AddOrUpdate(accomod);
            context.Accommodations.AddOrUpdate(accomod2);

            // context.Users
            context.Rooms.AddOrUpdate(room);
            context.Rooms.AddOrUpdate(room2);

            context.RoomReservationss.AddOrUpdate(roomReservations);
            context.RoomReservationss.AddOrUpdate(roomReservations2);

            context.Comments.AddOrUpdate(comment);
            context.Comments.AddOrUpdate(comment2);

            context.SaveChanges();




        }
    }
}
