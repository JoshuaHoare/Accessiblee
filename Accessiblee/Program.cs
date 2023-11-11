using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;
using WindowsInput;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Accessiblee
{
    enum InputState
    {
        Cursor,
        Precision,
        Interaction,
    }


    static class Program
    {
        private static Point prevPos;
        private static bool hasPrevPos;
        private static float alpha = 0.3f;

        private enum filters { Smooth, Averaged, Unfiltered };

        private static bool enableGazeMouseControl = false;
        private static int currentFilter;

        private static Form1 form;
        private static IKeyboardMouseEvents m_GlobalHook;

        public static InputState currentState;

        private static void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                InputSimulator inputSimulator = new InputSimulator(); //!!!!!
                inputSimulator.Mouse.LeftButtonDown();
                enableGazeMouseControl = !enableGazeMouseControl;
                   
                currentState = GetNextEnumValue(currentState);
            }
        }

        private static void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                InputSimulator inputSimulator = new InputSimulator(); //!!!!!
                inputSimulator.Mouse.LeftButtonUp();
            }
        }

        //Moves the mouse cursor and applies filter based on the currently selected setting
        private static void moveCursor(int x, int y)
        {
            Cursor.Position = SmoothFilter(new Point(x, y));
        }

        private static void subscribeGlobalKeyHook()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.KeyUp += GlobalHookKeyUp;
        }

        private static void unsubscribeGlobalKeyHook()
        {
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;
            m_GlobalHook.Dispose();
        }

        //Applies a filter to the point based on currently selected setting
        private static Point SmoothFilter(Point point)
        {
            //checks which filter is selected
            checkFilterSettings();

            Point filteredPoint = point;

            if (!hasPrevPos)
            {
                prevPos = point;
                hasPrevPos = true;
            }

            if (currentFilter == (int)filters.Smooth)
            {
                filteredPoint = new Point((int)((point.X * alpha) + (prevPos.X * (1.0f - alpha))),
                                                (int)((point.Y * alpha) + (prevPos.Y * (1.0f - alpha))));
            }
            else if (currentFilter == (int)filters.Averaged)  //takes the average of the current point and the previous point
            {
                filteredPoint = new Point((point.X + prevPos.X) / 2, (point.Y + prevPos.Y) / 2);
            }

            prevPos = filteredPoint; //set the previous point to current point

            return filteredPoint;
        }

        private static void toggleGazeMouse(object sender, EventArgs e)
        {
            enableGazeMouseControl = true;
        }

        private static void checkFilterSettings()
        {
            currentFilter = (int)filters.Smooth;
        }

        [STAThread]
        static void Main()
        {
            var host = new Host();
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();

            subscribeGlobalKeyHook();

            currentState = InputState.Cursor; // Example state

            var action = GetActionForInputState(currentState);

            //create the data stream
            var gazePointDataStream = host.Streams.CreateGazePointDataStream(Tobii.Interaction.Framework.GazePointDataMode.LightlyFiltered);

            gazePointDataStream.GazePoint((x, y, _) =>
            {
                GetActionForInputState(currentState).Invoke(x, y);
            });

            Application.Run(form);
        }
         
        #region Interaction States

        static Action<double, double> GetActionForInputState(InputState state)
        {
            Debug.WriteLine(state);
            switch (state)
            {
                case InputState.Cursor:
                    return HandleCursor;

                case InputState.Precision:
                    return HandlePrecision;

                case InputState.Interaction:
                    return HandleInteraction;

                default:
                    return HandleError;
            }
        }

        static public InputState GetNextEnumValue(InputState current)
        {
            int nextValue = ((int)current + 1) % Enum.GetValues(typeof(InputState)).Length;
            return (InputState)nextValue;
        }


        static void HandleCursor(double x, double y)
        {
            Console.WriteLine("Handling Cursor Mode");

            moveCursor((int)x, (int)y);
            // Add Cursor handling logic here
        }

        static void HandlePrecision(double x, double y)
        {
            Console.WriteLine("Handling Precision Mode");
            // Add Precision handling logic here
            ApplyMagnifyingEffect(SmoothFilter(new Point(x, y)));
        }

        static void HandleInteraction(double x, double y)
        {
            Console.WriteLine("Handling Interaction Mode");
            // Add Interaction handling logic here
        }

        static void HandleError(double x, double y)
        {
            Console.WriteLine("Unknown Input State.");
        }

        #endregion

        #region Magnification 

        static void ApplyMagnifyingEffect(Point point)
        {
            form._precisionElement.MovePrecision();
            form.UpdateDotPosition(point);

            // Logic to apply a magnifying effect at the given x and y coordinates
            // This could involve creating a zoomed-in overlay of a part of the screen.
        }

        #endregion
    }
}
