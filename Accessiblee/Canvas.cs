﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accessiblee  
{
    public partial class Canvas : Form
    {
        public Point point;
        public int x;
        public int y;


        private int dotSize = 10; // Size of the dot

         public Canvas()
        {
            //Setup the canvas
            Initialise();

            this.Paint += new PaintEventHandler(Form1_Paint); // Su bscribe to the Paint event
        }   

        private void Form1_Paint(object sender, PaintEventArgs e)
        {   
            // Create a solid red brush
            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                // Draw a filled ellipse (dot) at the specified coordinates
                e.Graphics.FillEllipse(redBrush, x - dotSize / 2, y - dotSize / 2, dotSize, dotSize);
            }
        }

          private void Form1_Load(object sender, EventArgs e)
        {

        }
         // Method to update  the dot's position and repaint
        public void UpdateDotPosition(Point _point)  
        {  
            this.point = _point;
            x = _point.X;
            y = _point.Y;

            this.Invalidate();
            // This will trigger the Paint event
        } 
        
    }
}
