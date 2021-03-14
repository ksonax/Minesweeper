using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
    public class Cell
    {
        public int positionX;
        public int positionY;
        // state determines if given cell is the bomb (true for bomb, false for empty cell)
        public bool state = false;
        public bool isRevealed = false;
        // if there is a bomb nearby the number will be from 1 to 8
        // if there is no bombs nearby the number will be 0
        // if the bomb is on this cell the number will be -1
        public int numberOfAdjecentBombs = 0;

        public Color color;

        public Cell(int newPositionX, int newPositionY)
        {
            positionX = newPositionX;
            positionY = newPositionY;
        }

        public void setState(bool newState)
        {
            state = newState;
        }
        public void setIsRevealed(bool revealed)
        {
            isRevealed = revealed;
        }
        public bool getState()
        {
            return state;
        }
        public bool getIsRevealed()
        {
            return isRevealed;
        }
        public int[] getPossition()
        {
            int[] position = { this.positionX, this.positionY };
            return position;
        }
        public void SetColor()
        {
            switch (numberOfAdjecentBombs)
            {
                case 1:
                    color = Color.FromName("B");
                    break;
                case 2:
                    color = Color.FromName("G");
                    break;
                case 3:
                    color = Color.FromName("R");
                    break;
                case 4:
                    color = Color.FromName("Purple");
                    break;
                case 5:
                    color = Color.FromName("DarkRed");
                    break;
                case 6:
                    color = Color.FromName("Turquoise");
                    break;
                case 7:
                    color = Color.FromName("Gray");
                    break;
                case 8:
                    color = Color.FromName("Black");
                    break;
                default:
                    color = Color.FromName("Black");
                    break;
            }

        }

    }
}
