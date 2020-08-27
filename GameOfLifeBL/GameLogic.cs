using GameOfLifeBL.Models;
using System;

namespace GameOfLifeBL
{
    public static class GameLogic
    {

        public static Cell[,] Play(Cell[,] board)
        {

            Cell[,] next = (Cell[,])board.Clone();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    next[i, j] = new Cell { Alive = true };
                }
            }

            return next;
        }



    }
}
