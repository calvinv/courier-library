using System.Net.Security;

namespace Courier.Calculator.Models
{
    public class Parcel
    {
        public ParcelType ParcelType { get; set; }
        public string Label { get; set; }
        public decimal Cost { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
    }

}
