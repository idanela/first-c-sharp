using System;

namespace C20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            int numberOfBinaryStrings = 4;
            string[] i_BinaryStrings = GetBinaryStringsFromUser(numberOfBinaryStrings);
            Console.WriteLine("the decimal representations of the binary numbers above are: ");
            printDecimalRepresentationOfBinaryNumbers(i_BinaryStrings, numberOfBinaryStrings);
            preformAnalysisOnBinaryStrings(i_BinaryStrings, numberOfBinaryStrings);
        }

        public static string[] GetBinaryStringsFromUser(int i_SizeOfStringArray)
        {
            string[] binaryStrings = new string[i_SizeOfStringArray]; //allocates a string array which will hold the numbers from user's input.
            Console.WriteLine("please enter 4 numbers in a binary format, 8 digit each: ");
            for (int i = 0; i < i_SizeOfStringArray; i++)
            {
                binaryStrings[i] = getInputFromUser();
                bool v_IsValidBinaryNum = checkIfInputIsValid(binaryStrings[i]); // Checks if the user inserted a valid string(8 number string of 1's and 0's).
                if (v_IsValidBinaryNum == false) 
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }
            }
            return binaryStrings;
        }
        private static void printDecimalRepresentationOfBinaryNumbers(string[] i_BinaryStrings, int i_NumberOfBinaryStrings) // Takes a binary string array and print each binar string decimal representation. 
        {
            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                int decimalRepresentaition = convertBinaryStringtToDecimalNumber(i_BinaryStrings[i]);//Convert the string to Deimal Number.
                Console.Write(decimalRepresentaition + ' ');
            }
        }

        public static void preformAnalysisOnBinaryStrings(string[] i_BinaryStrings, int i_NumberOfBinaryStrings) //Preform analysis on a few binary numbers.
        {
            float averageNumbersOfZeros = caluculateAverageNumbersOfACertainCharecterInStrings(i_BinaryStrings, i_NumberOfBinaryStrings, '0');//Gets average number of 0's from all string that were inserted.
            float averageNumbersOfOnes = caluculateAverageNumbersOfACertainCharecterInStrings(i_BinaryStrings, i_NumberOfBinaryStrings, '1');//Gets average number of 1's from all string that were inserted.
            int howManyArePowerOfTwo = checkHowManyArePowerOfTwo(i_BinaryStrings, i_NumberOfBinaryStrings);
            int howManyAreAscendingSeries = checkHowManyAreAscendingSeries(i_BinaryStrings, i_NumberOfBinaryStrings);
            float averageOfNumbers = calculateAverageOfNumbers(i_BinaryStrings, i_NumberOfBinaryStrings);
            string averageNumberOfZeorsMsg = string.Format("There are {0} zeros in average.", averageNumbersOfZeros);
            string averageNumberOfOnesMsg = string.Format("There are {0} ones in average.", averageNumbersOfOnes);
            string amountOfNumberThatIsPowerOfTwoMsg = string.Format("There are {0} number which are power of two.", howManyArePowerOfTwo);
            string amountOfNumbersThatConstituteAscendingSeriesMsg = string.Format("There are {0} number that constitute an ascending series.", howManyAreAscendingSeries);
            string averageOfNumbersMsg = string.Format("The average of the numbers is {0}", averageOfNumbers);
            printMessages(5,averageNumberOfZeorsMsg, averageNumberOfOnesMsg, amountOfNumberThatIsPowerOfTwoMsg,amountOfNumbersThatConstituteAscendingSeriesMsg,averageOfNumbersMsg);
        }

        private static void printMessages(int i_NumberOfStrings, params string[] i_Messages)
        {
            for (int i=0; i<i_NumberOfStrings; i++)
            {
                Console.WriteLine(i_Messages[i]);
            }
        }
   
        private static String getInputFromUser() //Gets input fron user.
        {
            string binaryNumber = Console.ReadLine();
            return binaryNumber;
        }

        private static bool checkIfInputIsValid(string i_BinaryNums)// Checks if a string has 8 characters and only 1's and 0's.
        {
            if (i_BinaryNums.Length != 8) // If the number is not an 8-bit number its not valid.
            {
                return false;
            }
            for (int i = 0; i < i_BinaryNums.Length; i++)
            {
                if (i_BinaryNums[i] != '1' && i_BinaryNums[i] != '0')// If the number is not containing only 1's and 0's its not valid.
                {
                    return false;
                }
            }
            return true;
        }
        
        private static float caluculateAverageNumbersOfACertainCharecterInStrings(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings, char i_ChosenCharacter)//Calculates the average apperances of a cerain character in a string array.
        {
            float numOfChosenCharInString = 0;

            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                for (int j = 0; j < i_BinaryNumbers[i].Length; j++)
                {
                    if (i_BinaryNumbers[i][j] == i_ChosenCharacter)// For each character in the string check if the chosen character.
                    {
                        numOfChosenCharInString++;
                    }
                }
            }
            float averageNumberOfChar = numOfChosenCharInString / i_NumberOfBinaryStrings;// Calculate average number of a certain character.
            return averageNumberOfChar; // Returns average number of a certain character.
        }
        
        private static int checkHowManyArePowerOfTwo(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings)// Checks how many strings (which represent a binary number) are a power of two.
        {
            int amountOfNumbersWhichArePowerOfTwo = 0;
            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                int binaryNumber = convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]); //Converts a string to the binary number that its represent.
                if (IsPowerOfTwo(binaryNumber)==true)
                {
                    amountOfNumbersWhichArePowerOfTwo++;
                }
            }
            return amountOfNumbersWhichArePowerOfTwo;
        }
        
        private static int convertBinaryStringtToDecimalNumber(string i_BinaryNum) // convert a string that represent a binary number to it's decimal form.
        {
            int actualDecimalNumber = 0;
            int binaryDigit;
            int currentPower = 1;
            for (int i = i_BinaryNum.Length - 1; i > 0; i++)
            {
                binaryDigit = i_BinaryNum[i] - '0';// Calculate the int value of the character.
                actualDecimalNumber += (currentPower * binaryDigit);// Caculate the cuurent digit nultiply iy by 2^i and add it to o_ActualBinaryNumber.
                currentPower *= 2; //Prepare the current power for next iteration.
            }
            return actualDecimalNumber;
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
            int howManyAreAscendingSeries = 0;
            int decimalNumber;
            for (int i = 0; i < i_AmountOfBinaryNumbers; i++)
            {
                decimalNumber = convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]);//Converts the string(of zeros and ones) to decimal representaion.
                if (isAscendingSeries(decimalNumber)) //Checks if the number in decimal representatoin constitutes an ascending series.
                {
                    howManyAreAscendingSeries++;
                }
            }
            return howManyAreAscendingSeries;
        }

        private static float calculateAverageOfNumbers(string[] i_BinaryNumbers, int i_NumberOfBinaryStrings)// Calculate average of numbers represented as binary string.
        {
            float sumOfAllNumbers = 0;
            for(int i= 0; i< i_NumberOfBinaryStrings; i++)
            {
                sumOfAllNumbers += convertBinaryStringtToDecimalNumber(i_BinaryNumbers[i]); //Calculates the decimal value of binary string and add it to sum of all the numbers.
            }
            float averageOfNumbers = sumOfAllNumbers / i_NumberOfBinaryStrings; // Caculate average.
            return averageOfNumbers;
        }

        private static bool isAscendingSeries(int i_PotentialAscendingSeriesNumber)// Checks is a number's digits are ascending series.
        {
            int currentLeastSignificantDigit;
            while (i_PotentialAscendingSeriesNumber != 0)
            {
                currentLeastSignificantDigit = i_PotentialAscendingSeriesNumber % 10;
                i_PotentialAscendingSeriesNumber = i_PotentialAscendingSeriesNumber / 10;
                if (i_PotentialAscendingSeriesNumber % 10 <= currentLeastSignificantDigit)//Checks if the 2 Least significant digits are acsending series.
                {
                    return false;
                }
            }
            return true;
        }
    }
   
}