using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BookingApp.Models;

namespace BookingApp.DbHelper
{
    public class DataBaseHelper
    {

        private BAContext db = new BAContext();
        private List<Accommodation> accomodationList = new List<Accommodation>();
        private List<AccommodationType> accomodationTypeList = new List<AccommodationType>();
        private List<Comment> commentList = new List<Comment>();
        private List<Country> countryList = new List<Country>();
        private List<Place> placeList = new List<Place>();
        private List<Region> regionList = new List<Region>();
        private List<Room> roomList = new List<Room>();
        private List<RoomReservations> reservationList = new List<RoomReservations>();

        public DataBaseHelper()
        {
            this.db = new BAContext();
            this.accomodationList = new List<Accommodation>(this.db.Accommodations);
            this.accomodationTypeList = new List<AccommodationType>(this.db.AccommodationTypes);
            this.commentList = new List<Comment>(this.db.Comments);
            this.countryList = new List<Country>(this.db.Countrys);
            this.placeList = new List<Place>(this.db.Places);
            this.regionList = new List<Region>(this.db.Regions);
            this.roomList = new List<Room>(this.db.Rooms);
            this.reservationList = new List<RoomReservations>(this.db.RoomReservationss);
        }


        private void populateDB()
        {
        }

        #region Getters and setters

        public List<Accommodation> AccomodationList
        {
            get
            {
                return accomodationList;
            }

            set
            {
                accomodationList = value;
            }
        }

        public List<AccommodationType> AccomodationTypeList
        {
            get
            {
                return accomodationTypeList;
            }

            set
            {
                accomodationTypeList = value;
            }
        }

        public List<Comment> CommentList
        {
            get
            {
                return commentList;
            }

            set
            {
                commentList = value;
            }
        }

        public List<Country> CountryList
        {
            get
            {
                return countryList;
            }

            set
            {
                countryList = value;
            }
        }

        public List<Place> PlaceList
        {
            get
            {
                return placeList;
            }

            set
            {
                placeList = value;
            }
        }

        public List<Region> RegionList
        {
            get
            {
                return regionList;
            }

            set
            {
                regionList = value;
            }
        }

        public List<Room> RoomList
        {
            get
            {
                return roomList;
            }

            set
            {
                roomList = value;
            }
        }

        public List<RoomReservations> ReservationList
        {
            get
            {
                return reservationList;
            }

            set
            {
                reservationList = value;
            }
        } 
        #endregion
    }
}