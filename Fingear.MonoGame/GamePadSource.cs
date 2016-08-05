using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public struct GamePadSource : IInputSource
    {
        public PlayerIndex PlayerIndex { get; private set; }

        public GamePadSource(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}