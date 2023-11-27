using System;
using System.Diagnostics;
using System.Drawing;  
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Tobii.Interaction; 
 
namespace Accessiblee 
{
    public class MagnifierElement :   Control
    {     
        Canvas canvas;
        Point position;

        private AccessibilityController manager;

        public MagnifierElement(AccessibilityController _manager)  
        {
            manager = _manager;

            Size = new System.Drawing.Size(150, 150);      
        }


        #region Form Control

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Outer circle (border)
            int borderWidth = 4; // Set the border width
            int offset = Width / 2;
            using (Pen borderPen = new Pen(Color.Black, borderWidth))
            {

                g.DrawEllipse(borderPen, 0, 0, Width - borderWidth, Height - borderWidth);
            }

            // Inner circle (transparent)
            // The inner circle is created by the empty space within the outer circle.
        }

        #endregion



        public void MovePrecision(Point eyePosition)
        {
            if (StaticUtils.DistanceBetweenPoints(position, eyePosition) <= 200)
            {
                Debug.WriteLine("buffered");
            }
            else
            {
                position = new Point(canvas.x - (Width / 2), canvas.y - (Width / 2));

                Location = position;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Redraw when the control is resized
        }
    }
}
