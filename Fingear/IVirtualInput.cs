using Diese;
using Fingear.Utils;

namespace Fingear
{
    public interface IVirtualInput : IInput, IDefaultable
    {
    }

    public interface IVirtualInput<TValue> : IInput<TValue>, IVirtualInput, IDefaultable<TValue>
    {
        new TValue Value { get; set; }
        Range<TValue>? ClampBounds { get; set; }
    }
}