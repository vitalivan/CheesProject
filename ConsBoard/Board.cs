using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Board
    {
        object[,] board;
        public int Columns { get; private set; }
        public int Rows { get; private set; }

        public Board(int cols, int rows)
        { 
            board=new object[cols,rows];
            Columns = cols;
            Rows = rows;
        }

        public object this[int col, int row]
        {
            get { return board[col,row];}
        }

        public void MoveFigure(object figure, int col, int row)
        {
            throw new NotImplementedException();
        }

        public void ApplyMove(Move move)
        {
            board[move.ColTo,move.RowTo]=board[move.ColFrom,move.RowFrom];
            board[move.ColFrom,move.RowFrom]=null;

            object figure=board[move.ColTo,move.RowTo];
            if (figure is Rook)
            {
                (figure as Rook).Row=move.RowTo;
                (figure as Rook).Column=move.ColTo;
            }
            else if (figure is Pawn)
            {
                (figure as Pawn).Row = move.RowTo;
                (figure as Pawn).Column = move.ColTo;
            }
            else
            {
                throw new ApplicationException("Unknown figure type");
            }
        }
        
        public void AddFigure(object figure, int col, int row)
        {
            board[col,row]=figure;

            if (figure is Rook)
            {
                (figure as Rook).Row = row;
                (figure as Rook).Column = col;
            }
            else if (figure is Pawn)
            {
                (figure as Pawn).Row = row;
                (figure as Pawn).Column = col;
            }
            else
            {
                throw new ApplicationException("Unknown figure type");
            }
        }

        internal void PrintBoard()
        {
            for (int j = Rows - 1; j >= 0; j--)
            {
                for (int i = 0; i < Columns; i++)
                {
                    string sym = "";
                    object figure = board[i, j];
                    if (figure is Rook)
                    {
                        sym = "R";
                        FigureColor color = (figure as Rook).Color;
                        if (color == FigureColor.Black)
                            sym = sym + "b";
                        else
                            sym = sym + "w";
                    }
                    else if (figure is Pawn)
                    {
                        sym = "P";
                        FigureColor color = (figure as Pawn).Color;
                        if (color == FigureColor.Black)
                            sym = sym + "b";
                        else
                            sym = sym + "w";
                    }
                    else
                    {
                        throw new ApplicationException("Unknown figure type");
                    }
                    Console.Write(sym + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
