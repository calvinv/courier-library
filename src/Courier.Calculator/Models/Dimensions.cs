namespace Courier.Calculator.Models
{
    public class Dimensions
    {
        public Dimensions(int length, int breadth, int height)
        {
            Length = length;
            Breadth = breadth;
            Height = height;
        }

        //all dimensions in cm
        public int Length { get; private set; }
        public int Breadth { get; private set; }
        public int Height { get; private set; }
    }

}
