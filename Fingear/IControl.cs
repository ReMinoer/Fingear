using System.Collections.Generic;
using Stave;

namespace Fingear
{
    public interface IControl : IComponent<IControl, IControlContainer>
    {
        string Name { get; set; }
        IEnumerable<IInput> Inputs { get; }
        IEnumerable<IInput> BaseInputs { get; }
        bool IsActive { get; }
        void Update(float elapsedTime);
        void Reset();
    }

    public interface IControl<TValue> : IControl
    {
        new bool IsActive(out TValue value);
    }
}