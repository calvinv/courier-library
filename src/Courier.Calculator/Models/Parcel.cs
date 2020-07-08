namespace Courier.Calculator.Models
{
    public class Parcel
    {        
        public string Label { get; private set; }
        public decimal Cost { get; private set; }
        public Dimensions Dimensions { get; set; }
    }

}
