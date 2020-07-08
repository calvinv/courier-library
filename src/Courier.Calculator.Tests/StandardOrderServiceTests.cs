using Courier.Calculator.Models;
using Courier.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class StandardOrderServiceTests
    {
        IOrderService _orderService;

        public StandardOrderServiceTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public void PrintOrderShouldWriteMultipleItemsOut()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 1m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Medium Parcel, Cost = $8; Total Order = $11", printedResult);
        }

        [Fact]
        public void SpeedyShippingOrdersShouldDoubleInCost()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.ApplySpeedyShipping(deliveryOrder);
            
            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Speedy Shipping Cost = $3; Total Order = $6", printedResult);
        }

        [Fact]
        public void SmallParcelShouldCost3Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Total Order = $3", printedResult);
        }

        [Fact]
        public void MediumParcelShouldCost8Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 3m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Medium Parcel, Cost = $8; Total Order = $8", printedResult);
        }

        [Fact]
        public void LargeParcelShouldCost15Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 6m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Large Parcel, Cost = $15; Total Order = $15", printedResult);
        }

        [Fact]
        public void ExtraLargeParcelShouldCost25Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 10m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Extra Large Parcel, Cost = $25; Total Order = $25", printedResult);
        }
    }
}
