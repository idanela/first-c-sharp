using System;

namespace C20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            preformAnalysisOnBinaryNumbers();
        }
        public static void preformAnalysisOnBinaryNumbers() //Preform analysis on a few binary numbers.
        {
            int i_NumOfBinaryNumbers = 4;
            string[] output = new string[i_NumOfBinaryNumbers]; //allocates a string array which will hold the numbers from user's input.
            Console.WriteLine("please enter 4 numbers in a binary format 8 digit each: ");
            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                output[i] = getInputFromUser();
                bool i_isValidBinaryNum = checkIfInputIsValid(output[i]); // Checks if the user inserted a valid string(8 number string of 1's and 0's).
                if (!i_isValidBinaryNum)
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }
            }
            float i_AverageNumbersOfZero = caluculateAverageNumbersOfACertainCharecter(output, i_NumOfBinaryNumbers, '0');//Gets average number of 0's from all string that were inserted.
            float i_AverageNumbersOfOnes = caluculateAverageNumbersOfACertainCharecter(output, i_NumOfBinaryNumbers, '1');//Gets average number of 1's from all string that were inserted.
            int i_HowManyArePowerOfTwo = checkHowManyArePowerOfTWO(output, i_NumOfBinaryNumbers);
            int HowManyAreAscendingSeries = checkHowManyAreAscendingSeries(output, i_NumOfBinaryNumbers);
            float i_averageOfNumbers = calculateAverageOfNumbers(output, i_NumOfBinaryNumbers);
        }


        private static String getInputFromUser() //Gets input fron user.
        {
            string io_BinaryNumber = Console.ReadLine();
            return io_BinaryNumber;
        }
        private static bool checkIfInputIsValid(string i_binaryNum)// Checks if a string has 8 characters and only 1's and 0's.
        {
            if (i_binaryNum.Length != 8) // If the number is not an 8-bit number its not valid.
            {
                return false;
            }
            for (int i = 0; i < i_binaryNum.Length; i++)
            {
                if (i_binaryNum[i] != '1' && i_binaryNum[i] != '0')// If the number is not containing only 1's and 0's its not valid.
                {
                    return false;
                }
            }
            return true;
        }
        
        private static float caluculateAverageNumbersOfACertainCharecter(string[] BinaryNumbers, int i_NumOfBinaryNumbers, char i_ChosenCharecter)//Calculates the average apperances of a cerain character in a string array.
        {
            float i_NumOfChars = 0;

            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                for (int j = 0; j < BinaryNumbers[i].Length; j++)
                {
                    if (BinaryNumbers[i][j] == i_ChosenCharecter)// For each character in the sring check if the chosen character.
                    {
                        i_NumOfChars++;
                    }

                }
            }
            float O_AverageNumberOfChar = i_NumOfChars / i_NumOfBinaryNumbers;// Calculate average number of a certain character.
            return O_AverageNumberOfChar; // Returns average number of a certain character.
        }


        private static int checkHowManyArePowerOfTWO(string[] i_BinaryNumbers, int i_NumOfBinaryNumbers)// Checks how many strings (which represent a binary number) are a power of two.
        {
            int o_AmountOfNumbersWhichIsPowerOfTwo = 0;
            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                int i_BinaryNum = convertBinaryStringtToInt(i_BinaryNumbers[i]); //converts a string to the binary number that its represent.
                if (IsPowerOfTwo(i_BinaryNum))
                {
                    o_AmountOfNumbersWhichIsPowerOfTwo++;
                }
            }
            return o_AmountOfNumbersWhichIsPowerOfTwo;
        }


        private static int convertBinaryStringtToInt(string i_BinaryNum) // convert a string that represent a binary number to it's decimal form.
        {
            int o_ActualBinaryNumber = 0;
            int i_BinaryDigit;
            int i_CurrentPower = 1;
            for (int i = i_BinaryNum.Length - 1; i > 0; i++)
            {
                i_BinaryDigit = i_BinaryNum[i] - '0';// Calculate the int value of the character.
                o_ActualBinaryNumber += (i_CurrentPower * i_BinaryDigit);// Caculate the cuurent diggit nultiply iy by 2^i and add it to o_ActualBinaryNumber.
                i_CurrentPower *= 2; //Prepare the current power for next iteration.
            }
            return o_ActualBinaryNumber;
        }


        private static bool IsPowerOfTwo(int i_num)// return about a number if it is a power of two.
        {
            if (i_num!=1 &&(i_num & (i_num - 1)) == 0)// if the number is a power of two , then number-1 will have lower-order bits set.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int checkHowManyAreAscendingSeries(string[] i_BinaryNumbers, int i_AmountOfBinaryNumbers)// Checks from an string array how many of them is an ascending series.
        {
            int o_HowManyAreAscendingSeries = 0;
            int i_BinaryNum;
            for (int i = 0; i < i_AmountOfBinaryNumbers; i++)
            {
                i_BinaryNum = convertBinaryStringtToInt(i_BinaryNumbers[i]);//convert the string(of zeros and ones) to decimal representaion.
                if (isAscendingSeries(i_BinaryNum)) //Checks if the number is an ascending series.
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

        private static bool isAscendingSeries(int i_BinaryNum)
        {
            int i_CurrentLessSignificantNumber = i_BinaryNum % 10;
            i_BinaryNum = i_BinaryNum / 10;
            while(i_BinaryNum!=0)
            {
                if(i_BinaryNum%10<=i_CurrentLessSignificantNumber)
                {
                    return false;
                }
                int i_CurrentLessSignificantNumber = i_BinaryNum % 10;
                i_BinaryNum = i_BinaryNum / 10;
            }
            return true;
        }
    }
   
}