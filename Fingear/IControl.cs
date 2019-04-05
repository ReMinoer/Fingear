using System.Collections.Generic;
using Stave;

namespace Fingear
{
    public interface IControl : IComponent<IControl, IControlContainer>
    {
        string Name { get; set; }
        IEnumerable<IInput> Inputs { get; }
        void Update(float elapsedTime);
        void Reset();
        bool IsActive();
    }

    public interface IControl<TValue> : IControl
    {
        bool IsActive(out TValue value);
    }
}