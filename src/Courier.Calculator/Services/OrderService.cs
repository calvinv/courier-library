using Courier.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Courier.Calculator.Services
{
    public class OrderService : IOrderService
    {
        private const int _smallsDiscountNumber = 4;
        private const int _mediumsDiscountNumber = 3;
        private const int _mixedDiscountNumber = 5;

        private const int _smallDimension = 10;
        private const decimal _smallWeight = 1m;

        private const int _mediumDimension = 50;
        private const decimal _mediumWeight = 3m;

        private const int _largeDimension = 100;
        private const decimal _largeWeight = 6m;

        private const decimal _extraLargeWeight = 10m;

        private const decimal _heavyWeight = 50m;

        private const int _heavyParcelExtraChargePerKg = 1;
        private const int _normalParcelOverweightChargePerKg = 2;

        public DeliveryOrder AddParcelToOrder(DeliveryOrder deliveryOrder, int length, int breadth, int height, decimal weight)
        {
            var newParcel = new Parcel()
            {
                Length = length,
                Breadth = breadth,
                Height = height,
                Weight = weight,
                OverweightFee = 0m,
                TotalCost = 0m,
                BaseCost = 0m
            };

            if (weight >= _heavyWeight)
            {
                newParcel.BaseCost = 50;
                if (weight >= _heavyWeight)
                {
                    newParcel.OverweightFee = (weight - _heavyWeight) * _heavyParcelExtraChargePerKg;
                }

                newParcel.TotalCost = newParcel.BaseCost + newParcel.OverweightFee;
                newParcel.Label = "Heavy Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _smallDimension && breadth < _smallDimension && height < _smallDimension)
            {
                newParcel.BaseCost = 3;
                if (weight >= _smallWeight)
                {
                    newParcel.OverweightFee = (weight - _smallWeight) * _normalParcelOverweightChargePerKg;
                }

                newParcel.TotalCost = newParcel.BaseCost + newParcel.OverweightFee;
                newParcel.Label = "Small Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _mediumDimension && breadth < _mediumDimension && height < _mediumDimension)
            {
                newParcel.BaseCost = 8;
                if (weight >= _mediumWeight)
                {
                    newParcel.OverweightFee = (weight - _mediumWeight) * _normalParcelOverweightChargePerKg;
                }

                newParcel.TotalCost = newParcel.BaseCost + newParcel.OverweightFee;
                newParcel.Label = "Medium Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else if (length < _largeDimension && breadth < _largeDimension && height < _largeDimension)
            {
                newParcel.BaseCost = 15;
                if (weight >= _largeWeight)
                {
                    newParcel.OverweightFee = (weight - _largeWeight) * _normalParcelOverweightChargePerKg;
                }
                
                newParcel.TotalCost = newParcel.BaseCost + newParcel.OverweightFee;
                newParcel.Label = "Large Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }
            else
            {
                newParcel.BaseCost = 25;
                if (weight >= _extraLargeWeight)
                {
                    newParcel.OverweightFee = (weight - _extraLargeWeight) * _normalParcelOverweightChargePerKg;
                }

                newParcel.TotalCost = newParcel.BaseCost + newParcel.OverweightFee;
                newParcel.Label = "Extra Large Parcel";
                deliveryOrder.Parcels.Add(newParcel);
            }

            deliveryOrder = CalculateTotalCost(deliveryOrder);

            return deliveryOrder;
        }

        private DeliveryOrder CalculateTotalCost(DeliveryOrder deliveryOrder)
        {
            //var smallParcels = deliveryOrder.Parcels.Where(x => x.Label == "Small Parcel");
            //var mediumParcels = deliveryOrder.Parcels.Where(x => x.Label == "Medium Parcel");
            //var largeParcels = deliveryOrder.Parcels.Where(x => x.Label == "Large Parcel");
            //var extraLargeParcels = deliveryOrder.Parcels.Where(x => x.Label == "Extra LargeParcel");
            //var heavyParcels = deliveryOrder.Parcels.Where(x => x.Label == "Heavy Parcel");

            //deliveryOrder.MultiParcelDiscount = 0;
            //deliveryOrder.BaseCost = deliveryOrder.Parcels.Sum(x => x.TotalCost);
            //var deliveryOrderTotalParcels = deliveryOrder.Parcels;

            //var discountSmalls = (deliveryOrder.Parcels.Count(x => x.Label == "Small Parcel") % _smallsDiscountNumber);
            //deliveryOrderTotalParcels -= (discountSmalls * _smallsDiscountNumber);
            //deliveryOrder.MultiParcelDiscount += (discountSmalls * 3);

            //var discountMediums = (deliveryOrder.Parcels.Count(x => x.Label == "Medium Parcel") % _mediumsDiscountNumber);
            //deliveryOrderTotalParcels -= (discountSmalls * _mediumsDiscountNumber);
            //deliveryOrder.MultiParcelDiscount += (discountSmalls * 8);

            //var discounts = (deliveryOrderTotalParcels % _mediumsDiscountNumber);
            //deliveryOrder.MultiParcelDiscount += (discountSmalls * 8);

            deliveryOrder.BaseCost = deliveryOrder.Parcels.Sum(x => x.TotalCost);

            if (deliveryOrder.SpeedyShipping)
            {
                deliveryOrder.SpeedyShippingCost = deliveryOrder.BaseCost;
            }

            deliveryOrder.TotalCost = deliveryOrder.SpeedyShippingCost + deliveryOrder.BaseCost;
            return deliveryOrder;
        }

        public DeliveryOrder ApplySpeedyShipping(DeliveryOrder deliveryOrder)
        {
            deliveryOrder.SpeedyShipping = true;
            deliveryOrder = CalculateTotalCost(deliveryOrder);

            return deliveryOrder;
        }

        public string PrintOrder(DeliveryOrder deliveryOrder)
        {
            var sb = new StringBuilder();

            foreach (var parcel in deliveryOrder.Parcels)
            {
                sb.Append($"{parcel.Label}, Cost = ${parcel.TotalCost}; ");
            }

            if (deliveryOrder.SpeedyShipping)
            {
                sb.Append($"Speedy Shipping Cost = ${deliveryOrder.SpeedyShippingCost}; ");
            }

            sb.Append($"Total Order = ${deliveryOrder.TotalCost}");

            return sb.ToString();
        }
    }
}
