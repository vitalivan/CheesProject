using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Bishop
    {
        public Bishop(FigureColor color)
        {
            this.color = color;
        }
        FigureColor color;
        public FigureColor Color
        {
            get { return color; }
        }
        int col;
        public int Column
        {
            get { return col; }
            set { col = value; }
        }
        int row;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public bool CheckMove(Move m, Board board)
        {
            //TODO:Write move check

            return true;

        }
    
    }
}
