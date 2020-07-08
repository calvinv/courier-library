using Courier.Calculator.Factory;
using Courier.Calculator.Models;
using System.Collections.Generic;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class DeliveryOrderTests
    {
        readonly IParcelFactory _parcelFactory;

        public DeliveryOrderTests()
        {
            _parcelFactory = new ParcelFactory();
        }

        [Fact]
        public void DeliveryOrderOf3SmallParcelsShouldCost9Dollars()
        {
            var smallParcel = _parcelFactory.CreateParcel(new Dimensions(9, 9, 9));
            var threeSmallParcels = new List<Parcel>() { smallParcel, smallParcel, smallParcel };

            var deliveryOrder = new DeliveryOrder(threeSmallParcels);

            Assert.Equal(9, deliveryOrder.TotalCost);
        }        
    }
}
