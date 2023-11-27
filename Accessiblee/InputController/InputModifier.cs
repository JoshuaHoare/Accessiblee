using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Accessiblee.InputController.InputVariations;

namespace Accessiblee
{
    public interface IInputModifier
    {
        void Stream();
        void Disable();
    }

    public struct CurrentModifier
    {
        public InputState state;
        public IInputModifier modifier;
    }

    public static class InputModifier
    {
        public static CurrentModifier currentModifier;
        
        public static void Initialise()
        {
            ChangeState(InputState.Cursor);
            GazeData.GazeUpdate += Stream;
        }

        public static void ChangeState(InputState newState)
        {
            // Disable the current modifier
            if (currentModifier.state != newState)
                currentModifier.modifier.Disable();

            // Setup new modifier
            currentModifier.modifier = newModifier(newState);
            currentModifier.state = newState;
        }
       
        //
        public static void Stream(Point point)
        {
            if (currentModifier.modifier != null)
                currentModifier.modifier.Stream();
            else
                Console.WriteLine("No Modifier to Stream too");
        }

        public static IInputModifier newModifier(InputState newState)
        {
            switch (newState)
            {
                case InputState.Cursor:
                    return new CursorInput();
                case InputState.Precision:
                    return new PrecisionInput();
                case InputState.Interaction:
                    return new PrecisionInput();

                // Add cases for other control types and their corresponding classes
                default:
                    throw new ArgumentException("Invalid control type", nameof(InputState));
            }
        }
    }
}
