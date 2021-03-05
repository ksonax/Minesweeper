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
        //Player constructor takes grid size as parameter
        Player player = new Player(BOARD_SIZE);
        public Button[,] buttons = new Button[BOARD_SIZE+2, BOARD_SIZE+2];
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
                    b.Left = i * 40;
                    b.Top = j * 40;
                    Controls.Add(b);
                    b.Click += Button_Click;
                }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int x = b.Left / 40;
            int y = b.Top / 40;
            if (player.grid.grid[x, y].numberOfAdjecentBombs == -1)
            {
                b.Text = "\U0001F4A3"; // U0001F4A3 is ASCII Code for bomb
            }
            else if (player.grid.grid[x, y].numberOfAdjecentBombs == 0)
            {
                b.Text = "";
                RevealNeigboringFileds(x, y);
            }
            else
            {
                b.Text = player.grid.grid[x, y].numberOfAdjecentBombs.ToString();
                b.Enabled = false;
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

                    buttons[p.X, p.Y].Enabled = false;

                    if (player.grid.grid[p.X, p.Y].numberOfAdjecentBombs != 0)
                        buttons[p.X, p.Y].Text = "" + player.grid.grid[p.X, p.Y].numberOfAdjecentBombs;

                    if (player.grid.grid[p.X, p.Y].numberOfAdjecentBombs != 0)
                        continue;

                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X, p.Y - 1));
                    stack.Push(new Point(p.X, p.Y + 1));
                }

            }
        }
    }
}
