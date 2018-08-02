using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using BookingApp.Models;
using BookingApp.DbHelper;

[assembly: OwinStartup(typeof(BookingApp.Startup))]

namespace BookingApp
{
    public partial class Startup
    {
        private BAContext db = new BAContext();
        public void Configuration(IAppBuilder app)
        {
            //DataBaseHelper dbHelper = new DataBaseHelper();

            ConfigureAuth(app);
         

            setDatabase();
        }


        private void setDatabase()
        {
            var user = new BAIdentityUser();
            user.UserName = "admin";
            user.PasswordHash = BAIdentityUser.HashPassword("admin");
            user.Email = "admin@gmail.com";
            

            var user2 = new BAIdentityUser();
            user2.UserName = "appU";
            user2.PasswordHash = BAIdentityUser.HashPassword("appU");
            user2.Email = "appU@gmail.com";
            

            var accomod = new Accommodation();
            var accomod2 = new Accommodation();
            var accomods = new List<Accommodation>() { accomod, accomod2 };

            var accomType = new AccommodationType();
            accomType.Name = "Motel";
        //    accomType.Accommodations = accomods;

            var accomType2 = new AccommodationType();
            accomType2.Name = "Hotel";
          //  accomType2.Accommodations = accomods;
            

            var place = new Place();
            var place2 = new Place();

            var room = new Room();
            var room2 = new Room();
            var rooms = new List<Room>() { room, room2 };

            var country = new Country();
            country.Name = "Serbia";

            country.Code = 43;
           

            var country2 = new Country();
            country2.Name = "Serbia";
            country2.Code = 44;
            


            var region = new Region();
            region.Name = "Zlatibor";
            region.Country = country;
            region.Places = new List<Place>() { place, place2 };
         

            var region2 = new Region();
            region2.Name = "Jahorina";
            region2.Country = country2;
            region2.Places = new List<Place>() { place, place2 };
            country2.Regions = new List<Region>() { region2 };
            country.Regions = new List<Region>() { region, region2 };

            place.Name = "place1";
            place.RegionId = 1;
            //  place.Accommodations = new List<Accommodation>() { accomod, accomod2 };

            place2.Name = "place2";
            place2.RegionId = 1;

            accomod.Id = 1; 
            accomod.Address = "Jovana Subotica";
            accomod.Name = "accomod1";
            accomod.Approved = true;
            accomod.User = user;
         
            accomod.AvrageGrade = 50;
            accomod.Description = "opisAccom";
            accomod.AccomodationType = accomType;
            accomod.ImageURL = "https://images.pexels.com/photos/164595/pexels-photo-164595.jpeg?auto=compress&cs=tinysrgb&h=350";
            accomod.Latitude = 49;
            accomod.Longitude = 19;
            accomod.Place = place;
            accomod.Rooms = rooms;

            accomod2.Id = 2;
            accomod2.Address = "Nikole Pasica";
            accomod2.Name = "accomod2";
            accomod2.Approved = true;
            accomod2.User = user2;
     
            accomod2.AvrageGrade = 40;
            accomod2.Description = "opisAccom2";
            accomod2.AccomodationType = accomType2;
            accomod2.ImageURL = "https://www.rd.com/wp-content/uploads/2017/11/Here%E2%80%99s-What-You-Can-and-Can%E2%80%99t-Steal-from-Your-Hotel-Room_363678794-Elnur-760x506.jpg";
            accomod2.Latitude = 56.43;
            accomod2.Longitude = 10.39;
            accomod2.Place = place2;
          //  place.Accommodations = new List<Accommodation>() { accomod, accomod2 };
          //  place2.Accommodations = new List<Accommodation>() { accomod, accomod2 };

            var comment = new Comment() { User = user, Text = "dobar", Grade = 10, Accomodation = accomod };
            var comment2 = new Comment() { User = user2, Text = "los", Grade = 2, Accomodation = accomod2 };
            accomod.Comments = new List<Comment> { comment};
            accomod2.Comments = new List<Comment> { comment };
            room.Description = "opisSobe1";
            room.PricePerNight = 100;
            room.RoomNumber = 4;
            room.BedCount = 3;
            room.Accomodation = accomod;
         

            room2.Description = "opisSobe12";
            room2.PricePerNight = 97;
            room2.RoomNumber = 6;
            room2.BedCount = 3;
            room2.Accomodation = accomod2;

            accomod.Rooms = rooms;

            var roomReservations = new RoomReservations();
            var roomReservations2 = new RoomReservations();

            roomReservations.Room = room;
            roomReservations.User = user;
            roomReservations.Timestamp = "5";
            roomReservations.StartDate = "Danas";
            roomReservations.EndDate = "Sutra";

            roomReservations2.Room = room2;
            roomReservations2.User = user2;
            roomReservations2.Timestamp = "8";
            roomReservations2.StartDate = "Danas";
            roomReservations2.EndDate = "Prekosutra";

            room.RoomReservations = new List<RoomReservations> { roomReservations };
            room2.RoomReservations = new List<RoomReservations> { roomReservations2 };

            HelperJebeni.accomodations = new List<Accommodation>();
            HelperJebeni.accomodations.Add(accomod);
            HelperJebeni.accomodations.Add(accomod2);

            

        }

    }
}
