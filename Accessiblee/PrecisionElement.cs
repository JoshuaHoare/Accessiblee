﻿using System;
using System.Diagnostics;
using System.Drawing;  
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Tobii.Interaction; 

namespace Accessiblee 
{
    public class PrecisionElement :   Control
    {     
        Form1 form; 

        public PrecisionElement(Form1 _form)
        {    
                 
            form = _form; 
            Size = new System.Drawing.Size(150, 150);      
        }  
          
        private double DistanceTo(Point from, Point to)  
        {
            var result = Math.Sqrt(Math.Pow((from.X - to.X), 2) + Math.Pow((from.Y - to.Y) , 2 ));
            return result; 
        }
             
        Point lastPos;
        Point eyePosition;
        Point cursorPosition;
        bool triggerMovement = false;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            eyePosition = new Point(form.x, form.y); 
            cursorPosition = Cursor.Position;   
                 
            if (DistanceTo(Location, eyePosition) <= 250)  
            { 
                Debug.WriteLine("buffered"); 
                triggerMovement = false;
            }
            else if (!triggerMovement)
            {
                triggerMovement = true;
            }
            else
            {
                lastPos = eyePosition;
                Location = new Point(form.x - (Width / 2), form.y - (Width / 2));
            }

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

            Debug.WriteLine("REEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            // Inner circle (transparent)
            // The inner circle is created by the empty space within the outer circle.
        }

        public void MovePrecision()
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Redraw when the control is resized
        }
    }
}
