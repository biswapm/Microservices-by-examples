﻿using System;
using System.Collections.Generic;

namespace Hotels.API.Models
{
    public partial class HotelAddress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int? HotelId { get; set; }

        public HotelsInfo Hotel { get; set; }
    }
}
