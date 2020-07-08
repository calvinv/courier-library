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

            Assert.Equal("Small Parcel, Cost = $5; Speedy Shipping Cost = $5; Total Order = $10", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void OneKgOverSmallParcelShouldCost5Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 2m);

            Assert.Equal("Small Parcel, Cost = $5; Total Order = $5", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void OneKgOverMediumParcelShouldCost10Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 4m);

            Assert.Equal("Medium Parcel, Cost = $10; Total Order = $10", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void OneKgOverLargeParcelShouldCost17Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 7m);

            Assert.Equal("Large Parcel, Cost = $17; Total Order = $17", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void OneKgOverExtraLargeParcelShouldCost27Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 11m);

            Assert.Equal("Extra Large Parcel, Cost = $27; Total Order = $27", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void OneKgOverHeavyParcelShouldCost51Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 120, 120, 120, 51m);

            Assert.Equal("Heavy Parcel, Cost = $51; Total Order = $51", _orderService.PrintOrder(deliveryOrder));
        }
    }
}
