using System;
using System.Collections.Generic;

namespace YahtzeeAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Cup cup = new Cup();

            int numberOfDice = 5;
            int numberOfRolls = 3;

            // int result = dice.RollOneDice(numberOfDice);

            // int[] rollResult = cup.RollFiveDice(numberOfDice);
            //foreach (int number in rollResult)
            //{
            //    Console.WriteLine(number);
            //}

            int[,] result = cup.RollFiveDiceThreeTimes(numberOfRolls, numberOfDice);

            foreach (int roll in result)
            {
                Console.Write("{0} ", roll);
            }
        }

        public class Dice
        {
            Random random = new Random();

            // v1.0 create a function to roll ONE 6 sided dice
            public int RollOneDice(int numberOfDice)
            {
                return random.Next(1, 7);
            }
        }

        public class Cup
        {
            Random random = new Random();

            // v1.1 create a function to roll FIVE 6 sided dice
            public int[] RollFiveDice(int numberOfDice)
            {
                int[] result = new int[numberOfDice];

                for (int i = 0; i < numberOfDice; i++)
                {
                    result[i] = random.Next(1, 7);
                }
                return result;
            }

            // v1.2 Create a Game loop to roll all FIVE dice 3 times
            public int[,] RollFiveDiceThreeTimes(int numOfRolls, int numOfDice)
            {
                // int[,] 2dArray = new int[rows, collumns]
                int[,] result = new int[numOfRolls, numOfDice];

                int index1 = 0;

                while (index1 < numOfRolls)
                {
                    for (int i = 0; i < numOfDice; i++)
                    {
                        result[index1, i] = random.Next(1, 7);
                    }
                    index1++;
                }

                return result;
            }
        }
    }
}

/*
    v1.3 allow the user to pick ONE dice to reroll (+ print the one they picked)
    v1.4 allow the user to pick multiple dice to reroll (+ print them)
    v1.5 allow the user to roll a set number of dice
    v1.6 allow the user to roll the dice 3 times
        after each roll ask the player for the dice to re roll
        re-roll those dice
    v1.7 display only the newly re-rolled dice
    v1.8 ensure previous dice are also displayed
    v1.9 if player has a yahtzee at any time, display it
*/
