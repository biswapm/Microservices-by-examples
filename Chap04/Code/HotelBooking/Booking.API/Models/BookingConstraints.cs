using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Models
{
    public class BookingConstraints
    {

        [Required, DataType(DataType.Date), Display(Name = "Start date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "End date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required, Display(Name = "Maximum price per night")]
        public double MaxPricePerNight { get; set; }
        [Required, Display(Name = "Number of beds")]
        public int NbOfBeds { get; set; }
        [Required, Display(Name = "Smoking allowed")]
        public bool SmokingAllowed { get; set; }

        public override string ToString()
        {
            return "Booking constraints:\r\n" +
                "From " + StartDate + " till " + EndDate + "\r\n" +
                "# beds: " + NbOfBeds + "\t" + (SmokingAllowed ? "Smoking" : "Non-smoking") + "\r\n" +
                "Max price: " + MaxPricePerNight;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            BookingConstraints other = obj as BookingConstraints;
            return (other.StartDate.Equals(StartDate) && other.EndDate.Equals(EndDate) &&
                other.MaxPricePerNight.Equals(MaxPricePerNight) && other.NbOfBeds == NbOfBeds &&
                other.SmokingAllowed == SmokingAllowed);
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 59 * hash + (StartDate != null ? StartDate.GetHashCode() : 0);
            hash = 59 * hash + (EndDate != null ? EndDate.GetHashCode() : 0);
            hash = 59 * hash + Convert.ToInt32(MaxPricePerNight);
            hash = 59 * hash + NbOfBeds;
            hash = 59 * hash + Convert.ToInt32(SmokingAllowed); ;
            return hash;
        }
    }
    public class BookingException : Exception
    {
        public BookingException(string msg)
            : base(msg)
        { }
    }
}

