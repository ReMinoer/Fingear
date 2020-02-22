using System;
using System.Linq;
using System.Numerics;
using Fingear.Interactives.Containers;

namespace Fingear.Interactives.Interfaces.Base
{
    public abstract class InteractiveInterfaceCompositeBase : InteractiveComposite<IInteractiveInterface>, IInteractiveInterface
    {
        public void OnCursorMoved(Vector2 cursorPosition) => Propagate(() => OnLocalCursorMoved(cursorPosition), x => x.OnCursorMoved(cursorPosition));
        public IInteractiveInterface OnTouchStarted(Vector2 cursorPosition) => Propagate(() => OnLocalTouchStarted(cursorPosition), x => x.OnTouchStarted(cursorPosition));
        public void OnTouching(Vector2 cursorPosition) => OnLocalTouching(cursorPosition);
        public void OnTouchEnded(Vector2 cursorPosition) => OnLocalTouchEnded(cursorPosition);
        public bool OnDirectionMoved(Vector2 direction) => Propagate(() => OnLocalDirectionMoved(direction), x => x.OnDirectionMoved(direction));
        public bool OnConfirmed() => Propagate(OnLocalConfirmed, x => x.OnConfirmed());
        public bool OnCancelled() => Propagate(OnLocalCancelled, x => x.OnCancelled());
        public bool OnExited() => Propagate(OnLocalExited, x => x.OnExited());

        protected abstract void OnLocalCursorMoved(Vector2 cursorPosition);
        protected abstract IInteractiveInterface OnLocalTouchStarted(Vector2 cursorPosition);
        protected abstract void OnLocalTouching(Vector2 cursorPosition);
        protected abstract void OnLocalTouchEnded(Vector2 cursorPosition);
        protected abstract bool OnLocalDirectionMoved(Vector2 direction);
        protected abstract bool OnLocalConfirmed();
        protected abstract bool OnLocalCancelled();
        protected abstract bool OnLocalExited();

        private void Propagate(Action localHandler, Action<IInteractiveInterface> componentHandler)
        {
            foreach (IInteractiveInterface component in Components)
                componentHandler(component);
            localHandler();
        }

        private bool Propagate(Func<bool> localHandler, Func<IInteractiveInterface, bool> componentHandler)
        {
            return Components.Any(componentHandler) || localHandler();
        }

        private IInteractiveInterface Propagate(Func<IInteractiveInterface> localHandler, Func<IInteractiveInterface, IInteractiveInterface> componentHandler)
        {
            return Components.Select(componentHandler).FirstOrDefault(x => x != null) ?? localHandler();
        }
    }
}