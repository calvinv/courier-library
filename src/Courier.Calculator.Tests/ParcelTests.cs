using Courier.Calculator.Models;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class ParcelTests
    {
        [Fact]
        public void SmallParcelShouldCost3Dollars()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions(9, 9, 9) };

            Assert.Equal(3, parcel.Cost);
        }

        [Fact]
        public void MediumParcelShouldCost3Dollars()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions(49, 49, 49) };

            Assert.Equal(8, parcel.Cost);
        }

        [Fact]
        public void LargeParcelShouldCost3Dollars()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions(99, 99, 99)  };

            Assert.Equal(15, parcel.Cost);
        }

        [Fact]
        public void XLParcelShouldCost3Dollars()
        {
            var parcel = new Parcel() { Dimensions = new Dimensions(100, 100, 100) };

            Assert.Equal(25, parcel.Cost);
        }
    }
}
