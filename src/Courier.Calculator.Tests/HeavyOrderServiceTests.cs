using Courier.Calculator.Models;
using Courier.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class HeavyOrderServiceTests
    {
        IOrderService _orderService;

        public HeavyOrderServiceTests()
        {
            _orderService = new OrderService();
        }


        [Fact]
        public void HeavySpeedyShippingOrdersShouldDoubleInCost()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 2m);
            deliveryOrder = _orderService.ApplySpeedyShipping(deliveryOrder);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $5; Speedy Shipping Cost = $5; Total Order = $10", printedResult);
        }

        [Fact]
        public void OneKgOverSmallParcelShouldCost5Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 2m);
            
            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $5; Total Order = $5", printedResult);
        }

        [Fact]
        public void OneKgOverMediumParcelShouldCost10Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 4m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Medium Parcel, Cost = $10; Total Order = $10", printedResult);
        }

        [Fact]
        public void OneKgOverLargeParcelShouldCost17Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 7m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Large Parcel, Cost = $17; Total Order = $17", printedResult);
        }

        [Fact]
        public void OneKgOverExtraLargeParcelShouldCost27Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 11m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Extra Large Parcel, Cost = $27; Total Order = $27", printedResult);
        }

        [Fact]
        public void OneKgOverHeavyParcelShouldCost51Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 120, 120, 120, 51m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Heavy Parcel, Cost = $51; Total Order = $51", printedResult);
        }
    }
}
