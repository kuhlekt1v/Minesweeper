using MinesweeperLibrary;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MinesweeperApp
{
    public partial class Form1 : Form
    {
        // Initialize empty mine field.
        static Board field = new Board();
        private Button [,] btnGrid = new Button [field.Size, field.Size];

        // Initialize game timer.
        private Stopwatch watch = new Stopwatch();


        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Assign live bombs to random cells.
            field.SetUpLiveNeighbors();

            // Calculate number of live neighbors.
            field.CalculateLiveNumbers();

            // Initialize mine field.
            CreateGrid(field);
        }

        // Create and display the initial mine field.
        private void CreateGrid(Board field)
        {
            // Set button size.
            int btnSize = panel1.Width / field.Size;

            // Initialize grid of buttons.
            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {
                    // Button size.
                    btnGrid [i, j] = new Button();
                    btnGrid [i, j].Height = btnSize;
                    btnGrid [i, j].Width = btnSize;

                    // Add click event to each button
                    btnGrid [i, j].Click += GridButtonClick;

                    // Add new button to the panel.
                    panel1.Controls.Add(btnGrid [i, j]);

                    // Set location of new button on panel.
                    btnGrid [i, j].Location = new Point(i * btnSize, j * btnSize);
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

            // Update & display number of clicks by user - change for unvisited cells only in Board.cs.
            field.UpdateClickCounter();
            lblClicks.Text = field.Click.ToString();

            // Mark cells as visited.
            field.FloodFill(x, y);


            // CHECK FOR LIVE CELL NEEDS TO GO HERE BEFORE UPDATEGRID





            // Display the updated grid.
            UpdateGrid(field);

            // Check for game win or lose.
            if (field.GameStatus() == "win")
                DisplayGameResult($"You've won in {lblTime.Text} seconds!");            
        }

        private void DisplayGameResult(string message)
        {
            watch.Stop();
            MessageBox.Show(message);
        }

        // Update minefield after user click.
        private void UpdateGrid(Board field)
        {
            // Initialize grid of buttons.
            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {

                    Cell c = field.Grid [i, j];
                    if (c.Visited)
                    {
                        btnGrid [i, j].BackColor = ColorTranslator.FromHtml("#bdbdbd");

                        // Set live neighbor label color.
                        switch (c.LiveNeighbors)
                        {
                            case 1:
                                btnGrid [i, j].ForeColor = Color.Blue;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 2:
                                btnGrid [i, j].ForeColor = Color.Green;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 3:
                                btnGrid [i, j].ForeColor = Color.Red;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 4:
                                btnGrid [i, j].ForeColor = Color.DarkBlue;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 5:
                                btnGrid [i, j].ForeColor = Color.DarkRed;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 6:
                                btnGrid [i, j].ForeColor = Color.DarkGreen;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 7:
                                btnGrid [i, j].ForeColor = Color.Maroon;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            case 8:
                                btnGrid [i, j].ForeColor = Color.Black;
                                btnGrid [i, j].Text = c.LiveNeighbors.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
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
            // Toggle start button text.
            btnStart.Text = "Reset";

            watch.Restart();

            lblClicks.Text = 0.ToString();
        }
    }
}
