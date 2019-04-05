using System.Collections;
using System.Collections.Generic;
using Stave;

namespace Fingear.Interactives.Base
{
    public abstract class InteractiveBase : IInteractive
    {
        public string Name { get; set; }
        public abstract IEnumerable<IControl> Controls { get; }
        
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
                    Update(0f);
                else
                    Reset();
            }
        }

        public void Update(float elapsedTime)
        {
            if (!Enabled)
                return;

            UpdateEnabled(elapsedTime);
        }

        protected abstract void UpdateEnabled(float elapsedTime);
        public abstract void Reset();

        protected abstract IComponent<IInteractive, IInteractiveContainer> ComponentImplementation { get; }
        
        public IInteractiveContainer Parent
        {
            get => ComponentImplementation.Parent;
            set => ComponentImplementation.Parent = value;
        }
        
        IEnumerable<IInteractive> IComponent<IInteractive>.Components => ComponentImplementation.Components;
        IEnumerable IComponent.Components => ((IComponent)ComponentImplementation).Components;
        IInteractive IComponent<IInteractive>.Parent => ((IComponent<IInteractive>)ComponentImplementation).Parent;
        IComponent IComponent.Parent => ((IComponent)ComponentImplementation).Parent;
    }
}