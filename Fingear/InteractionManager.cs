using Fingear.Interactives;

namespace Fingear
{
    public class InteractionManager
    {
        public IInteractiveComposite<IInteractive> Root { get; } = new InteractiveComposite();

        public void Update(float elapsedTime)
        {
            InputManager.Instance.Update();
            Root.Update(elapsedTime);
        }

        public void Reset()
        {
            Root.Reset();
        }
    }
}