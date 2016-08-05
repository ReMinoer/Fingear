using System.Collections.Generic;
using Stave;

namespace Fingear
{
    public interface IControl : IComponent<IControl, IControlParent>
    {
        IInputSource Source { get; }
        IEnumerable<IInput> Inputs { get; }
        void Update(float elapsedTime);
        bool IsTriggered();
    }

    public interface IControl<TValue> : IControl
    {
        bool IsTriggered(out TValue value);
    }
}