using System.Collections.Generic;
using System.Linq;

namespace Courier.Calculator.Models
{
    public class DeliveryOrder
    {
        public List<Parcel> Parcels { get; set; }
        public decimal TotalCost { get; set; }
    }
}
