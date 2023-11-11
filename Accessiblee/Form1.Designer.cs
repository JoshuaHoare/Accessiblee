
using System.Drawing;
using System.Windows.Forms;

namespace Accessiblee
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        } 
         


        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.components = new System.ComponentModel.Container();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.timer1 = new Timer(this.components);

            // Set border to nothing
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            // Set background of form to transparent
            this.BackColor = Color.Magenta; // Set a unique background color
            this.TransparencyKey = Color.Magenta; // Set TransparencyKey to the same color

            // Maximize the window
            this.WindowState = FormWindowState.Maximized;

            //Timer

            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += new System.EventHandler(timer1_Tick);

            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;

    }
}

