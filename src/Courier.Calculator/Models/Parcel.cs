using System.Net.Security;

namespace Courier.Calculator.Models
{
    public class Parcel
    {
        public Parcel(Dimensions dimensions, ParcelType parcelType, decimal cost)
        {
            Dimensions = dimensions;
            ParcelType = parcelType;
            Cost = cost;
        }

        public ParcelType ParcelType { get; private set; }
        public decimal Cost { get; private set; }
        public Dimensions Dimensions { get; set; }
    }

}
