using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static int[,] board;
        static Board brd;
        static Move ReadMove()
        {
            int iFrom,jFrom,iTo,jTo;
            iFrom = 0;
            jFrom = 0;
            iTo = 0;
            jTo = 0;
            bool reading = true;
            do
            {
                Console.WriteLine("Your turn: ");
                string[] cmd = Console.ReadLine().Split(' ');
                if (cmd.Length != 4)
                {
                    Console.WriteLine("Enter 4 numbers ");
                    continue;
                }
                try
                {
                    iFrom = int.Parse(cmd[0])-1;
                    jFrom = int.Parse(cmd[1])-1;
                    iTo = int.Parse(cmd[2])-1;
                    jTo = int.Parse(cmd[3])-1;

                    if (iFrom < 0 || iFrom > 7) continue;
                    if (jFrom < 0 || jFrom > 7) continue;
                    if (iTo < 0 || iTo > 7) continue;
                    if (jTo < 0 || jTo > 7) continue;
                   
                    reading = false;
                }
                catch
                {
                    Console.WriteLine("Enter 4 numbers ");
                    continue;
                }
           
            }while(reading);
            return new Move(iFrom, jFrom, iTo, jTo);
        }
        static void PlaceFigures(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                Pawn p = new Pawn(FigureColor.White);
                board.AddFigure(p, i, 1);

                p = new Pawn(FigureColor.Black);
                board.AddFigure(p, i, 6);
            }
            
            
            Rook r = new Rook(FigureColor.White);// добавлена ладья
            board.AddFigure(r, 0, 0);
            board.AddFigure(r, 0, 7);
            r = new Rook(FigureColor.Black);
            board.AddFigure(r, 7, 0);
            board.AddFigure(r, 7, 7);
            
            //board[0,0]=board[0,7]=2;//Ладья
            //board[7,0]=board[7,7]=-2;
        }
        static bool CheckMove(Move move,FigureColor currentPlayerColor)
        {
            if (brd[move.ColFrom,move.RowFrom] == null)
            {
                return false;  
            }
            FigureColor colorFrom;
            //Принадлежит ли фигура игроку
            object figure=brd[move.ColFrom,move.RowFrom];
            if(figure is Rook)
            {
                colorFrom = (figure as Rook).Color;
            }
            else if (figure is Pawn)
            {
                colorFrom = (figure as Pawn).Color;
            }
            else
            {
                throw new ApplicationException("Unknown figure type");
            }
            if (colorFrom != currentPlayerColor)
            {
                return false;
            }

            //Проверка, ходит ли фигура таким образом
            if (figure is Rook)
            {
                if ((figure as Rook).CheckMove(move,brd) == false)
                    return false;
            }
            else if (figure is Pawn)
            {
                if ((figure as Pawn).CheckMove(move, brd) == false)
                    return false;
            }
            else
            {
                throw new ApplicationException("Unknown figure type");
            }
            // Конец проверки, ходит ли фигура таким образом
           
            object fig2 = brd[move.ColTo, move.RowTo];
            if (fig2 != null)
            {
                FigureColor colorTo;
                if (fig2 is Rook)
                {
                    colorTo = (fig2 as Rook).Color;
                }
                else if (fig2 is Pawn)
                {
                    colorTo = (fig2 as Pawn).Color;
                }
                else
                {
                    throw new ApplicationException("Unknown figure type");
                }
                if (colorFrom == colorTo)
                {
                    return false;
                }
            }
            return true;

        }

        static void Main(string[] args)
        {
            brd = new Board(8, 8);
            PlaceFigures(brd);
            FigureColor currentPlayerColor = FigureColor.White;

            int i1, j1, i2, j2;


            Move move;

            while (true)
            {
                brd.PrintBoard();

                move = ReadMove();
                if (CheckMove(move, currentPlayerColor))
                {
                    brd.ApplyMove(move);
                }
                if (currentPlayerColor == FigureColor.White)
                    currentPlayerColor = FigureColor.Black;
                else
                    currentPlayerColor = FigureColor.White;
            }
            i1 = move.ColFrom;
            j1 = move.RowFrom;
            i2 = move.ColTo;
            j2 = move.RowTo;
            
           
            
            board = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                board[1, i]=1;
                board[6, i]=-1;
            }

            bool moveWhite = true;

            while (true)
            {
                for (int j = 7; j >= 0; j--)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("{0} ", board[j, i]);
                    }
                    Console.WriteLine();
                }


                
                bool reading = true;
                
                do
                {
                    move = ReadMove();

                    i1 = move.ColFrom;
                    j1 = move.RowFrom;
                    i2 = move.ColTo;
                    j2 = move.RowTo;


                    if (board[j1, i1] == 0)
                    {
                        Console.WriteLine("There is no figure on this cell");
                        continue;
                    }
                    if (moveWhite && board[j1, i1] < 0)
                    {
                        Console.WriteLine("White move");
                        continue;
                    }
                    if (!moveWhite && board[j1, i1] > 0)
                    {
                        Console.WriteLine("Black move");
                        continue;
                    }
                    if (board[j1, i1] == 1 || board[j1, i1] == -1)
                    {
                        bool correctMove = true;
                        if (i1 != i2)
                        {
                            correctMove = false;

                        }
                        if (board[j1, i1] == 1)
                        {
                            if (j2 - j1 != 1) correctMove = false;
                            if (board[j2, i2] == -1) correctMove = false;

                        }
                        else
                        {
                            if (j2 - j1 != -1) correctMove = false;
                            if (board[j2, i2] == 1) correctMove = false;
                        }
                        if (!correctMove)
                        {
                            Console.WriteLine("Wrong move");
                            continue;
                        }
                        reading = false;

                    }
                    if (board[j1, i1] == 2 || board[j1, i1] == -2)
                    {
                        bool correctMove = true;
                        if (i1 != i2 && j1 != j2)
                        {
                            correctMove = false;
                        }
                        else
                        {
                            if (i1 == i2)
                            {
                                int a = Math.Min(j1, j2);
                                int b = Math.Max(j1, j2);
                                for (int jx = a + 1; jx < b; jx++)
                                {
                                    if (board[jx, i1] != 0) correctMove = false;
                                }
                            }
                            else
                            {
                                int a = Math.Min(i1, i2);
                                int b = Math.Max(i1, i2);
                                for (int ix = a + 1; ix < b; ix++)
                                {
                                    if (board[j1, ix] != 0) correctMove = false;
                                }
                            }
                            if ((board[j1, i1] > 0 && board[j2, i2] > 0) || (board[j1, i1] < 0 && board[j2, i2] < 0))
                            {
                                correctMove = false;
                            }
                        }
                        if (!correctMove)
                        {
                            Console.WriteLine("Wrong move");
                            continue;
                        }
                        reading = false;
                    }

                   } while (reading);

                board[j2, i2] = board[j1, i1];
                board[j1, i1] = 0;

                moveWhite = !moveWhite;
            }
            
            
            Console.WriteLine("END OF THE GAME");
            Console.ReadKey();
        }
    }
}
