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

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 0.9m);
            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 0.9m);

            Assert.Equal("Small Parcel, Cost = $3; Medium Parcel, Cost = $8; Total Order = $11", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void SpeedyShippingOrdersShouldDoubleInCost()
        {

            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 0.9m);
            deliveryOrder = _orderService.ApplySpeedyShipping(deliveryOrder);

            Assert.Equal("Small Parcel, Cost = $3; Speedy Shipping Cost = $3; Total Order = $6", _orderService.PrintOrder(deliveryOrder));
        }

        #region Under Weight Parcel Tests
        [Fact]
        public void SmallParcelShouldCost3Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 9, 9, 9, 0.9m);

            Assert.Equal("Small Parcel, Cost = $3; Total Order = $3", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void MediumParcelShouldCost8Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 49, 49, 49, 2.9m);

            Assert.Equal("Medium Parcel, Cost = $8; Total Order = $8", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void LargeParcelShouldCost15Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 99, 99, 99, 5.9m);

            Assert.Equal("Large Parcel, Cost = $15; Total Order = $15", _orderService.PrintOrder(deliveryOrder));
        }

        [Fact]
        public void ExtraLargeParcelShouldCost25Dollars()
        {
            var deliveryOrder = new DeliveryOrder();

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 9.9m);

            Assert.Equal("Extra Large Parcel, Cost = $25; Total Order = $25", _orderService.PrintOrder(deliveryOrder));
        }
        #endregion 

        #region Heavy Parcel Tests
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

            deliveryOrder = _orderService.AddParcelToOrder(deliveryOrder, 100, 100, 100, 51m);

            Assert.Equal("Heavy Parcel, Cost = $51; Total Order = 51", _orderService.PrintOrder(deliveryOrder));
        }
        #endregion
    }
}
