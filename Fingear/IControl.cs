using System.Collections.Generic;
using Stave;

namespace Fingear
{
    public interface IControl : IComponent<IControl, IControlContainer>
    {
        string Name { get; set; }
        IEnumerable<IInput> Inputs { get; }
        bool Handled { get; }
        ControlLayer Layer { get; set; }
        void Update(float elapsedTime);
        void Reset();
        bool IsActive();
        void HandleControl();
        void HandleInputs();
    }

    public interface IControl<TValue> : IControl
    {
        bool IsActive(out TValue value);
    }
}