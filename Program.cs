using System;

namespace YahtzeeAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Cup cup = new Cup();

            int[][] answer = cup.RollVariableNumberOfDiceThreeTimes();

            foreach (int[] row in answer)
            {
                foreach (int die in row)
                {
                    Console.WriteLine(die);
                }
            }

            /*
            int[][] whichDiceToReroll = new int[][]
            {
                new int[] { 0 },
                new int[] { 1, 3 },
            };

            int[] numOfDiceRolling = new int[] { 5, 4, 3 };

            int[][] result = cup.RollDiceThreeTimesAskingWhichToReroll(whichDiceToReroll, numOfDiceRolling);

            foreach (int[] roll in result)
            {
                foreach (int number in roll)
                {
                    Console.WriteLine("{0} ", number);
                }
            }
            */
            
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


            // v1.6 allow the user to roll the dice 3 times
            // after each roll ask the player for the dice to re roll
            // print the ones asked to re-roll
            /*
            public int[][] RollDiceThreeTimesAskingWhichToReroll(int[][] whichDiceToReroll, int[] numOfDiceRolling)
            {
                int numOfRolls = 3;

                int[][] rerollLog = new int[2][];

                int rollCounter = 0;

                while (rollCounter < numOfRolls)
                {
                    // roll dice 3 times
                    for (int i = 0; i < numOfRolls; i++) // i = 0, 1, 2
                    {
                        // how many dice to roll on attempt 2 + 3
                        for (int j = 0; j < numOfDiceRolling[i]; j++) // j = 0, 1, 2
                        {
                            rerollLog[][] = random.Next(1, 7); 
                        }
                        rollCounter++;
                    }
                    
                }

                return rerollLog;
            }
            */
        }
    }
}

/*
    v1.7 display only the newly re-rolled dice
    v1.8 ensure previous dice are also displayed
    v1.9 if player has a yahtzee at any time, display it
*/
