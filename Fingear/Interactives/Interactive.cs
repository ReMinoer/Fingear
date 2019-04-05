using System.Collections;
using System.Collections.Generic;
using Diese.Collections;
using Fingear.Interactives.Base;
using Stave;

namespace Fingear.Interactives
{
    public class Interactive : InteractiveComponentBase, ICollection<IControl>
    {
        private readonly List<IControl> _controls;
        private readonly ReadOnlyList<IControl> _readOnlyControls;
        public override IEnumerable<IControl> Controls => _readOnlyControls;

        public Interactive()
        {
            _controls = new List<IControl>();
            _readOnlyControls = new ReadOnlyList<IControl>(_controls);
        }
        
        public void Add(IControl item) => _controls.Add(item);
        public void Clear() => _controls.Clear();
        public bool Contains(IControl item) => _controls.Contains(item);
        public bool Remove(IControl item) => _controls.Remove(item);
        public IEnumerator<IControl> GetEnumerator() => _controls.GetEnumerator();
        
        int ICollection<IControl>.Count => _controls.Count;
        bool ICollection<IControl>.IsReadOnly => false;
        void ICollection<IControl>.CopyTo(IControl[] array, int arrayIndex) => _controls.CopyTo(array, arrayIndex);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}