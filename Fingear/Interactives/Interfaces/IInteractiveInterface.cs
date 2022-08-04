using System.Numerics;

namespace Fingear.Interactives.Interfaces
{
    public interface IInteractiveInterface : IInteractive
    {
        void OnCursorMoved(Vector2 cursorPosition);
        IInteractiveInterface OnCursorHovering(Vector2 cursorPosition);
        IInteractiveInterface OnTouchStarted(Vector2 cursorPosition);
        void OnTouching(Vector2 cursorPosition);
        void OnTouchEnded(Vector2 cursorPosition);
        bool OnDirectionMoved(Vector2 direction);
        bool OnConfirmed();
        bool OnCancelled();
        bool OnExited();
    }

    public interface IInteractiveInterface<TComponent> : IInteractiveComposite<TComponent>, IInteractiveInterface
        where TComponent : class, IInteractiveInterface<TComponent>
    {
        new TComponent OnCursorHovering(Vector2 cursorPosition);
        new TComponent OnTouchStarted(Vector2 cursorPosition);
    }
}