using System.Collections.Generic;
using Fingear.Controls;
using Stave;

namespace Fingear.Interactives
{
    public interface IInteractive : IComponent<IInteractive, IInteractiveContainer>
    {
        bool Enabled { get; set; }
        string Name { get; }
        IEnumerable<IControl> Controls { get; }
        void Update(float elapsedTime);
        void Reset();
    }
}