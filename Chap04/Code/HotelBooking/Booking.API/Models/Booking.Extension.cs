using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Models
{
    public partial class Booking
    {
        public override string ToString()
        {
            return "Booking for " + Guest + "\r\n" +
                "Hotel: " + HotelName + ", Room: " + RoomNb + "\r\n" +
                "From " + StartDate + " till " + EndDate + "\r\n" +
                "Total price: " + Price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Booking other = obj as Booking;
            return (other.Guest.Equals(Guest) && other.StartDate.Equals(StartDate) &&
                other.EndDate.Equals(EndDate) && other.Price.Equals(Price) &&
                other.RoomNb == RoomNb && other.HotelName.Equals(HotelName));
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 43 * hash + (Guest != null ? Guest.GetHashCode() : 0);
            hash = 43 * hash + (StartDate != null ? StartDate.GetHashCode() : 0);
            hash = 43 * hash + (EndDate != null ? EndDate.GetHashCode() : 0);
            hash = 43 * hash + Convert.ToInt32(Price);
            hash = 43 * hash + RoomNb;
            hash = 43 * hash + (HotelName != null ? HotelName.GetHashCode() : 0);
            return hash;
        }
    }
}
