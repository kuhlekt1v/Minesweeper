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
        static Board field = new();
        private readonly Button [,] btnGrid = new Button [field.Size, field.Size];

        // Embedded cell icons.
        readonly Image redFlag = Image.FromFile("..\\..\\..\\Images\\red-triang-flag.png");
        readonly Image mine = Image.FromFile("..\\..\\..\\Images\\mine.png");

        // Initialize game timer.
        private readonly Stopwatch watch = new();

        public Form1()
        {
            InitializeComponent();
            
            // Assign live bombs to random cells.
            field.SetUpLiveNeighbors();
            field.CalculateLiveNumbers();
            CreateGrid(field);
        }

        private void fileToolStripMenuItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int difficulty = 5;

            switch (e.ClickedItem.Text)
            {
                case "Easy":
                    difficulty = 5;
                    break;
                case "Normal":
                    difficulty = 10;
                    break;
                case "Hard":
                    difficulty = 25;
                    break;
                default:
                    break;
            }

            // Reset mine field.
            ResetGrid(field);
            field.ResetCells();

            field.Difficulty = difficulty;
            field.SetUpLiveNeighbors();
            field.CalculateLiveNumbers();
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
                    btnGrid [i, j] = new Button
                    {
                        Height = btnSize,
                        Width = btnSize,
                        BackColor = SystemColors.Control
                    };

                    // Add click event to each button
                    btnGrid [i, j].MouseDown += GridButtonClick;

                    // Add new button to the panel.
                    panel1.Controls.Add(btnGrid [i, j]);

                    // Set location of new button on panel.
                    btnGrid [i, j].Location = new Point(i * btnSize, j * btnSize);
                    btnGrid [i, j].Tag = new Point(i, j);
                }
            }
        }

        private void GridButtonClick(object sender, MouseEventArgs e)
        {
            // Get the row and column number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            // Left click.
            if (e.Button == MouseButtons.Left)
            {
                if (field.Click == 0)
                {
                    tsDifficultySetting.Enabled = false;
                    watch.Restart();
                }

                // Remove image (in case it has been flagged).
                btnGrid[x, y].Image = null;

                // Update & display number of clicks by user - change for unvisited cells only in Board.cs.
                field.UpdateClickCounter(x, y);
                lblClicks.Text = field.Click.ToString();

                // Mark cells as visited.
                field.FloodFill(x, y);

                switch (field.GameStatus(x, y))
                {
                    case "win":
                        DisplayGameResult($"You've won in {lblTime.Text} seconds!");
                        field.RevealBoard("win");
                        UpdateGrid(field, "win");
                        break;
                    case "lose":
                        btnGrid [x, y].BackColor = Color.Red;
                        btnGrid [x, y].Image = mine;
                        DisplayGameResult("Game over!");
                        field.RevealBoard("lose");
                        UpdateGrid(field);
                        break;
                    default:
                        UpdateGrid(field);
                        break;
                }
            }

            // Right click empty square.
            else if(e.Button == MouseButtons.Right && btnGrid [x, y].Image == null && btnGrid [x, y].Text == "")
            {
                // Display red flag.
                btnGrid[x, y].Image = redFlag;
                btnGrid[x, y].ImageAlign = ContentAlignment.MiddleCenter;
            }

            // Right click empty square.
            else if (e.Button == MouseButtons.Right && btnGrid [x, y].Image == redFlag)
            {
                // Remove red flag.
                btnGrid [x, y].Image = null;
            }
        }

        private void DisplayGameResult(string message)
        {
            watch.Stop();
            MessageBox.Show(message);
        }

        // Update minefield after user click.
        private void UpdateGrid(Board field, string result = null)
        {
            // Initialize grid of buttons.
            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {
                    Cell c = field.Grid [i, j];

                    // Not live visited cells.
                    if (c.Visited && !c.Live)
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
                    // Live visited cells.
                    else if (c.Visited && c.Live)
                    {
                        btnGrid [i, j].BackColor = Color.Red;
                        btnGrid [i, j].Image = mine;
                    }

                    if(result == "win" && !c.Visited && c.Live)
                        btnGrid [i, j].Image = redFlag;
                }
            }
        }


        // Update minefield after user click.
        private void ResetGrid(Board field)
        {
            // Initialize grid of buttons.
            for (int i = 0; i < field.Size; i++)
            {
                for (int j = 0; j < field.Size; j++)
                {
                    btnGrid [i, j].BackColor = SystemColors.Control;
                    btnGrid [i, j].Text = "";
                    btnGrid [i, j].Image = null;
                }
            }
        }

        // Update display time label.
        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;
            string displayTime = string.Format("{0}", ts.Seconds);
            lblTime.Text = displayTime;
        }

        // Initialize new game.
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Stop timer
            watch.Restart();
            watch.Stop();

            // Reset labels.
            field.Click = 0;
            lblClicks.Text = field.Click.ToString();

            // Enable difficulty selection.
            tsDifficultySetting.Enabled = true;

            // Clear all live cells & neighbors.
            ResetGrid(field);

            // Reset all cells.
            field.ResetCells();

            // Assign live bombs to random cells.
            field.SetUpLiveNeighbors();
            field.CalculateLiveNumbers();
        }
    }
}
