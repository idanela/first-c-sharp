using System;
using System.Text;
using C20_Ex01_1;


namespace C20_Ex01_5
{
    public class program
    {
        public static void Main()
        {
            preformStatisticAnalysis();    
        }
       
        public static void preformStatisticAnalysis()
        {
            string numberToAnalyze = getValidInputFromUser();
            int largestDigit = FindMaxNumInString(numberToAnalyze);// Finds maximal number in number's string.
            int smallestDigit = FindMinNumInString(numberToAnalyze);// Finds Minimal number in number's string.
            int amountOfNumbersDividedByFour = howManyDigitsAreDividedByNum(numberToAnalyze,4); //Counts how many of the numbers are divided by 4 with no reminder.
            int amountOfDigitsBiggerFromUnityDigit = howManyBiggerThanUnityDigit(numberToAnalyze);// Counts how many digits in the number are bigger thant it's unity digit.
            Program.CreateAndPrintMessages(4, "messagesEX01_5.txt", largestDigit, smallestDigit, amountOfNumbersDividedByFour, amountOfDigitsBiggerFromUnityDigit); //prints messages regarding the data above.
        }

        private static string getValidInputFromUser() // Gets input from user until we get valid input.
        {
            Console.WriteLine("please enter an eigth digit decimal number");
            string numberAsAString="";
            bool v_IsValidInput = false;
            while(v_IsValidInput==false)
            {
                numberAsAString = Console.ReadLine();
                if (Program.checkIfInputIsValidRanged(numberAsAString, '0', '9',8))// checks if the string is in range(0'-'9') and in proper length.
                {
                    v_IsValidInput = true;
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
            int current_Max = i_numberToAnalyze[0]-'0';//Caculates the integer value of character and set it as max.
            int valueAsDecimalNumber;
            for(int i=1; i<i_numberToAnalyze.Length; i++)
            {
                valueAsDecimalNumber = i_numberToAnalyze[i] - '0';//Caculates the integer value of character.
                if (valueAsDecimalNumber > current_Max)
                {
                    current_Max = valueAsDecimalNumber; //If it is biiger set it as the new current maximal number.
                }
            }
            return current_Max;
        }

        private static int FindMinNumInString(string i_numberToAnalyze)//Finds minimal number in string.(returns it as an int).
        {
            
            int min = i_numberToAnalyze[0]-'0';//Caculates the integer value of character and set it as min.
            int valueAsDecimalNumber;
            for (int i = 1; i < i_numberToAnalyze.Length; i++)
            {
                valueAsDecimalNumber = i_numberToAnalyze[i] - '0';// Caculates the integer value of character.
                if (valueAsDecimalNumber < min)
                {
                    min = valueAsDecimalNumber;//If it is smaller set it as the new current maxinal number.
                }
            }
            return min;
        }
        private static int howManyDigitsAreDividedByNum(string i_numberToAnalyze, int i_numTobeDividedBy)// Counts how many digits are divided by a certain number.
        {
            int numOfDigitsDividedByFour = 0;
            for(int i=0; i<i_numberToAnalyze.Length;i++)
            {
                if(isDigitDividedByNum(i_numberToAnalyze[i],i_numTobeDividedBy)==true)//Checks if current digits is divided by i_numTobeDividedBy.
                {
                    numOfDigitsDividedByFour++;
                }
            }
            return numOfDigitsDividedByFour;
        }
        private static bool isDigitDividedByNum(char i_Digit, int i_numTobeDividedBy)//Checks if a certain digit is divided by i_numToBeDivideBy with no remonder.
        {
            int digit= i_Digit - '0';// Caculates the integer value of character.
            if ((digit % i_numTobeDividedBy) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int howManyBiggerThanUnityDigit(string i_numberToAnalyze)//Counts how many digits are bigger than unity digit.
        {
            int amountOfNumbersBiggerThanUnityDigit = 0;
            char unityDigit = i_numberToAnalyze[i_numberToAnalyze.Length - 1];//Sets unity digit.
            for(int i=0;i<i_numberToAnalyze.Length-1; i++)//for each digit check if it is bigger than unity digit. 
            {
                if(i_numberToAnalyze[i]>unityDigit)
                {
                    amountOfNumbersBiggerThanUnityDigit++;
                }
            }
            return amountOfNumbersBiggerThanUnityDigit;
        }
    }
}

