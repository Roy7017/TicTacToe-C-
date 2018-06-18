using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
   class Square
   { 
        private State state;

        public Square (State state)   //constructor
        {
            this.state = state;
        }

        public State State { get; set; } = State.Undef; //state property
   }
}
