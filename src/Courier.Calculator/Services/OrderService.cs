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
                newParcel.Label = "Small Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _mediumDimension && breadth < _mediumDimension && height < _mediumDimension)
            {
                newParcel.Cost = 8;
                newParcel.ParcelType = ParcelType.Medium;
                newParcel.Label = "Medium Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _largeDimension && breadth < _largeDimension && height < _largeDimension)
            {
                newParcel.Cost = 15;
                newParcel.ParcelType = ParcelType.Large;
                newParcel.Label = "Large Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else
            {
                newParcel.Cost = 25;
                newParcel.ParcelType = ParcelType.ExtraLarge;
                newParcel.Label = "Extra Large Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }

            deliveryOrder.TotalCost = deliveryOrder.Parcels.Sum(x => x.Cost);

            return deliveryOrder;
        }

        public DeliveryOrder ApplySpeedyShipping(DeliveryOrder deliveryOrder)
        {
            throw new NotImplementedException();
        }

        public string PrintOrder(DeliveryOrder deliveryOrder)
        {
            var sb = new StringBuilder();

            foreach (var parcel in deliveryOrder.Parcels)
            {
                sb.Append($"{parcel.Label}, Cost = ${parcel.Cost}; ");
            }

            sb.Append($"Total Order = ${deliveryOrder.TotalCost}");

            return sb.ToString();
        }
    }
}
