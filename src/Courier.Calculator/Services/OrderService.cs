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
            deliveryOrder.MultiParcelDiscount = 0;

            var smallParcels = deliveryOrder.Parcels.Where(x => x.Label == "Small Parcel").OrderBy(x => x.TotalCost);
            var mediumParcels = deliveryOrder.Parcels.Where(x => x.Label == "Medium Parcel").OrderBy(x => x.TotalCost);
            var largeParcels = deliveryOrder.Parcels.Where(x => x.Label == "Large Parcel").OrderBy(x => x.TotalCost);
            var extraLargeParcels = deliveryOrder.Parcels.Where(x => x.Label == "Extra Large Parcel").OrderBy(x => x.TotalCost);
            var heavyParcels = deliveryOrder.Parcels.Where(x => x.Label == "Heavy Parcel").OrderBy(x => x.TotalCost);

            var discountSmalls = smallParcels.Count() / _smallsDiscountNumber;
            var smallsRemaining = smallParcels.Count() % _smallsDiscountNumber;
            deliveryOrder.MultiParcelDiscount += smallParcels.Take(discountSmalls).Sum(x => x.TotalCost);
            var leftOverSmallParcels = smallParcels.Skip(discountSmalls).Take(smallsRemaining);

            var discountMediums = mediumParcels.Count() / _mediumsDiscountNumber;
            var mediumsRemaining = mediumParcels.Count() % _mediumsDiscountNumber;
            deliveryOrder.MultiParcelDiscount += mediumParcels.Take(discountMediums).Sum(x => x.TotalCost);            
            var leftOverMediumParcels = mediumParcels.Skip(discountMediums).Take(mediumsRemaining);

            var leftOverParcels = new List<Parcel>();
            leftOverParcels.AddRange(leftOverSmallParcels);
            leftOverParcels.AddRange(leftOverMediumParcels);
            leftOverParcels.AddRange(largeParcels);
            leftOverParcels.AddRange(extraLargeParcels);
            leftOverParcels.AddRange(heavyParcels);

            var orderedLeftOverParcels = leftOverParcels.OrderBy(x => x.TotalCost);
            var discountLeftOvers = orderedLeftOverParcels.Count() / _mixedDiscountNumber;
            deliveryOrder.MultiParcelDiscount += orderedLeftOverParcels.Take(discountLeftOvers).Sum(x => x.TotalCost);


            deliveryOrder.BaseCost = deliveryOrder.Parcels.Sum(x => x.TotalCost);            

            if (deliveryOrder.SpeedyShipping)
            {
                deliveryOrder.SpeedyShippingCost = (deliveryOrder.BaseCost - deliveryOrder.MultiParcelDiscount);
            }

            deliveryOrder.TotalCost = deliveryOrder.SpeedyShippingCost + deliveryOrder.BaseCost - deliveryOrder.MultiParcelDiscount;
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

            if (deliveryOrder.MultiParcelDiscount > 0)
            {
                sb.Append($"Discount = ${deliveryOrder.MultiParcelDiscount}; ");
            }

            sb.Append($"Total Order = ${deliveryOrder.TotalCost}");

            return sb.ToString();
        }
    }
}
