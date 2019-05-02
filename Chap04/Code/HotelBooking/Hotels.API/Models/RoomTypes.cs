using System;
using System.Collections.Generic;

namespace Hotels.API.Models
{
    public partial class RoomTypes
    {
        public RoomTypes()
        {
            Rooms = new HashSet<Rooms>();
        }

        public string Id { get; set; }
        public decimal BasePrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public ICollection<Rooms> Rooms { get; set; }
    }
}
