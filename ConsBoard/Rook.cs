using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Rook
    {
        public Rook(FigureColor color)
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

            if (m.ColFrom != m.ColTo && m.RowFrom != m.RowFrom)
            {
                return false;
            }


            if (m.ColFrom == m.ColTo)
            {
                int a = Math.Min(m.RowFrom, m.RowTo);
                int b = Math.Max(m.RowFrom, m.RowTo);
                for (int jx = a + 1; jx < b; jx++)
                {
                    if (board[m.ColFrom, jx] != null) return false;
                }
            }
            else
            {
                int a = Math.Min(m.ColFrom, m.ColTo);
                int b = Math.Max(m.ColFrom, m.ColTo);
                for (int ix = a + 1; ix < b; ix++)
                {
                    if (board[ix, m.RowFrom] != null) return false;
                }
            }
            return true;

        }
    }
}
