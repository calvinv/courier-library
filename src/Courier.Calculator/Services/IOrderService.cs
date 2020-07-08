using Courier.Calculator.Models;

namespace Courier.Calculator.Services
{
    public interface IOrderService
    {
        public DeliveryOrder ApplySpeedShipping(DeliveryOrder deliveryOrder);
        public string PrintOrder(DeliveryOrder deliveryOrder);
        public DeliveryOrder AddParcelToOrder(DeliveryOrder deliveryOrder, int length, int breadth, int height);
        
    }
}
