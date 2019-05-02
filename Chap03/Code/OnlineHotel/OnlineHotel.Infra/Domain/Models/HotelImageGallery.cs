using System;
using System.Collections.Generic;

namespace OnlineHotel.Infra.Domain.Models
{
    public partial class HotelImageGallery
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public int? HotelId { get; set; }

        public Hotels Hotel { get; set; }
    }
}
