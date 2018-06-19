using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum State { Undef = ' ', X = 'X', O = 'O' }; // Define a state of a square on the board

    class Program
    {
        static void Main(string[] args)
        {
            //START OF GAME AND INITIALIZATIONS
            Player player1; // creating players 1 and 2
            Player player2;
            string name;
            Console.WriteLine("Hello, welcome to my Tic-Tac-Toe game\n");
            Console.WriteLine("Player 1 please enter your name: ");
            name = Console.ReadLine();
            player1 = new Player(name, State.O);  //calling its constructor to initialize the names...
            Console.WriteLine("Player 2 please enter your name: ");
            name = Console.ReadLine();            //...and same here
            player2 = new Player(name, State.X);

            //GAMEPLAY AND TURN BASES

            Console.WriteLine("START!!!\n\n");
            int moveNumber;
            do
            {
                //START OF GAMEPLAY LOOP
                //PLAYER ONE TURN
                Board.Render();
                Console.WriteLine(player1.PlayerName + " Your turn\n");
                moveNumber = player1.GetMove();  //registers player1's valid move...
                player1.ChangeSquare(moveNumber);//...and implements it

                //ENDGAME CHECK
                if (Board.CheckWin() || Board.CheckDraw()) //exits gameplay loop if there is draw or win
                    break;

                //PLAYER TWO TURN
                Board.Render();
                Console.WriteLine(player2.PlayerName + " Your turn\n");
                moveNumber = player2.GetMove();  //registers pllayer2's valid move...
                player2.ChangeSquare(moveNumber);//...and implements it

                //ENDGAME CHECK
                if (Board.CheckWin() || Board.CheckDraw()) //exits gameplay loop if there is a draw or win
                    break;

            } while (true);

            Board.Render();

            //ENDGAME AND WIN ANNOUNCEMENTS

            if (Board.CheckWin())
            {
                //WIN MESSAGES
                if (Board.WinState == State.O)
                    Console.WriteLine( "\n" + player1.PlayerName + " Wins\n");
                else
                    Console.WriteLine( "\n" + player2.PlayerName + " Wins\n");
            }

            else
                Console.WriteLine("DRAW!!\nNobody Wins");
            Console.ReadKey();
        }
    }
}
