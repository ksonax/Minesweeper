using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Grid
    {
        public int height;
        public int width;
        public int amountOfBombs;
        public Cell[,] grid;

        public Grid(int newHeight, int newWidth)
        {
            height = newHeight+2;
            width = newWidth+2;
            amountOfBombs = (int)Math.Sqrt(newHeight * newWidth);
            grid = new Cell[height, width];
            GenerateCells();
            GenerateBombs(grid);
            SetAdjecentBombs();

        }
        public void SetAmountOfBombs(int newBombsAmonut)
        {
            amountOfBombs = newBombsAmonut;
        }
        public int GetAmountOfBombs()
        {
            return amountOfBombs;
        }
        public void GenerateCells()
        {
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                {
                    grid[i,j] = new Cell(i, j);
                }
        }
        public void GenerateBombs(Cell[,] grid)
        {
            int placedBombs = 0;
            while(placedBombs != amountOfBombs)
            {
                Random rnd = new Random();
                int randX = rnd.Next(1, height-1);
                int randY = rnd.Next(1, width-1);
                if (!grid[randX, randY].state)
                {
                    grid[randX, randY].state = true;
                    placedBombs++;
                }
            }
        }
        public void SetAdjecentBombs()
        {
            int numberOfSurroundingBombs = 0;
            for (int i = 1; i < height - 1; i++)
                for (int j = 1; j < width - 1; j++)
                {
                    if (grid[i,j].state)
                        grid[i, j].numberOfAdjecentBombs = -1;
                    else
                    {
                        if (grid[i - 1, j - 1].state)
                            numberOfSurroundingBombs++;
                        if (grid[i, j - 1].state)
                            numberOfSurroundingBombs++;
                        if (grid[i + 1, j - 1].state)
                            numberOfSurroundingBombs++;
                        if (grid[i - 1, j].state)
                            numberOfSurroundingBombs++;
                        if (grid[i + 1, j].state)
                            numberOfSurroundingBombs++;
                        if (grid[i - 1, j + 1].state)
                            numberOfSurroundingBombs++;
                        if (grid[i, j + 1].state)
                            numberOfSurroundingBombs++;
                        if (grid[i + 1, j + 1].state)
                            numberOfSurroundingBombs++;
                        grid[i, j].numberOfAdjecentBombs = numberOfSurroundingBombs;
                        numberOfSurroundingBombs = 0;
                    }
                }
        }
    }
}
