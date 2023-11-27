
using System.Drawing;
using System.Windows.Forms;

namespace Accessiblee
{
    partial class Canvas { 
    
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
        private void Initialise()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 

            // Set the form to full screen and borderless
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds; // Manually set the form to cover the entire screen

            // Set the form to be always on top
            this.TopMost = true; 

            // Set up transparency
            this.BackColor = Color.Magenta; // Set a unique background color
            this.TransparencyKey = Color.Magenta; // Set TransparencyKey to the same color

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

            // Ensure the form is laid out immediately to apply the above settings
            this.PerformLayout();
        }

        #endregion

    }
}

