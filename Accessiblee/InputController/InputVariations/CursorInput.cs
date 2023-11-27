using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Accessiblee.InputController.InputVariations
{
    public class CursorInput : IInputModifier
    {
        #region Disable Functionality

        /// <summary>
        /// We want to make sure we are disabling all features related to this modifier
        /// </summary>

        bool active = false;

        void IInputModifier.Disable()
        {
            if (!active)
                return;

            // Disable features
        }

        #endregion

        //Private Fields
        Point prevPoint;
        float alpha = 0.2f;

        void IInputModifier.Stream()
        {

            prevPoint = SmoothFilter(GazeData.position);
            Cursor.Position = prevPoint;

        }

        Point SmoothFilter(Point point)
        {
            return new Point((int)((point.X * alpha) + (prevPoint.X * (1.0f - alpha))),
                                                (int)((point.Y * alpha) + (prevPoint.Y * (1.0f - alpha))));
        }
    }
}
