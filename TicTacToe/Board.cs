using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class Board
    {
        private static Square[][] grid = new Square[3][];  //this is the grid that has information on the state of the board
        private static State winState; // a variable to contain the state (or character) of the player that wins

        static Board ()
        {
            for (int i = 0; i < 3; i++)
            {
                grid[i] = new Square[3]; // this was to initialize the sub-arrays of the grid
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i][j] = new Square(State.Undef); //all the inndividual squares are initialized to empty (undef)     
                }
            }
        }

        public static State WinState
        {
            get
            {
                return winState;
            }
            set
            {
                winState = value;
            }
        } // creating winState property 

        static public void Print()
        {
            //renders the board...
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" " + (char)grid[i][0].State + " | " + (char)grid[i][1].State + " | " + (char)grid[i][2].State + "\n");
                // print the board with characters of respective states and puts suitable characters
                if (i < 2) Console.WriteLine("---+---+---\n"); //i.e puts the bottom only for the first two lines
            }
        }

        static public void ChangeState(int row, int column, State state)
        {
            //changes the state of the square with position (row, column)
            // ...to the new state
            grid[row][column].State = state;
        }

        static public bool CheckWin()
        {
            //this method checks for a win
            bool flag = false; // just initializing my boolean ;)
            for (int i = 0; i < 3; i++)
            {
                if ((grid[i][0].State == grid[i][1].State && grid[i][1].State == grid[i][2].State) && (grid[i][0].State != State.Undef))
                {
                    flag = true;
                    winState = grid[i][0].State;
                }
            }//we check all the rows if there is same state across any of them and if sure in question is not undef  

            for (int i = 0; i < 3; i++)
            {
                if ((grid[0][i].State == grid[1][i].State && grid[1][i].State == grid[2][i].State) && (grid[0][i].State != State.Undef))
                {
                    flag = true;

                    winState = grid[0][i].State;
                }
            }//we check all the columns if there is the same state across any of them and if the state in question is not undef

            if ((grid[0][0].State == grid[1][1].State && grid[1][1].State == grid[2][2].State) && (grid[0][0].State != State.Undef))
            {
                flag = true;
                winState = grid[0][0].State;
            }
            //we check the leading diagonal for a match and if the matched state is not undef

            if ((grid[2][0].State == grid[1][1].State && grid[1][1].State == grid[0][2].State) && (grid[2][0].State != State.Undef))
            {
                flag = true;
                winState = grid[2][0].State;
            }
            //check the non-leading diagonal for a match and if the matched state is not undef

            return flag;
        }

        public static bool CheckDraw()
        {
            //checks if there is a draw
            bool flag;
            if (!CheckWin())       // if no player has won yet...
            {
                flag = true;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i][j].State == State.Undef)  //...and all the squares are not empty, there is a draw..
                            flag = false;       //becuz if atleast one of them is empty, then the draw is false.
                    }
                }
            }

            else flag = false; // if any if them has alredy won then there cannot be a draw... obviously

            return flag;
        }

        public static bool CheckSquare(int row, int column)
        {
            //checks if a valid square is free for a player move
            bool flag;
            int num = (3 * row) + column;
            if (num < 0 || num > 8) // if the num is valid
                flag = false;                         
            else if (grid[row][column].State == State.Undef)
                flag = true;
            else
                flag = false;
            return flag;
        }
    }
}
