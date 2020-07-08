using Courier.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Courier.Calculator.Services
{
    public class OrderService : IOrderService
    {
        private const int _smallDimension = 10;
        private const int _mediumDimension = 50;
        private const int _largeDimension = 100;

        private DeliveryOrder _deliveryOrder;

        public OrderService()
        {
            _deliveryOrder = new DeliveryOrder();
        }

        public DeliveryOrder AddParcelToOrder(DeliveryOrder deliveryOrder, int Length, int Breadth, int Height)
        {
            throw new NotImplementedException();
        }

        public decimal GetOrderCost(DeliveryOrder deliveryOrder)
        {
            throw new NotImplementedException();
        }

        public string PrintOrder(DeliveryOrder deliveryOrder)
        {
            throw new NotImplementedException();
        }

        //public void AddParcelToOrder(Dimensions dimensions)
        //{
        //    if (dimensions.Length < _smallDimension && dimensions.Breadth < _smallDimension && dimensions.Height < _smallDimension)
        //    {
        //        _deliveryOrder.Parcels.Add(new Parcel(dimensions, ParcelType.Small, 3));
        //    }
        //    else if (dimensions.Length < _mediumDimension && dimensions.Breadth < _mediumDimension && dimensions.Height < _mediumDimension)
        //    {
        //        _deliveryOrder.Parcels.Add(new Parcel(dimensions, ParcelType.Medium, 8));
        //    }
        //    else if (dimensions.Length < _largeDimension && dimensions.Breadth < _largeDimension && dimensions.Height < _largeDimension)
        //    {
        //        _deliveryOrder.Parcels.Add(new Parcel(dimensions, ParcelType.Large, 15));
        //    }
        //    else
        //    {
        //        _deliveryOrder.Parcels.Add(new Parcel(dimensions, ParcelType.ExtraLarge, 25));
        //    }
        //}

    }
}
