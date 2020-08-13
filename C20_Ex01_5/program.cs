using System;
namespace C20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            preformStatisticAnalysis();
        }

        private static void preformStatisticAnalysis()
        {
            string numberToAnalyze = getValidInputFromUser();
            int largestDigit = FindMaxNumInString(numberToAnalyze);// Finds maximal number in number's string.
            int smallestDigit = FindMinNumInString(numberToAnalyze);// Finds Minimal number in number's string.
            int amountOfNumbersDividedByFour = howManyDigitsAreDividedByNum(numberToAnalyze, 4); //Counts how many of the numbers are divided by 4 with no reminder.
            int amountOfDigitsBiggerFromUnityDigit = howManyBiggerThanUnityDigit(numberToAnalyze);// Counts how many digits in the number are bigger thant it's unity digit.
            string msg = string.Format(@" {0} is the largest digit from the digits above.
{1} is the smallest digit from the digits above.
There are {2} digits that are divided by four with no reminder. 
There are {3} digits that are bigger than unity digit", largestDigit, smallestDigit, amountOfNumbersDividedByFour, amountOfDigitsBiggerFromUnityDigit);
            Console.WriteLine(msg);
        }

        private static string getValidInputFromUser() // Gets input from user until we get valid input.
        {
            string numberAsAString = "";
            bool isValidInput = false;

            Console.WriteLine("please enter an eigth digit decimal number");
            while (isValidInput == false)
            {
                numberAsAString = Console.ReadLine();
                if (C20_Ex01_1.Program.checkIfInputIsValidRanged(numberAsAString, '0', '9', 8))// checks if the string is in range(0'-'9') and in proper length.
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("the input you have entered is invalid. please try again.");
                }
            }
            return numberAsAString;
        }

        private static int FindMaxNumInString(string i_numberToAnalyze) //Finds maximal number in string.(returns it as an int). 
        {
            int currentMax;
            int.TryParse(i_numberToAnalyze[0].ToString(), out currentMax);//Caculates the integer value of character and set it as max.
            int valueAsDecimalNumber;

            for (int i = 1; i < i_numberToAnalyze.Length; i++)
            {
                int.TryParse(i_numberToAnalyze[i].ToString(), out valueAsDecimalNumber);//Caculates the integer value of character.
                currentMax = Math.Max(valueAsDecimalNumber, currentMax);
            }
            return currentMax;
        }

        private static int FindMinNumInString(string i_numberToAnalyze)//Finds minimal number in string.(returns it as an int).
        {
            int currentMin;
            int.TryParse(i_numberToAnalyze[0].ToString(), out currentMin);//Caculates the integer value of character and set it as min.
            int valueAsDecimalNumber;

            for (int i = 1; i < i_numberToAnalyze.Length; i++)
            {
                int.TryParse(i_numberToAnalyze[i].ToString(), out valueAsDecimalNumber);// Caculates the integer value of character.
                currentMin = Math.Min(valueAsDecimalNumber, currentMin);
            }
            return currentMin;
        }

        private static int howManyDigitsAreDividedByNum(string i_numberToAnalyze, int i_numTobeDividedBy)// Counts how many digits are divided by a certain number.
        {
            int numOfDigitsDividedByFour = 0;
            for (int i = 0; i < i_numberToAnalyze.Length; i++)
            {
                if (isDigitDividedByNum(i_numberToAnalyze[i], i_numTobeDividedBy) == true)//Checks if current digits is divided by i_numTobeDividedBy.
                {
                    numOfDigitsDividedByFour++;
                }
            }
            return numOfDigitsDividedByFour;
        }

        private static bool isDigitDividedByNum(char i_Digit, int i_numTobeDividedBy)//Checks if a certain digit is divided by i_numToBeDivideBy with no remonder.
        {
            int digit;
            int.TryParse(i_Digit.ToString(), out digit);// Caculates the integer value of character.

            return (digit % i_numTobeDividedBy) == 0;
        }

        private static int howManyBiggerThanUnityDigit(string i_numberToAnalyze)//Counts how many digits are bigger than unity digit.
        {
            int amountOfNumbersBiggerThanUnityDigit = 0;
            char unityDigit = i_numberToAnalyze[i_numberToAnalyze.Length - 1];//Sets unity digit.

            for (int i = 0; i < i_numberToAnalyze.Length - 1; i++)//for each digit check if it is bigger than unity digit. 
            {
                if (i_numberToAnalyze[i] > unityDigit)
                {
                    amountOfNumbersBiggerThanUnityDigit++;
                }
            }
            return amountOfNumbersBiggerThanUnityDigit;
        }
    }
}

