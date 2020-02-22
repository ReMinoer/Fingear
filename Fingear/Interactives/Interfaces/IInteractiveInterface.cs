using System.Numerics;

namespace Fingear.Interactives.Interfaces
{
    public interface IInteractiveInterface : IInteractiveComposite<IInteractiveInterface>
    {
        void OnCursorMoved(Vector2 cursorPosition);
        IInteractiveInterface OnTouchStarted(Vector2 cursorPosition);
        void OnTouching(Vector2 cursorPosition);
        void OnTouchEnded(Vector2 cursorPosition);
        bool OnDirectionMoved(Vector2 direction);
        bool OnConfirmed();
        bool OnCancelled();
        bool OnExited();
    }
}