using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Board
    {
        object[,] board;

        public Board(int cols, int rows)
        { 
            board=new object[cols,rows];
        }

        public object this[int col, int row]
        {
            get { return board[col,row];}
        }

        public void MoveFigure(object figure, int col, int row)
        {
            throw new NotImplementedException();
        }
        public void AddFigure(object figure, int col, int row)
        {
            throw new NotImplementedException();
        }
    }
}
