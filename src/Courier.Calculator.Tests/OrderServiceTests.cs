using Courier.Calculator.Models;
using Courier.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class OrderServiceTests
    {
        IOrderService _orderService;

        public OrderServiceTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public void PrintOrderShouldWriteMultipleItemsOut()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49);

            Assert.Equal("Small Parcel, Cost = $3; Medium Parcel, Cost = $8; Total Order = $11", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void SpeedyShippingOrdersShouldDoubleInCost()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);
            deliveryOrder = _orderService.ApplySpeedyShipping(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Total Order = $6", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void SmallParcelShouldCost3Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal("Small Parcel, Cost = $3; Total Order = $3", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void MediumParcelShouldCost8Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49);

            Assert.Equal("Medium Parcel, Cost = $8; Total Order = $8", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void LargeParcelShouldCost15Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99);

            Assert.Equal("Large Parcel, Cost = $15; Total Order = $15", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void ExtraLargeParcelShouldCost25Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100);

            Assert.Equal("Extra Large Parcel, Cost = $25; Total Order = $25", _orderService.PrintOrder(deliveryOrder));
        }
    }
}
