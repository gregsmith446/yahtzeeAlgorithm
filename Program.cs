using System;
using System.Linq;

namespace YahtzeeAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Cup cup = new Cup();


            // the dice the user wants to reroll
            int[] toReRoll1 = new int[] { 0, 1 };
            int[] toReRoll2 = new int[] { 0, 1 };

            cup.RollDiceThreeTimesAskingWhichToReroll(toReRoll1, toReRoll2);
        }

        public class Dice
        {
            Random random = new Random();

            public int RollOneDice()
            {
                return random.Next(1, 7);
            }
        }

        public class Cup
        {
            Random random = new Random();

            public int[] RollFiveDiceOnce(int numberOfDice)
            {
                int[] result = new int[numberOfDice];

                for (int i = 0; i < numberOfDice; i++)
                {
                    result[i] = random.Next(1, 7);
                }
                return result;
            }

            public int[,] RollAllFiveDiceThreeTimes(int numOfRolls, int numOfDice)
            {
                int[,] result = new int[numOfRolls, numOfDice];

                int rollCount = 0;

                while (rollCount < numOfRolls)
                {
                    for (int i = 0; i < numOfDice; i++)
                    {
                        result[rollCount, i] = random.Next(1, 7);
                    }
                    rollCount++;
                }
                return result;
            }

            public int UserPicksOneDieToReroll(int[] rollResult, int pick)
            {
                return rollResult[pick];
            }

            public int[] UserPicksMultipleDieToReroll(int[] rollResult, int numOfDicePicking, int[] choices)
            {
                int[] picks = new int[numOfDicePicking];

                for (int i = 0; i < choices.Length; i++)
                {
                    picks[i] = rollResult[choices[i]];   
                }
                    return picks;
            }

            public int[] RollVariableNumberOfDiceOnce(int amountToRoll)
            {
                int[] result = new int[amountToRoll];

                for (int i = 0; i < amountToRoll; i++)
                {
                    result[i] = random.Next(1, 7);
                }
                return result;
            }

            public int[][] RollVariableNumberOfDiceThreeTimes()
            {
                int roll1 = 5;
                int roll2 = 4;
                int roll3 = 3;

                int[][] rolls = new int[3][];
                rolls[0] = new int[5];
                rolls[1] = new int[4];
                rolls[2] = new int[3];

                int rollCounter = 0;

                while (rollCounter < 3)
                {
                    for (int i = 1; i < roll1; i++)
                    {
                        rolls[rollCounter][i] = random.Next(1, 7);
                    }
                    rollCounter++;
                    for (int i = 1; i < roll2; i++)
                    {
                        rolls[rollCounter][i] = random.Next(1, 7);
                    }
                    rollCounter++;
                    for (int i = 1; i < roll3; i++)
                    {
                        rolls[rollCounter][i] = random.Next(1, 7);
                    }
                    rollCounter++;
                }
                return rolls;
            }


            // v1.6 allow the user to roll the dice 3 times, after each roll ask the player for the dice to re roll, then print the ones asked to re-roll
            // v1.7 display only the newly re-rolled dice
            // v1.8 ensure previous dice are also displayed
            // v1.9 if player has a yahtzee at any time, display it
            public void RollDiceThreeTimesAskingWhichToReroll(int[] diceToReroll1, int[] diceToReroll2)
            {
                int[] roll1 = new int[5];
                int[] roll2 = new int[diceToReroll1.Length];
                int[] roll3 = new int[diceToReroll2.Length];

                int rollCounter = 0;

                while (rollCounter < 3)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        roll1[i] = random.Next(1, 7);
                    }
                        Console.WriteLine("The results of roll 1");
                        foreach (int dice in roll1)
                        {
                            Console.WriteLine(dice);
                        }
                       
                    if (roll1.Distinct().Count() == 1)
                    {
                        Console.WriteLine("Yahtzee!");
                    }
                    Console.WriteLine("Not Yahtzee");

                    rollCounter++;

                    for (int i = 0; i < diceToReroll1.Length; i++)
                    {
                        Console.WriteLine("Dice being re-rolled: {0}", roll1[diceToReroll1[i]]);
                        roll1[diceToReroll1[i]] = random.Next(1, 7);
                    }
                        Console.WriteLine("The results of re-roll 2");
                        foreach (int dice in roll1)
                        {
                            Console.WriteLine(dice);
                        }

                    if (roll1.Distinct().Count() == 1)
                    {
                        Console.WriteLine("Yahtzee!");
                    }
                    Console.WriteLine("Not Yahtzee");

                    rollCounter++;

                    for (int i = 0; i < diceToReroll2.Length; i++)
                    {
                        Console.WriteLine("Dice being re-rolled: {0}", roll1[diceToReroll2[i]]);
                        roll1[diceToReroll2[i]] = random.Next(1, 7);
                    }
                        Console.WriteLine("The results of re-roll 3");
                        foreach (int dice in roll1)
                        {
                            Console.WriteLine(dice);
                        }

                    if (roll1.Distinct().Count() == 1)
                    {
                        Console.WriteLine("Yahtzee!");
                    }
                    Console.WriteLine("Not Yahtzee");

                    rollCounter++;
                }  
            }
        }
    }
}

