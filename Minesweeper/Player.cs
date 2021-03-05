using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Player // idk if this is necessery => might delete it later
    {
        public int fieldsLeft;
        public int fieldsRevealed;
        public bool gameOver = false;
        public Grid grid;

        public Player(int gridSize)
        {
            grid = new Grid(gridSize, gridSize);
            fieldsLeft = (grid.height*grid.width)-grid.amountOfBombs;
            fieldsRevealed = 0;
        }

    }
}
