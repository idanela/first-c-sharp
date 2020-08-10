using System;

namespace C20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            int i_NumberOfBinaryStrings = 4;
            string[] i_BinaryStrings = GetBinaryStringsFromUser(i_NumberOfBinaryStrings);
            Console.WriteLine("the decimal representations of the binary numbers above are: ");
            printDecimalRepresentationOfBinaryNumbers(i_BinaryStrings, i_NumberOfBinaryStrings);
            preformAnalysisOnBinaryStrings(i_BinaryStrings, i_NumberOfBinaryStrings);
        }
        public static string[] GetBinaryStringsFromUser(int i_SizeOfStringArray)
        {
            string[] i_BinaryStrings = new string[i_SizeOfStringArray]; //allocates a string array which will hold the numbers from user's input.
            Console.WriteLine("please enter 4 numbers in a binary format, 8 digit each: ");
            for (int i = 0; i < i_SizeOfStringArray; i++)
            {
                i_BinaryStrings[i] = getInputFromUser();
                bool i_isValidBinaryNum = checkIfInputIsValid(i_BinaryStrings[i]); // Checks if the user inserted a valid string(8 number string of 1's and 0's).
                if (!i_isValidBinaryNum)
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }
            }
            return i_BinaryStrings;
        }
        private static void printDecimalRepresentationOfBinaryNumbers(string[] i_BinaryStrings, int i_NumberOfBinaryStrings) // Takes a binary string array and print each binar string decimal representation. 
        {
            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                int i_DecimalRepresentaition = convertBinaryStringtToDecimalNumber(i_BinaryStrings[i]);//Convert the string to Deimal Number.
                Console.Write(i_DecimalRepresentaition + ' ');
            }
        }
        public static void preformAnalysisOnBinaryStrings(string[]i_BinaryStrings,int i_NumberOfBinaryStrings) //Preform analysis on a few binary numbers.
        {
            float i_AverageNumbersOfZero = caluculateAverageNumbersOfACertainCharecter(i_BinaryStrings, i_NumberOfBinaryStrings, '0');//Gets average number of 0's from all string that were inserted.
            float i_AverageNumbersOfOnes = caluculateAverageNumbersOfACertainCharecter(i_BinaryStrings, i_NumberOfBinaryStrings, '1');//Gets average number of 1's from all string that were inserted.
            int i_HowManyArePowerOfTwo = checkHowManyArePowerOfTwo(i_BinaryStrings, i_NumberOfBinaryStrings);
            int HowManyAreAscendingSeries = checkHowManyAreAscendingSeries(i_BinaryStrings, i_NumberOfBinaryStrings);
            float i_averageOfNumbers = calculateAverageOfNumbers(i_BinaryStrings, i_NumberOfBinaryStrings);
        }
     
        private static String getInputFromUser() //Gets input fron user.
        {
            string i_BinaryNumber = Console.ReadLine();
            return i_BinaryNumber;
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
        
        private static float caluculateAverageNumbersOfACertainCharecter(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings, char i_ChosenCharacter)//Calculates the average apperances of a cerain character in a string array.
        {
            float i_NumOfChosenCharInString = 0;

            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                for (int j = 0; j < i_BinaryNumbers[i].Length; j++)
                {
                    if (i_BinaryNumbers[i][j] == i_ChosenCharacter)// For each character in the string check if the chosen character.
                    {
                        i_NumOfChosenCharInString++;
                    }

                }
            }
            float i_AverageNumberOfChar = i_NumOfChosenCharInString / i_NumberOfBinaryStrings;// Calculate average number of a certain character.
            return i_AverageNumberOfChar; // Returns average number of a certain character.
        }
        
        private static int checkHowManyArePowerOfTwo(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings)// Checks how many strings (which represent a binary number) are a power of two.
        {
            int i_AmountOfNumbersWhichArePowerOfTwo = 0;
            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                int i_BinaryNum = convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]); //Converts a string to the binary number that its represent.
                if (IsPowerOfTwo(i_BinaryNum)==true)
                {
                    i_AmountOfNumbersWhichArePowerOfTwo++;
                }
            }
            return i_AmountOfNumbersWhichArePowerOfTwo;
        }


        private static int convertBinaryStringtToDecimalNumber(string i_BinaryNum) // convert a string that represent a binary number to it's decimal form.
        {
            int i_ActualDecimalNumber = 0;
            int i_BinaryDigit;
            int i_CurrentPower = 1;
            for (int i = i_BinaryNum.Length - 1; i > 0; i++)
            {
                i_BinaryDigit = i_BinaryNum[i] - '0';// Calculate the int value of the character.
                i_ActualDecimalNumber += (i_CurrentPower * i_BinaryDigit);// Caculate the cuurent digit nultiply iy by 2^i and add it to o_ActualBinaryNumber.
                i_CurrentPower *= 2; //Prepare the current power for next iteration.
            }
            return i_ActualDecimalNumber;
        }


        private static bool IsPowerOfTwo(int i_NumWhichIsPossiblePowerOfTwo)// return about a number if it is a power of two.
        { 
            if (i_NumWhichIsPossiblePowerOfTwo!=1 &&(i_NumWhichIsPossiblePowerOfTwo & (i_NumWhichIsPossiblePowerOfTwo - 1)) == 0)// if the number is a power of two , then (number-1 will have lower-order bits set.
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
            int i_HowManyAreAscendingSeries = 0;
            int i_BinaryNum;
            for (int i = 0; i < i_AmountOfBinaryNumbers; i++)
            {
                i_BinaryNum = convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]);//Converts the string(of zeros and ones) to decimal representaion.
                if (isAscendingSeries(i_BinaryNum)) //Checks if the number is an ascending series.
                {
                    i_HowManyAreAscendingSeries++;
                }
            }
            return i_HowManyAreAscendingSeries;
        }

        private static float calculateAverageOfNumbers(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings)// Calculate average of numbers represented as binary string.
        {
            float i_SumOfAllNumbers = 0;
            for(int i= 0; i< i_NumberOfBinaryStrings; i++)
            {
                i_SumOfAllNumbers += convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]); //Calculates the decimal value of binary string and add it to sum of all the numbers.
            }
            float i_Average = i_SumOfAllNumbers / i_NumberOfBinaryStrings; // Caculate average.
            return i_Average;
        }

        private static bool isAscendingSeries(int i_potentialAscendingSeriesNumber)// Checks is a number's digits are ascending series.
        {
            int i_CurrentLessSignificantNumber;
            while (i_potentialAscendingSeriesNumber != 0)
            {
                i_CurrentLessSignificantNumber = i_potentialAscendingSeriesNumber % 10;
                i_potentialAscendingSeriesNumber = i_potentialAscendingSeriesNumber / 10;
                if (i_potentialAscendingSeriesNumber % 10 <= i_CurrentLessSignificantNumber)//Checks if the 2 Least significant digits are acsending series.
                {
                    return false;
                }
            }
            return true;
        }
    }
   
}