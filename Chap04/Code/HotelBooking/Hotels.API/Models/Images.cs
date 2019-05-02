using System;
using System.Collections.Generic;

namespace Hotels.API.Models
{
    public partial class Images
    {
        public Images()
        {
            ItemImageRelationships = new HashSet<ItemImageRelationships>();
        }

        public string Id { get; set; }
        public string RoomId { get; set; }
        public string FilePath { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public Rooms Room { get; set; }
        public ICollection<ItemImageRelationships> ItemImageRelationships { get; set; }
    }
}
