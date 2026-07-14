using SharpDX;
using System;

namespace ConwaysGameOfLife.Models
{
    internal class CellLifeMatrix
    {
        private bool[,] _cellLifeMatrix;

        public bool[,] CellMatrix => _cellLifeMatrix;

        public CellLifeMatrix(int rows, int cols) 
        {
             _cellLifeMatrix = new bool[rows, cols];
        }

        public void Initialize(float density)
        {
            for (int y = 0; y <= _cellLifeMatrix.GetLength(0) - 1; y++)
            {
                for (int x = 0; x <= _cellLifeMatrix.GetLength(1) - 1; x++)
                {
                    Random rnd = new Random();
                    _cellLifeMatrix[y, x] = (rnd.NextFloat(0.0f,1.0f) < density);
                }
            }
        }

        public void Update()
        {
            for (int y = 0; y <= _cellLifeMatrix.GetLength(0) - 1; y++)
            {
                for (int x = 0; x <= _cellLifeMatrix.GetLength(1) - 1; x++)
                {
                    if (_Reproduction(x, y) && !_cellLifeMatrix[x,y])
                    {
                        _cellLifeMatrix[x, y] = true;
                    }

                    else if (_UnderPopulation(x, y) && _cellLifeMatrix[x, y])
                    {
                        _cellLifeMatrix[x, y] = false;
                    }

                    else if (_OverPopulation(x, y) && _cellLifeMatrix[x, y])
                    {
                        _cellLifeMatrix[x, y] = false;
                    } else
                    {
                        _cellLifeMatrix[x, y] = true;
                    }
                }
            }
        }

        private bool _Reproduction(int x, int y)
        {
            bool[] cells = _GetNearestNeighbors(x, y);

            int count = 0;
            for (int i = 0; i <= cells.Length - 1; i++)
            {
                if (cells[i])
                {
                    count++;
                }
            }

            return count == 3;
        }

        private bool _OverPopulation(int x, int y)
        {
            bool[] cells = _GetNearestNeighbors(x, y);

            int count = 0;
            for (int i = 0; i <= cells.Length - 1; i++)
            {
                if (cells[i])
                {
                    count++;
                }
            }

            return count > 3;
        }

        private bool _UnderPopulation(int x, int y)
        {
            bool[] cells = _GetNearestNeighbors(x, y);

            int count = 0;
            for (int i = 0; i <= cells.Length - 1; i++)
            {
                if (cells[i])
                {
                    count++;
                }
            }

            return count < 2;
        }

        private bool[] _GetNearestNeighbors(int x, int y)
        {
            // Modulo (%) wraps edges safely: if x is 0, (0 - 1 + cols) % cols wraps to the far right side.
            int rows = _cellLifeMatrix.GetLength(0);
            int cols = _cellLifeMatrix.GetLength(1);
            int northY = (y - 1 + rows) % rows;
            int southY = (y + 1) % rows;
            int westX = (x - 1 + cols) % cols;
            int eastX = (x + 1) % cols;


            return new bool[]
            {
               _cellLifeMatrix[x, northY], // North
               _cellLifeMatrix[x, southY], // South
               _cellLifeMatrix[eastX, y],  // East
               _cellLifeMatrix[westX, y]   // West
            };
        }
    }
}
