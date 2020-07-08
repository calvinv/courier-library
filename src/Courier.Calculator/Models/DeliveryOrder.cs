using System.Collections.Generic;

namespace Courier.Calculator.Models
{
    public class DeliveryOrder
    {
        public DeliveryOrder(List<Parcel> parcels)
        {
            Parcels = parcels;
        }

        public List<Parcel> Parcels { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
