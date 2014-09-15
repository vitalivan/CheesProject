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
                    
                    Figure figure = board[i, j];

                    if (figure == null)
                    {
                        sym = "__";
                    }
                    else
                    {
                        sym = figure.Symbol;
                        if (figure.Color==FigureColor.Black)
                            sym=sym+"b";
                         else
                            sym=sym+"w";
                        
                    }

                    Console.Write(sym + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
