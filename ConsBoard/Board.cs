using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Board
    {
        Figure[,] board;
        public int Columns { get; private set; }
        public int Rows { get; private set; }

        public Board(int cols, int rows)
        { 
            board=new Figure[cols,rows];
            Columns = cols;
            Rows = rows;
        }

        public Figure this[int col, int row]
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

            Figure figure=board[move.ColTo,move.RowTo];
            figure.Row = move.RowTo;
            figure.Column = move.ColTo;
           
        }
        
        public void AddFigure(Figure figure, int col, int row)
        {
            board[col,row]=figure;

            figure.Row = row;
            figure.Column = col;

         
        }

        internal void PrintBoard()
        {
            for (int j = Rows-1; j >= 0; j--)
            {
                for (int i = 0; i < Columns; i++)
                {
                    string sym = "";
                    
                    object figure = board[i, j];

                    if (figure == null)
                    {
                        sym = "__";
                    }
                    else
                    {
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
                        else if (figure is Bishop)
                        {
                            sym = "B";
                            FigureColor color = (figure as Bishop).Color;
                            if (color == FigureColor.Black)
                                sym = sym + "b";
                            else
                                sym = sym + "w";
                        }

                        else
                        {
                            throw new ApplicationException("Unknown figure type");
                        }
                    }

                    Console.Write(sym + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
