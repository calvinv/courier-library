using Courier.Calculator.Models;
using System.Collections.Generic;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class DeliveryOrderTests
    {
        [Fact]
        public void DeliveryOrderOf3SmallParcelsShouldCost9Dollars()
        {
            var threeSmallParcels = new List<Parcel>()
            {
                new Parcel() { Dimensions = new Dimensions(9, 9, 9) },
                new Parcel() { Dimensions = new Dimensions(9, 9, 9) },
                new Parcel() { Dimensions = new Dimensions(9, 9, 9) }
            };

            var deliveryOrder = new DeliveryOrder(threeSmallParcels);


            Assert.Equal(9, deliveryOrder.TotalCost);
        }        
    }
}
