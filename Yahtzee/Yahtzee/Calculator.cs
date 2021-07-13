using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Yahtzee
{
    public class Calculator
    {
        public int Calculate(Roll roll, Combination combination)
        {
            if (roll == null)
            {
                throw new ArgumentNullException();
            }

            var dicesValues = roll.GetDicesValues();

            return combination switch
            {
                Combination.Ones => dicesValues.Where(x => x == 1).Sum(),
                Combination.Twos => dicesValues.Where(x => x == 2).Sum(),
                Combination.Threes => dicesValues.Where(x => x == 3).Sum(),
                Combination.Fours => dicesValues.Where(x => x == 4).Sum(),
                Combination.Fives => dicesValues.Where(x => x == 5).Sum(),
                Combination.Sixes => dicesValues.Where(x => x == 6).Sum(),
                Combination.Chance => dicesValues.Sum(),
                Combination.LargeStraight => IsLargeStraight(dicesValues) ? 40 : 0,
                Combination.SmallStraight => IsSmallStraight(dicesValues) ? 30 : 0,
                Combination.Yahtzee => dicesValues.Count(x => x == dicesValues[0]) == 5 ? 50 : 0,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private bool IsSmallStraight(int[] dicesValues)
        {
            return dicesValues.Intersect(new int[] {1, 2, 3, 4}).Count() == 4 ||
                   dicesValues.Intersect(new int[] {2, 3, 4, 5}).Count() == 4 ||
                   dicesValues.Intersect(new int[] {3, 4, 5, 6}).Count() == 4;
        }

        private bool IsLargeStraight(int[] dicesValues)
        {
            return dicesValues.Intersect(new int[] {1, 2, 3, 4, 5}).Count() == 5 ||
                   dicesValues.Intersect(new int[] {2, 3, 4, 5, 6}).Count() == 5;
        }
    }
}