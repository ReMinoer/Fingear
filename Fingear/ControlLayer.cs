using System.Collections;
using System.Collections.Generic;
using Diese.Collections;

namespace Fingear
{
    public class ControlLayer : IControlLayer
    {
        private readonly Tracker<IControl> _tracker = new Tracker<IControl>();
        private bool _enabled = true;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value)
                    return;

                _enabled = value;
                
                if (Enabled)
                {
                    foreach (IControl control in _tracker)
                        control.Update(0f);
                }
                else
                {
                    foreach (IControl control in _tracker)
                        control.Reset();
                }
            }
        }

        public string Name { get; set; }
        public ICollection<object> Tags { get; } = new List<object>();
        public int Count => _tracker.Count;

        public ControlLayer()
        {
        }

        public ControlLayer(string name, IEnumerable<object> tags = null)
        {
            Name = name;
            if (tags != null)
                Tags.AddMany(tags);
        }

        public ControlLayer(string name, params object[] tags)
        {
            Name = name;
            Tags.AddMany(tags);
        }

        public void Register(IControl item)
        {
            if (Contains(item))
                return;

            _tracker.Register(item);
            if (item.Layer != this)
                item.Layer = this;
        }

        public bool Unregister(IControl item)
        {
            if (!_tracker.Unregister(item))
                return false;

            if (item.Layer != null)
                item.Layer = null;

            return true;
        }

        public void Clear() => _tracker.Clear();
        public void ClearDisposed() => _tracker.ClearDisposed();
        public bool Contains(IControl item) => _tracker.Contains(item);
        public IEnumerator<IControl> GetEnumerator() => _tracker.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_tracker).GetEnumerator();
    }
}