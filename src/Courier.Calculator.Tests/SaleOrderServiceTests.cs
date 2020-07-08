using Courier.Calculator.Models;
using Courier.Calculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Courier.Calculator.Tests
{
    public class SaleOrderServiceTests
    {
        IOrderService _orderService;

        public SaleOrderServiceTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public void FourSmallParcelShouldCost9Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Small Parcel, Cost = $3; Small Parcel, Cost = $3; Small Parcel, Cost = $3; Discount = $3; Total Order = $9", printedResult);
        }

        [Fact]
        public void FiveMixedParcelShouldCost73Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 1m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Medium Parcel, Cost = $8; Large Parcel, Cost = $15; Extra Large Parcel, Cost = $25; Extra Large Parcel, Cost = $25; Discount = $3; Total Order = $73", printedResult);
        }

        [Fact]
        public void FiveMixedSpeedyParcelShouldCost146Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 1m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 1m);

            deliveryOrder = _orderService.ApplySpeedyShipping(deliveryOrder);
            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Medium Parcel, Cost = $8; Large Parcel, Cost = $15; Extra Large Parcel, Cost = $25; Extra Large Parcel, Cost = $25; Speedy Shipping Cost = $73; Discount = $3; Total Order = $146", printedResult);
        }

        [Fact]
        public void ThreeMediumParcelShouldCost16Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 3m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 3m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 3m);

            var printedResult = _orderService.PrintOrder(deliveryOrder);

            Assert.Equal("Medium Parcel, Cost = $8; Medium Parcel, Cost = $8; Medium Parcel, Cost = $8; Discount = $8; Total Order = $16", printedResult);
        }

    }
}
