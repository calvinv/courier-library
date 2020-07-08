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
        public void PrintOrderShouldWriteItemsOut()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal("Small Parcel, Cost = $3; Total Order = $3", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void SmallParcelShouldCost3Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal(3, deliveryOrder.TotalCost);
        }

        [Fact]
        public void MediumParcelShouldCost8Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal(8, deliveryOrder.TotalCost);
        }

        [Fact]
        public void LargeParcelShouldCost15Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal(15, deliveryOrder.TotalCost);
        }

        [Fact]
        public void XLParcelShouldCost25Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9);

            Assert.Equal(25, deliveryOrder.TotalCost);
        }
    }
}
