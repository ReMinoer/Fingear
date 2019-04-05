using System.Collections.Generic;
using System.Numerics;
using Fingear.Interactives.Base;

namespace Fingear.Interactives
{
    public interface IInterfaceComponent
    {
        IInteractive Parent { get; }
        IEnumerable<IInteractive> Children { get; }
        void OnCursorChanged(Vector2 cursor);
        void OnDirectionChanged(Vector2 direction);
        void OnConfirmed(InputActivity confirm);
        void OnCancelled(InputActivity cancel);
        void OnLaunched(InputActivity launch);
        void OnExited(InputActivity exit);
        void OnClic(InputActivity clic);
        void OnContextClic(InputActivity contextClic);
    }

    public class InteractiveInterface : InteractiveComponentBase
    {
        public IInterfaceComponent InterfaceRoot { get; }

        public IControl<Vector2> Direction { get; set; }
        public IControl<InputActivity> Confirm { get; set; }
        public IControl<InputActivity> Cancel { get; set; }
        public IControl<InputActivity> Launch { get; set; }
        public IControl<InputActivity> Exit { get; set; }

        public IControl<Vector2> Cursor { get; set; }
        public IControl<InputActivity> Clic { get; set; }
        public IControl<InputActivity> ContextClic { get; set; }

        public override IEnumerable<IControl> Controls
        {
            get
            {
                yield return Direction;
                yield return Confirm;
                yield return Cancel;
                yield return Launch;
                yield return Exit;
                yield return Cursor;
                yield return Clic;
                yield return ContextClic;
            }
        }

        public InteractiveInterface(IInterfaceComponent interfaceRoot)
        {
            InterfaceRoot = interfaceRoot;
        }

        protected override void UpdateEnabled(float elapsedTime)
        {
            base.UpdateEnabled(elapsedTime);
            
            if (Cursor.IsActive(out Vector2 cursor))
                InterfaceRoot.OnCursorChanged(cursor);
            if (Direction.IsActive(out Vector2 direction))
                InterfaceRoot.OnDirectionChanged(direction);
            if (Confirm.IsActive(out InputActivity confirm))
                InterfaceRoot.OnConfirmed(confirm);
            if (Cancel.IsActive(out InputActivity cancel))
                InterfaceRoot.OnCancelled(cancel);
            if (Launch.IsActive(out InputActivity launch))
                InterfaceRoot.OnLaunched(launch);
            if (Exit.IsActive(out InputActivity exit))
                InterfaceRoot.OnExited(exit);
            if (Clic.IsActive(out InputActivity clic))
                InterfaceRoot.OnClic(clic);
            if (ContextClic.IsActive(out InputActivity contextClic))
                InterfaceRoot.OnContextClic(contextClic);
        }
    }
}