﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class RollShould
    {
        [Fact]
        public void Have_5_Dices()
        {
            // arrange
            var dices = new Dice[] {new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1)};
            
            // act
            var roll = new Roll(dices);
            
            // assert
            roll.Dices.Should().HaveCount(5);
        }
        
        [Fact]
        public void Not_Have_Less_Than_5_Dices()
        {
            // arrange
            var dices = new Dice[] {new Dice(1), new Dice(1)};
            
            // act
            Action result = ()=> new Roll(dices);
            
            // assert
            result.Should().Throw<InvalidRollException>()
                .WithMessage("A roll must have 5 dices");

        }
        
        [Fact]
        public void Not_Have_More_Than_5_Dices()
        {
            // arrange
            var dices = new Dice[] {new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1)};
            
            // act
            Action result = ()=> new Roll(dices);
            
            // assert
            result.Should().Throw<InvalidRollException>()
                .WithMessage("A roll must have 5 dices");

        }
        
        [Fact]
        public void Not_Have_Null_Dices()
        {
            // arrange
            
            // act
            Action result = ()=> new Roll(null);
            
            // assert
            result.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void Return_Dice_Values()
        {
            // arrange
            var dices = new Dice[] {new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1)};
            var roll = new Roll(dices);

            // act
            var result = roll.GetDicesValues();
            // assert
            result.Should().Be(expected);
        }

    }
}
