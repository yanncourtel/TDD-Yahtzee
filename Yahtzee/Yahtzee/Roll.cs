using System;

namespace Yahtzee
{
    public class Roll
    {
        public Roll(Dice[] dices)
        {
            Dices = dices;
        }

        public Dice[] Dices { get; set; }
    }
}