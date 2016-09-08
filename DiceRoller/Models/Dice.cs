using System;

namespace DiceRoller.Models
{
    public class Dice
    {

        private int eyes;
        private int numRolls;
        private int outcome;
        private int totalSum;
        private int[] distribution;

        public int NumRolls
        {
            get
            {
                return numRolls;
            }
        }

        public int Outcome
        {
            get
            {
                return outcome;
            }
        }

        public int TotalSum
        {
            get
            {
                return totalSum;
            }
        }

        public int[] Distribution
        {
            get
            {
                return distribution;
            }
        }

        public decimal AvgScore
        {
            get
            {
                return Decimal.Divide(totalSum, numRolls);
            }
        }

        Random rnd = new Random();

        public Dice()
        {
            eyes = 6;
            numRolls = 0;
            totalSum = 0;
            distribution = new int[eyes];
        }

        public void Roll()
        {
            numRolls++;
            outcome = rnd.Next(1, 7);
            totalSum += outcome;
            distribution[outcome - 1]++;
        }

    }
}