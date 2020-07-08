using Courier.Calculator.Models;

namespace Courier.Calculator.Services
{
    public interface IOrderService
    {        
        public string PrintOrder(DeliveryOrder deliveryOrder);
        public decimal GetOrderCost(DeliveryOrder deliveryOrder);        
        public DeliveryOrder AddParcelToOrder(DeliveryOrder deliveryOrder, int Length, int Breadth, int Height);
        
    }
}
