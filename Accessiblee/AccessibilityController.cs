using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Accessiblee
{
    public enum InputState
    {
        Cursor,
        Precision,
        Interaction,
    }

    public class AccessibilityController
    {

        #region Public References

        // Class References
        public static MagnifierElement magnifier;
        public static Canvas canvas;
        public static Point eyePosition;
        public static IInputModifier inputModifier;

        #endregion

        public static InputState inputState;

        public AccessibilityController(Canvas _canvas)
        {
            // Initialise Eye Tracker Streaming
            GazeController.Init();
            GazeData.GazeUpdate += GazeUpdate;

            // Initialise Input Modifier
            InputModifier.Initialise();

            //Set References
            canvas = _canvas;
            magnifier = new MagnifierElement(this);
        }


        // Subscribe to updates on gaze data
        public void GazeUpdate(Point gazePosition)
        {
            Console.WriteLine("Streaming Gaze Data: " + gazePosition.X);
        }

    }
}
