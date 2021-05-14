using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
       
        private Button [,] btnGrid = new Button [10, 10];

        public Form2()
        {
            InitializeComponent();
            CreateGrid();
        }

        public void CreateGrid()
        {
            // Create buttons and place into panel 1.
            int buttonSize = panel1.Width / 10;

            // Ensure panel is a square
            panel1.Height = panel1.Width;

            // Create buttons and print to screen.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    btnGrid [i, j] = new Button();
                    btnGrid [i, j].Height = buttonSize;
                    btnGrid [i, j].Width = buttonSize;

                    // Add click event to each button
                    btnGrid [i, j].Click += GridButtonClick;

                    // Add new button to the panel.
                    panel1.Controls.Add(btnGrid [i, j]);

                    // Set location of new button on panel.
                    btnGrid [i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid [i, j].Tag = new Point(i, j);
                }
            }
        }

        private void GridButtonClick(object sender, EventArgs e)
        {
            // Get the row and column number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            // Count number of clicks on each cell.
            int i;
            if (string.IsNullOrEmpty(btnGrid [x, y].Text))
                i = 0;
            else
                i = Convert.ToInt32(btnGrid [x, y].Text);

            i++;
            btnGrid [x, y].Text = i.ToString();
        }

    }
}
