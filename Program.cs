using System;

namespace C20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            preformAnalisysOnBinaryNumbers();
        }
        public static void preformAnalisysOnBinaryNumbers()
        {
            int i_NumOfBinaryNumbers = 4;
            string[] output = new string[i_NumOfBinaryNumbers];
            Console.WriteLine("please enter 4 numbers in a binary format 8 digit each: ");
            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                output[i] = getInputFromUser();
                bool i_isValidBinaryNum = checkIfInputIsValid(output[i]);
                if (!i_isValidBinaryNum)
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }
            }
            int i_AverageNumbersOfOnes;
            int i_AverageNumbersOfzero = caluculateAverageNumbersOfACertainCharecter(output, i_NumOfBinaryNumbers, '0');
            int i_AverageNumbersOfOnes = caluculateAverageNumbersOfACertainCharecter(output, i_NumOfBinaryNumbers, '1');
            int i_HowManyArePowerOfTwo = checkHowManyArePowerOfTWO(output, i_NumOfBinaryNumbers);
            int HowManyAreAscendingSeries = checkHowManyAreAscendingSeries(output, i_NumOfBinaryNumbers);
            float i_averageOfNumbers = calculateAverageOfNumbers(output, i_NumOfBinaryNumbers);
        }


        private static String getInputFromUser()
        {
            string io_BinaryNumber = Console.ReadLine();
            return io_BinaryNumber;
        }
        private static bool checkIfInputIsValid(string i_binaryNum)
        {
            if (i_binaryNum.Length != 8)
            {
                return false;
            }
            for (int i = 0; i < i_binaryNum.Length; i++)
            {
                if (i_binaryNum[i] != '1' && i_binaryNum[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        private static float caluculateAverageNumbersOfACertainCharecter(string[] BinaryNumbers, int i_NumOfBinaryNumbers)
        {
            float i_numOfZeros = 0;

            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                for (int j = 0; j < BinaryNumbers[i].Length; j++)
                {
                    if (BinaryNumbers[i][j] == '0')
                    {
                        i_numOfZeros++;
                    }

                }
            }
            float o_AverageNumberOfZeros = i_numOfZeros / i_NumOfBinaryNumbers;// Calculate average number of zeros.
            return o_AverageNumberOfZeros; // Returns average number of zeros.
        }



        private static float caluculateAverageNumbersOfACertainCharecter(string[] BinaryNumbers, int i_NumOfBinaryNumbers, char i_ChosenCharecter)
        {
            float i_numOfChars = 0;

            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                for (int j = 0; j < BinaryNumbers[i].Length; j++)
                {
                    if (BinaryNumbers[i][j] == i_ChosenCharecter)
                    {
                        i_numOfChars++;
                    }

                }
            }
            float O_AverageNumberOfChar = i_numOfOnes / i_NumOfBinaryNumbers;// Calculate average number of a certain character.
            return O_AverageNumberOfChar; // Returns average number of a certain character.
        }


        private static int checkHowManyArePowerOfTWO(string[] i_BinaryNumbers, int i_NumOfBinaryNumbers)
        {
            int o_AmountOfNumbersWhichIsPowerOfTwo = 0;
            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                int i_BinaryNum = convertBinaryStringtToInt(i_BinaryNumbers[i]);
                if (IsPowerOfTwo(BinaryNum))
                {
                    o_AmountOfNumbersWhichIsPowerOfTwo++;
                }
            }
            return o_AmountOfNumbersWhichIsPowerOfTwo;
        }


        private static int convertBinaryStringtToInt(string i_BinaryNum)
        {
            int o_ActualBinaryNumber = 0;
            int i_BinaryDigit;
            int i_CurrentPower = 1;
            for (int i = i_BinaryNum.Length - 1; i > 0; i++)
            {
                i_BinaryDigit = i_BinaryNum[i] - '0';// Calculate the int value of the character.
                o_ActualBinaryNumber += (i_CurrentPower * i_BinaryDigit);
                i_CurrentPower *= 2; //Prepare the current power for next iteration.
            }
            return o_ActualBinaryNumber;
        }


        private static bool IsPowerOfTwo(int i_num)
        {
            if (i_num && (i_num - 1) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int checkHowManyAreAscendingSeries(string[] i_BinaryNumbers, inst i_AmountOfBinaryNumbers)
        {
            int o_HowManyAreAscendingSeries = 0;
            int i_BinaryNum;
            for (int i = 0; i < i_AmountOfBinaryNumbers; i++)
            {
                i_BinaryNum = convertBinaryStringtToInt(i_BinaryNumbers[i]);
                if (isAscendingSeries(i_BinaryNum))
                {
                    o_HowManyAreAscendingSeries++;
                }
            }
            return o_HowManyAreAscendingSeries;
        }

        private static float calculateAverageOfNumbers(string[] i_BinaryNumbers, int i_NumOfBinaryNumbers)
        {
            float i_SumOfAllBinaryNumbers = 0;
            for(int i= 0; i<i_NumOfBinaryNumbers; i_NumOfBinaryNumbers++)
            {
                i_SumOfAllBinaryNumbers += convertBinaryStringtToInt(i_BinaryNumbers[i]);
            }
            int o_Average = i_SumOfAllBinaryNumbers / i_NumOfBinaryNumbers;
            return o_Average;
        }
            

    }
   
}