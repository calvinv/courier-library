using Courier.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Calculator.Factory
{
    public class ParcelFactory : IParcelFactory
    {
        private const int _smallDimension = 10;
        private const int _mediumDimension = 50;
        private const int _largeDimension = 100;
        

        public Parcel CreateParcel(Dimensions dimensions)
        {
            if (dimensions.Length < _smallDimension && dimensions.Breadth < _smallDimension && dimensions.Height < _smallDimension)
            {
                return new Parcel(dimensions, ParcelType.Small, 3);
            }
            else if (dimensions.Length < _mediumDimension && dimensions.Breadth < _mediumDimension && dimensions.Height < _mediumDimension)
            {
                return new Parcel(dimensions, ParcelType.Medium, 8);
            }
            else if (dimensions.Length < _largeDimension && dimensions.Breadth < _largeDimension && dimensions.Height < _largeDimension)
            {
                return new Parcel(dimensions, ParcelType.Large, 15);
            }
            else
            {
                return new Parcel(dimensions, ParcelType.ExtraLarge, 25);
            }
        }
    }
}
