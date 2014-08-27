using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Pawn
    {
        public Pawn(FigureColor color)
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

        public bool CheckMove(Move m,Board b)
        {
            if (m.ColFrom != m.ColTo)
            {
                return false;
            }
            if (Color == FigureColor.White)
            {
                if (m.RowTo - m.RowFrom != 1) return false;
            }
            else
            {
                if (m.RowTo - m.RowFrom != -1) return false;
            }
            if (b[m.ColTo, m.RowTo] != null) return false;

            return true;
        }
    
    }
}
