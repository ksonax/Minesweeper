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
        //Player constructor takes grid size as parameter
        Player player = new Player(10);
        public MineSweeper()
        {
            InitializeComponent();
        }
        
        public void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < player.grid.height-1; i++)
                for(int j = 1; j < player.grid.width-1; j++)
                {
                    Button b = new Button();
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
                b.Text = "\U0001F4A3"; // U0001F4A3 is ASCII Code for bomb
            else
                b.Text = player.grid.grid[x, y].numberOfAdjecentBombs.ToString();
        }
    }
}
