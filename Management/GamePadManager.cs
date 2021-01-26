using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ZeldaOne.Management
{
    public static class GamePadManager
    {
        public static GamePadState GamePadState;
        public static GamePadState OldGamePadState;

        public static bool ButtonPressedOnce(Buttons buttons)
        {
            return GamePadState.IsButtonDown(buttons) && !OldGamePadState.IsButtonDown(buttons);
        }

        public static bool ButtonPressedContinue(Buttons buttons)
        {
            return GamePadState.IsButtonDown(buttons);
        }
    }
}