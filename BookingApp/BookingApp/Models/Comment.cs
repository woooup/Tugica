﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Text { get; set; }
        public BAIdentityUser User { get; set; }
        public Accommodation Accomodation { get; set; }
    }
}