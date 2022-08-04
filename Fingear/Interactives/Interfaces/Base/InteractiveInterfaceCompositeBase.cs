using System;
using System.Linq;
using System.Numerics;
using Fingear.Interactives.Containers;

namespace Fingear.Interactives.Interfaces.Base
{
    public abstract class InteractiveInterfaceCompositeBase<TComponent> : InteractiveComposite<TComponent>, IInteractiveInterface<TComponent>
        where TComponent : class, IInteractiveInterface<TComponent>
    {
        public void OnCursorMoved(Vector2 cursorPosition) => Propagate(() => OnLocalCursorMoved(cursorPosition), x => x.OnCursorMoved(cursorPosition));
        public TComponent OnCursorHovering(Vector2 cursorPosition) => Propagate(() => OnLocalCursorHovering(cursorPosition), x => x.OnCursorHovering(cursorPosition));
        public TComponent OnTouchStarted(Vector2 cursorPosition) => Propagate(() => OnLocalTouchStarted(cursorPosition), x => x.OnTouchStarted(cursorPosition));
        public void OnTouching(Vector2 cursorPosition) => OnLocalTouching(cursorPosition);
        public void OnTouchEnded(Vector2 cursorPosition) => OnLocalTouchEnded(cursorPosition);
        public bool OnDirectionMoved(Vector2 direction) => Propagate(() => OnLocalDirectionMoved(direction), x => x.OnDirectionMoved(direction));
        public bool OnConfirmed() => Propagate(OnLocalConfirmed, x => x.OnConfirmed());
        public bool OnCancelled() => Propagate(OnLocalCancelled, x => x.OnCancelled());
        public bool OnExited() => Propagate(OnLocalExited, x => x.OnExited());

        IInteractiveInterface IInteractiveInterface.OnCursorHovering(Vector2 cursorPosition) => OnCursorHovering(cursorPosition);
        IInteractiveInterface IInteractiveInterface.OnTouchStarted(Vector2 cursorPosition) => OnTouchStarted(cursorPosition);

        protected abstract void OnLocalCursorMoved(Vector2 cursorPosition);
        protected abstract TComponent OnLocalCursorHovering(Vector2 cursorPosition);
        protected abstract TComponent OnLocalTouchStarted(Vector2 cursorPosition);
        protected abstract void OnLocalTouching(Vector2 cursorPosition);
        protected abstract void OnLocalTouchEnded(Vector2 cursorPosition);
        protected abstract bool OnLocalDirectionMoved(Vector2 direction);
        protected abstract bool OnLocalConfirmed();
        protected abstract bool OnLocalCancelled();
        protected abstract bool OnLocalExited();

        private void Propagate(Action localHandler, Action<TComponent> componentHandler)
        {
            foreach (TComponent component in Components)
                componentHandler(component);
            localHandler();
        }

        private bool Propagate(Func<bool> localHandler, Func<TComponent, bool> componentHandler)
        {
            return Components.Any(componentHandler) || localHandler();
        }

        private TComponent Propagate(Func<TComponent> localHandler, Func<TComponent, TComponent> componentHandler)
        {
            return Components.Select(componentHandler).FirstOrDefault(x => x != null) ?? localHandler();
        }
    }
}