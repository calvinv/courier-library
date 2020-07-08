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
            var newParcel = new Parcel()
            {
                Length = length,
                Breadth = breadth,
                Height = height,
            };

            if (length < _smallDimension && breadth < _smallDimension && height < _smallDimension)
            {
                newParcel.Cost = 3;
                newParcel.ParcelType = ParcelType.Small;
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _mediumDimension && breadth < _mediumDimension && height < _mediumDimension)
            {
                newParcel.Cost = 8;
                newParcel.ParcelType = ParcelType.Medium;
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _largeDimension && breadth < _largeDimension && height < _largeDimension)
            {
                newParcel.Cost = 15;
                newParcel.ParcelType = ParcelType.Large;
                deliveryOrder.Parcels.Add(newParcel);
            }
            else
            {
                newParcel.Cost = 25;
                newParcel.ParcelType = ParcelType.ExtraLarge;
                deliveryOrder.Parcels.Add(newParcel);
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
