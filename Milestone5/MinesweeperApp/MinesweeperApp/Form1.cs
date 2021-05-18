using MinesweeperLibrary;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MinesweeperApp
{
    public partial class Form1 : Form
    {
        // Initialize empty mine field.
        static Board field = new Board();

        // Initialize game timer.
        private Stopwatch watch = new Stopwatch();
        private int rows, cols, clicks;

        public Form1()
        {
            InitializeComponent();
        }

        // Update display time label.
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;
            string displayTime = string.Format("{0}", ts.Seconds);
            lblTime.Text = displayTime;
        }

        // Initialize new game.
        private void btnStart_Click(object sender, EventArgs e)
        {
            int clicks = 0;

            // Reset time and clicks.
            watch.Restart();
            lblClicks.Text = clicks.ToString();

            rows = panel1.Height / field.Size;
            cols = panel1.Width / field.Size;

            //for (int r = 0; r < rows; r++)
            //{
            //    for (int c = 0; c < cols; c++)
            //    {
                    
            //        field.Grid [r, c] = new Button();
            //        field.Grid [r, c].ColumnNumber = c;
            //        field.Grid [r, c].RowNumber = r;

                    
            //    }
            //}
        }

    }
}
