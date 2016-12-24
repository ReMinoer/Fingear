using Microsoft.Xna.Framework;

namespace Fingear.MonoGame
{
    public class MonoGameInputSytem : InputSystem
    {
        static private MonoGameInputSytem _instance;
        static public MonoGameInputSytem Instance => _instance ?? (_instance = new MonoGameInputSytem());
        public IInputStates InputStates { get; set; } = new GameInputStates();

        private MonoGameInputSytem()
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