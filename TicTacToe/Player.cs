using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        private string playerName;
        private State state;    //what it uses to play

        public Player(string playerName, State state)
        {
            //Constructor
            this.playerName = playerName;
            this.state = state;
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }   //Creating playerName (setter and getter)

        public int GetMove()
        {
            //Gets user input, makes sure it is valid and returns it
            int num;
            do
            {
                Console.WriteLine(this.playerName + " where do you want to play?\nEnter the number of an empty square between 1 and 9: ");
                num = Convert.ToInt16(Console.ReadLine()) - 1; //truncates by one so that the index can be zero-based...
                //...i did this because my calculations fo getting the 3x3 grid indices from the input number...
                //...works with zero-based indexing
            }
            while(!Board.CheckSquare(num)); //makes sure the input is valid
            return num;
        }

        public void ChangeSquare(int num)
        {
            //implements the move the player made
            int row = num / 3;
            int column = num % 3;
            Board.ChangeState(row, column, state);
            // i used num/3 and num%3 becuz i realized from my calculations that those were...
            //...the correct values for rows and columns respectively to change from the 0-8 numbers to the 3x3 grid 
        }

    }
}
