using System.Collections.Generic;
using Stave;

namespace Fingear
{
    public interface IControl : IComponent<IControl, IControlParent>
    {
        string Name { get; set; }
        IEnumerable<IInputSource> Sources { get; }
        IEnumerable<IInput> Inputs { get; }
        void Update(float elapsedTime);
        bool IsActive();
    }

    public interface IControl<TValue> : IControl
    {
        bool IsActive(out TValue value);
    }
}