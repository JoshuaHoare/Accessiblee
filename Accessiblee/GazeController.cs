using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;
using Gma.System.MouseKeyHook;
using System.Drawing;


namespace Accessiblee
{
    #region Gaze Data

    public static class GazeData
    {

        public static event Action<Point> GazeUpdate;

        public static double x;
        public static double y;

        public static Point position;

        public static void UpdateStream(double _x, double _y)
        {
            // Updates the point ---> INT precision
            position.X = (int)_x;
            position.Y = (int)_y;

            // Updates individual X and Y ---> DOUBLE precision
            x = _x;
            y = _y;

            //Console.WriteLine("Streaming Gaze Data: " + x);

            GazeUpdate?.Invoke(position);
        }
    }

    #endregion

    public static class GazeController
    {
        [STAThread]
        public static void Init()
        {
            var host = new Host();

            //create the data stream
            var gazePointDataStream = host.Streams.CreateGazePointDataStream(Tobii.Interaction.Framework.GazePointDataMode.LightlyFiltered);

            gazePointDataStream.GazePoint((x, y, _) =>
            {
                GazeData.UpdateStream(x, y);
            });
        }

        #region Tobbi Data


        #endregion

    }
}
