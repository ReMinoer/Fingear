using System.Collections.Generic;
using System.Numerics;
using Fingear.Controls;
using Fingear.Inputs;
using Fingear.Interactives.Interfaces.Base;

namespace Fingear.Interactives.Interfaces
{
    public class InteractiveInterfaceRoot : InteractiveInterfaceCompositeBase
    {
        private IInteractiveInterface _touchHandler;

        public IControl<Vector2> Cursor { get; set; }
        public IControl<InputActivity> Touch { get; set; }

        public IControl<Vector2> Direction { get; set; }
        public IControl Confirm { get; set; }
        public IControl Cancel { get; set; }
        public IControl Exit { get; set; }

        protected override IEnumerable<IControl> ReadOnlyControls
        {
            get
            {
                yield return Cursor;
                yield return Touch;
                yield return Direction;
                yield return Confirm;
                yield return Cancel;
                yield return Exit;
            }
        }

        protected override void UpdateEnabled(float elapsedTime)
        {
            // Do not call base.UpdateEnabled(elapsedTime);

            foreach (IControl control in ReadOnlyControls)
                control.Update(elapsedTime);

            bool cursorMoved = Cursor.IsActive(out Vector2 cursor);
            if (cursorMoved)
                OnCursorMoved(cursor);
            if (Direction.IsActive(out Vector2 direction))
                OnDirectionMoved(direction);

            if (Confirm.IsActive)
                OnConfirmed();
            if (Cancel.IsActive)
                OnCancelled();
            if (Exit.IsActive)
                OnExited();

            if (Touch.IsActive(out InputActivity touch))
            {
                if (touch.IsTriggered())
                    _touchHandler = OnTouchStarted(cursor);
                else if (touch.IsPressed())
                    _touchHandler.OnTouching(cursor);
                else if (touch.IsReleased())
                    _touchHandler.OnTouchEnded(cursor);
            }
            else
                _touchHandler = null;
        }

        public override void Reset()
        {
            foreach (IControl control in ReadOnlyControls)
                control.Reset();
        }

        protected override void OnLocalCursorMoved(Vector2 cursorPosition) {}
        protected override IInteractiveInterface OnLocalTouchStarted(Vector2 cursorPosition) => null;
        protected override void OnLocalTouching(Vector2 cursorPosition) {}
        protected override void OnLocalTouchEnded(Vector2 cursorPosition) {}
        protected override bool OnLocalDirectionMoved(Vector2 direction) => false;
        protected override bool OnLocalConfirmed() => false;
        protected override bool OnLocalCancelled() => false;
        protected override bool OnLocalExited() => false;
    }
}