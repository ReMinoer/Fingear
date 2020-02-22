using System;
using System.Linq;

namespace Fingear.Interactives.Containers
{
    public class InteractiveToggle : InteractiveToggle<IInteractive>
    {
    }

    public class InteractiveToggle<TComponent> : InteractiveComposite<TComponent>
        where TComponent : class, IInteractive
    {
        private TComponent _selectedInteractive;

        public TComponent SelectedInteractive
        {
            get => _selectedInteractive;
            set
            {
                if (_selectedInteractive == value)
                    return;

                if (value != null && !Contains(value))
                    throw new InvalidOperationException();

                _selectedInteractive = value;
                if (_selectedInteractive != null)
                    _selectedInteractive.Enabled = true;

                foreach (TComponent otherInteractive in Components.Where(x => x != _selectedInteractive))
                    otherInteractive.Enabled = false;
            }
        }

        public override void Add(TComponent item)
        {
            base.Add(item);
            
            if (Components.Count == 1)
                SelectedInteractive = item;
            else
                item.Enabled = false;
        }

        public override bool Remove(TComponent item)
        {
            if (!base.Remove(item))
                return false;

            if (item == SelectedInteractive)
                SelectedInteractive = null;

            return true;
        }

        public override void Clear()
        {
            base.Clear();
            SelectedInteractive = null;
        }
    }
}