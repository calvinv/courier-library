using Courier.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Courier.Calculator.Services
{
    public class OrderService : IOrderService
    {
        private const int _smallDimension = 10;
        private const int _mediumDimension = 50;
        private const int _largeDimension = 100;

        public DeliveryOrder AddParcelToOrder(DeliveryOrder deliveryOrder, int length, int breadth, int height)
        {
            if (length < _smallDimension && breadth < _smallDimension && height < _smallDimension)
            {
                deliveryOrder.Parcels.Add(new Parcel()
                {
                    Length = length,
                    Breadth = breadth,
                    Height = height,
                    ParcelType = ParcelType.Small, 
                    Cost = 3 });
            }

            deliveryOrder.TotalCost = deliveryOrder.Parcels.Sum(x => x.Cost);

            return deliveryOrder;
        }

        public string PrintOrder(DeliveryOrder deliveryOrder)
        {
            throw new NotImplementedException();
        }
    }
}
