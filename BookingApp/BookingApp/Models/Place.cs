﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
      //  public List<Accommodation> Accommodations { get; set; }
    }
}