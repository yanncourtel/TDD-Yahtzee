using System;

namespace Yahtzee
{
    public class Roll
    {
        public Roll(Dice[] dices)
        {
            if (dices == null)
                throw new ArgumentNullException(nameof(dices));
            
            Dices = dices.Length == 5 ? dices : throw new InvalidRollException();
        }

        public Dice[] Dices { get; set; }
    }
}