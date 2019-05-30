using System.Collections;
using System.Collections.Generic;
using Diese.Collections;
using Fingear.Interactives.Base;
using Stave;

namespace Fingear.Interactives
{
    public class Interactive : InteractiveComponentBase
    {
        public List<IControl> Controls { get; }
        private readonly ReadOnlyList<IControl> _readOnlyControls;
        protected override IEnumerable<IControl> ReadOnlyControls => _readOnlyControls;

        public Interactive()
        {
            Controls = new List<IControl>();
            _readOnlyControls = new ReadOnlyList<IControl>(Controls);
        }
    }
}