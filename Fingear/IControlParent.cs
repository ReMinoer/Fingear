using Stave;

namespace Fingear
{
    public interface IControlParent : IParent<IControl, IControlParent>, IControl
    {
    }

    public interface IControlParent<TValue> : IControlParent, IControl<TValue>
    {
    }
}