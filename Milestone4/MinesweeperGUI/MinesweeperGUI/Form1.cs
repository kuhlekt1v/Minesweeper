using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Start app centered in screen.
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            // Initialize 2nd form.
            Form2 f2 = new Form2();

            // Hide level select.
            this.Hide();

            // Open form two in center of screen.
            f2.StartPosition = FormStartPosition.CenterScreen;
            // Disable form maximize.
            f2.FormBorderStyle = FormBorderStyle.FixedSingle;
            f2.MaximizeBox = false;
            // Set form location & show.
            f2.Location = this.Location;
            f2.ShowDialog();

            // Close select level form.
            this.Close();

        }
    }
}
