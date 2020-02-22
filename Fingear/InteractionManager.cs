using Fingear.Inputs;
using Fingear.Interactives;
using Fingear.Interactives.Containers;

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