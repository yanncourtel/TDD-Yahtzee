using System;

namespace Yahtzee
{
    public class InvalidRollException : Exception
    {
        public InvalidRollException() : base("A roll must have 5 dices")
        {
        }
    }
}