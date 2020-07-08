using System.Net.Security;

namespace Courier.Calculator.Models
{
    public class Parcel
    {
        public string Label { get; set; }
        public decimal TotalCost { get; set; }
        public decimal BaseCost { get; set; }
        public decimal OverweightFee { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
    }

}
