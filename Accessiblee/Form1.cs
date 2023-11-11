using System;
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
public partial class Form1 : Form
    {
        public int x = 100; // X coordinate for the dot
        public int y = 100; // Y coordinate for the dot
        private int dotSize = 10; // Size of the dot

         public Form1()
        {
            InitializeComponent();
            InitializePrecisionElement();
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
        public void UpdateDotPosition(int newX, int newY)
        {
            x = newX;
            y = newY;

            this.Invalidate();
            _precisionElement.Invalidate();
            // This will trigger the Paint event
        } 
        
        public PrecisionElement _precisionElement; 
             
        private void InitializePrecisionElement()
        {
            _precisionElement = new PrecisionElement(this);



            this.Controls.Add(_precisionElement);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

    }
}
