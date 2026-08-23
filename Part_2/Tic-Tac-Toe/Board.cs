// See https://aka.ms/new-console-template for more information
namespace BoardGame;

public class Board
{
    private bool debug = false;
    
    private Game TicTacToe = new Game(2);

    private int count = 0;

    private char[,] _table;
    public int Player {  get; private set; }
    public int TurnCount { get; private set; }
    public bool Draw { get; private set; }

    public Board()
    {
        _table = new char[3,3];
        Player = 0;
        TurnCount = 0;
        Draw = false;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _table[i, j] = ' ';
            }
        }
        
    }

    //Sets the current turn order
    public void Turn()
    {
        if (TicTacToe.NumPlayers == 2)
        {
            if (Player == 0) { Player = 1; TurnCount = 1; }
            else if (Player == 1) { Player = 2; TurnCount++; }
            else if (Player == 2) { Player = 1; TurnCount++; }
        }

    }

    //Places the players marker on the board based on how a numpad is set up, 7 being top left and 3 being bottom right
    public bool Place(double loc)
    {
        if (debug)
        {
            Console.WriteLine("Loc divided by 3 ceiling is: " + Math.Ceiling((loc / 3)));
        }

        if(Math.Ceiling(loc/3) == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if(i + 7 == loc)
                {
                    if (_table[0, i] == ' ')
                    {
                        if (Player == 1)
                        {
                            _table[0, i] = 'X';
                        } else
                        {
                            _table[0, i] = 'O';
                        }
                    } else
                    {
                        return false;
                    }
                }
                
            }
        } 
        else if (Math.Ceiling(loc / 3) == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i + 4 == loc)
                {
                    if (_table[1, i] == ' ')
                    {
                        if (Player == 1)
                        {
                            _table[1, i] = 'X';
                        }
                        else
                        {
                            _table[1, i] = 'O';
                        }
                    } 
                    else
                    {
                        return false;
                    }
                }

            }
        }
        else if (Math.Ceiling(loc / 3) == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i + 1 == loc)
                {
                    if (_table[2, i] == ' ')
                    {
                        if (Player == 1)
                        {
                            _table[2, i] = 'X';
                        }
                        else
                        {
                            _table[2, i] = 'O';
                        }
                    } 
                    else
                    {
                        return false;
                    }
                }

            }
        }
        else
        {
            
            return false;
        }

        return true;
    }

    public void PrintBoard()
    {

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {

                Console.Write(_table[i, j]);
                
                if(j != 2)
                {
                    Console.Write(" | ");
                }
                

            }
            Console.WriteLine();
            if(i != 2)
            {
                Console.WriteLine("----------");
            }
           
        }
    }

    public bool IsOver()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_table[i, j] != ' ')
                {

                    count++;

                    //checks for 3 in a row going right
                    if (j + 1 < 3 && j + 2 < 3)
                    {
                        if (_table[i, j + 1] == _table[i, j] && _table[i, j + 2] == _table[i, j])
                        {
                            return true;
                        }
                    }

                    //checks for 3 in a row going down
                    if (i - 1 > -1 && i - 2 > -1)
                    {
                        if (_table[i - 1, j] == _table[i, j] && _table[i - 2, j] == _table[i, j])
                        {
                            return true;
                        }
                    }

                    //checks for three in a row in a diangle going from top right to bottom left
                    if ((i - 1 > -1 && j - 1 > -1) && (i - 2 > -1 && j - 2 > -1))
                    {
                        if ((_table[i - 1, j - 1] == _table[i, j]) && (_table[i - 2, j - 2] == _table[i, j]))
                        {
                            return true;
                        }
                    }

                    //checks for 3 in a row in a diangle going from top left to bottom right
                    if ((i - 1 > -1 && j + 1 < 3) && (i - 2 > -1 && j + 2 < 3))
                    {
                        if (_table[i - 1, j + 1] == _table[i, j] && _table[i - 2, j + 2] == _table[i, j])
                        {
                            return true;
                        }
                    }

                    if(count == 9)
                    {
                        Draw = true;
                        return true;
                    }

                }
            }
        }

        count = 0;

        return false;
    }


}
