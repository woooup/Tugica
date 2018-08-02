using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class RoomReservations
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timestamp { get; set; }//kog tipa ovo da bude
        public BAIdentityUser User { get; set; }
        public Room Room { get; set; }
    }
}