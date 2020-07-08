using System.Collections.Generic;
using System.Linq;

namespace Courier.Calculator.Models
{
    public class DeliveryOrder
    {
        public DeliveryOrder(List<Parcel> parcels)
        {
            Parcels = parcels;

            TotalCost = parcels.Sum(x => x.Cost);
        }

        public List<Parcel> Parcels { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
