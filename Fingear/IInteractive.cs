using System.Collections.Generic;
using Stave;

namespace Fingear
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