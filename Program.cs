using System;
using System.Text;
using System.IO;
namespace C20_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            BinarySeries(4);
        }
        public static void BinarySeries(int i_NumberOfBinarySeries)
        {
            string[] i_BinaryStrings = GetBinaryStringsFromUser(i_NumberOfBinarySeries);
            Console.WriteLine("the decimal representations of the binary numbers above are: ");
            printDecimalRepresentationOfBinaryNumbers(i_BinaryStrings, i_NumberOfBinarySeries);
            preformAnalysisOnBinaryStrings(i_BinaryStrings, i_NumberOfBinarySeries);
        }

        public static string[] GetBinaryStringsFromUser(int i_SizeOfStringArray)
        {
            StringBuilder[] binaryStringsBuilders = new StringBuilder[i_SizeOfStringArray]; //allocates a string array which will hold the numbers from user's input.
            Console.WriteLine("please enter 4 numbers in a binary format, 8 digit each: ");
            for (int i = 0; i < i_SizeOfStringArray; i++)
            {
                binaryStringsBuilders[i] = new StringBuilder();
                binaryStringsBuilders[i].Insert(0, Console.ReadLine()) ;
                bool v_IsValidBinaryNum = checkIfInputIsValidRanged(binaryStringsBuilders[i],'0','1',8); // Checks if the user inserted a valid string(8 number string of 1's and 0's).
                if (v_IsValidBinaryNum == false) 
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }

            }
            string []binaryStrings= new string[i_SizeOfStringArray];
            for(int i=0; i<i_SizeOfStringArray; i++)
            {
                binaryStrings[i] = binaryStringsBuilders[i].ToString();
            }
            return binaryStrings;
        }
        private static void printDecimalRepresentationOfBinaryNumbers(string[] i_BinaryStrings, int i_NumberOfBinaryStrings) // Takes a binary string array and print each binar string decimal representation. 
        {
            for (int i = 0; i < i_NumberOfBinaryStrings; i++)
            {
                int decimalRepresentaition = convertBinaryStringtToDecimalNumber(i_BinaryStrings[i]);//Convert the string to Deimal Number.
                Console.WriteLine(decimalRepresentaition );
            }
        }

        public static void preformAnalysisOnBinaryStrings(string[] i_BinaryStrings, int i_NumberOfBinaryStrings) //Preform analysis on a few binary numbers.
        {
           StringBuilder msg=new StringBuilder() ;
            float averageNumbersOfZeros = caluculateAverageNumbersOfACertainCharecterInStrings(i_BinaryStrings, i_NumberOfBinaryStrings, '0');//Gets average number of 0's from all string that were inserted.
            float averageNumbersOfOnes = caluculateAverageNumbersOfACertainCharecterInStrings(i_BinaryStrings, i_NumberOfBinaryStrings, '1');//Gets average number of 1's from all string that were inserted.
            int howManyArePowerOfTwo = checkHowManyArePowerOfTwo(i_BinaryStrings, i_NumberOfBinaryStrings);
            int howManyAreAscendingSeries = checkHowManyAreAscendingSeries(i_BinaryStrings, i_NumberOfBinaryStrings);
            float averageOfNumbers = calculateAverageOfNumbers(i_BinaryStrings, i_NumberOfBinaryStrings);
            CreateAndPrintMessages(5, "messages.txt", averageNumbersOfZeros, averageNumbersOfOnes, howManyArePowerOfTwo, howManyAreAscendingSeries, averageOfNumbers);
        }

        public static void CreateAndPrintMessages(int i_NumberOfResults,string i_FileName,params object[] resultNumber)
        {
            StringBuilder msg = new StringBuilder();
            StreamReader a=new StreamReader(i_FileName);
            for (int i=0; i< i_NumberOfResults; i++)
            {
               msg.AppendFormat(a.ReadLine(),resultNumber[i]);
                Console.WriteLine(msg);
                msg.Clear();
            }
        }

      public static bool checkIfInputIsValidRanged(StringBuilder i_BinaryNums,char i_From,char i_To ,int i_LengthOfValidInput)// Checks if a string has 8 characters and only 1's and 0's.
        {
            if (i_BinaryNums.Length != i_LengthOfValidInput) // If the number is not an 8-bit number its not valid.
            {
                return false;
            }
            for (int i = 0; i < i_BinaryNums.Length; i++)
            {
                if (i_BinaryNums[i] < i_From || i_BinaryNums[i] > i_To)// If the number is not containing only 1's and 0's its not valid.
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
            for (int i = i_BinaryNum.Length - 1; i >= 0; i--)
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