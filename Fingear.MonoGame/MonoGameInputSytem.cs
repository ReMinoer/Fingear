using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public class MonoGameInputSytem : InputSystem
    {
        public MonoGameInputSytem()
        {
            Add(new KeyboardSource());
            Add(new MouseSource());
            Add(new GamePadSource(PlayerIndex.One));
            Add(new GamePadSource(PlayerIndex.Two));
            Add(new GamePadSource(PlayerIndex.Three));
            Add(new GamePadSource(PlayerIndex.Four));
        }
    }
}