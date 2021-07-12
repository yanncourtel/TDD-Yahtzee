using System;

namespace Yahtzee
{
    public class InvalidDiceException : Exception
    {
        public InvalidDiceException() : base("Your dices are invalid")
        {
        }

        public InvalidDiceException(string message) : base(message)
        {
        }
    }
}