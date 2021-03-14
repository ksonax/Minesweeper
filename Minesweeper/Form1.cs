using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MineSweeper : Form
    {
        const int BOARD_SIZE = 10;
        const int BOARD_STARTING_X = 150;
        const int BOARD_STARTING_Y = 100;


        //Player constructor takes grid size as parameter
        Player player = new Player(BOARD_SIZE);
        private Button[,] buttons = new Button[BOARD_SIZE+2, BOARD_SIZE+2];
        private Label gameOverLabel = new Label();
        private int fieldsRevealed = 0;
        private int bombsLeft = BOARD_SIZE;
        public MineSweeper()
        {
            InitializeComponent();
        }
        
        public void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < player.grid.height - 1; i++)
                for(int j = 1; j < player.grid.width - 1; j++)
                {
                    Button b = new Button();
                    buttons[i, j] = b;
                    b.Font = new Font("Arial", 20);
                    b.Width = 40;
                    b.Height = 40;
                    b.Left = (i * 40) + BOARD_STARTING_X;
                    b.Top = (j * 40) + BOARD_STARTING_Y;
                    Controls.Add(b);
                    b.MouseDown += Button_MouseDown;
                }
            bombsLeftLabel.Text = bombsLeft.ToString();
            cellsRevealedLabel.Text = fieldsRevealed.ToString();
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            int x = (b.Left - BOARD_STARTING_X) / 40;
            int y = (b.Top - BOARD_STARTING_Y) / 40;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (player.grid.grid[x, y].numberOfAdjecentBombs == -1)
                    {
                        GameOver();
                    }
                    else if (player.grid.grid[x, y].numberOfAdjecentBombs == 0)
                    {
                        b.Text = "";
                        RevealNeigboringFileds(x, y);
                    }
                    else
                    {
                        if(b.Text == "\U0001F6A9")
                        {
                            break;
                        }
                        else
                        {
                            b.Text = player.grid.grid[x, y].numberOfAdjecentBombs.ToString();
                            b.ForeColor = player.grid.grid[x, y].color;
                            b.Enabled = true;
                            cellsRevealedLabel.Text = (++fieldsRevealed).ToString();
                        }
                    }
                    break;
                case MouseButtons.Right:
                    if (b.Text == "\U0001F6A9")
                    {
                        b.Text = "";
                        bombsLeftLabel.Text = (++bombsLeft).ToString();
                    }
                    else
                    {
                        b.Text = "\U0001F6A9";
                        bombsLeftLabel.Text = (--bombsLeft).ToString();
                    }
                    break;
            }
        }


        private void RevealNeigboringFileds(int x, int y)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                if(p.X > 0 && p.Y > 0 && p.X <= 10 && p.Y <= 10)
                {
                    if (p.X < 0 || p.Y < 0) 
                        continue;
                    if (p.X >= player.grid.grid.GetLength(0) || p.Y >= player.grid.grid.GetLength(1))
                        continue;
                    if (!buttons[p.X, p.Y].Enabled) 
                        continue;
                    if (buttons[p.X, p.Y].Text != "\U0001F6A9")
                        buttons[p.X, p.Y].Enabled = false;

                    if (player.grid.grid[p.X, p.Y].numberOfAdjecentBombs != 0 && buttons[p.X, p.Y].Text != "\U0001F6A9")
                    {
                        buttons[p.X, p.Y].Text = "" + player.grid.grid[p.X, p.Y].numberOfAdjecentBombs;
                        cellsRevealedLabel.Text = (++fieldsRevealed).ToString();
                    }


                    if (player.grid.grid[p.X, p.Y].numberOfAdjecentBombs != 0)
                        continue;

                    if (player.grid.grid[p.X, p.Y].numberOfAdjecentBombs == 0 && buttons[p.X,p.Y].Text != "\U0001F6A9")
                    {
                        cellsRevealedLabel.Text = (++fieldsRevealed).ToString();
                        buttons[p.X, p.Y].Text = "";
                    }

                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X, p.Y - 1));
                    stack.Push(new Point(p.X, p.Y + 1));
                }

            }
        }

        private void GameOver()
        {
            player.SetGameOver(true);
            for (int i = 1; i < player.grid.height - 1; i++)
                for (int j = 1; j < player.grid.width - 1; j++)
                {
                    buttons[i, j].Text = "" + player.grid.grid[i, j].numberOfAdjecentBombs;
                    if (player.grid.grid[i, j].numberOfAdjecentBombs == -1)
                    {
                        buttons[i, j].Text = "\U0001F4A3"; // U0001F4A3 is ASCII Code for bomb
                    }
                    buttons[i, j].Enabled = false;
                }
            RenderGameOverContent();
        }

        //Adds "game over" label and makes "new game" button
        private void RenderGameOverContent()
        {
             
            gameOverLabel.Text = "Game Over";
            gameOverLabel.Font = new Font("Arial", 30);
            gameOverLabel.TextAlign = ContentAlignment.MiddleCenter;
            gameOverLabel.Width = 240;
            gameOverLabel.Height = 40;
            gameOverLabel.Left = 260;
            gameOverLabel.Top = 500;
            Controls.Add(gameOverLabel);

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            player = new Player(BOARD_SIZE);
            Controls.Remove(gameOverLabel);
            bombsLeft = BOARD_SIZE;
            fieldsRevealed = 0;
            bombsLeftLabel.Text = bombsLeft.ToString();
            cellsRevealedLabel.Text = fieldsRevealed.ToString();
            for(int i = 1; i < player.grid.height - 1; i++)
                for (int j = 1; j < player.grid.width - 1; j++)
                {
                    buttons[i, j].Text = "";
                    buttons[i, j].Enabled = true;
                }
        }
        
        private void ButtonFontColor(Button b)
        {

        }

    }
}
