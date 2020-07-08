using Courier.Calculator.Models;

namespace Courier.Calculator.Factory
{
    public interface IParcelFactory
    {
        Parcel CreateParcel(Dimensions dimensions);
    }
}