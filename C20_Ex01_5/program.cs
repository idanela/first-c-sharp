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
            int largestDigit = FindMaxNumInString(numberToAnalyze);
            int smallestDigit = FindMinNumInString(numberToAnalyze);
            int amountOfNumbersDividedByFour = howManyDividedByNum(numberToAnalyze,4);
            int amountOfDigitsBiggerFromUnityDigit = howManyBiggerThanUnityDigit(numberToAnalyze);
            Program.CreateAndPrintMessages(4, "messagesEX01_5.txt", largestDigit, smallestDigit, amountOfNumbersDividedByFour, amountOfDigitsBiggerFromUnityDigit);
        }

        private static string getValidInputFromUser()
        {
            StringBuilder numberAsAString = new StringBuilder();
            bool v_IsValidInput = false;
            while(v_IsValidInput==false)
            {
                numberAsAString.Append(Console.ReadLine());
                if (Program.checkIfInputIsValidRanged(numberAsAString, '0', '9',8))
                {
                    v_IsValidInput = true;
                }
            }
            return numberAsAString.ToString();
        }
        private static bool checkIfValid8DigitNumber(string i_DigitsSrting)
        {
            if (i_DigitsSrting.Length != 8)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < i_DigitsSrting.Length; i++)
                {
                    if(i_DigitsSrting[i]>'9' && i_DigitsSrting[i]<'0')
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }

        private static int FindMaxNumInString(string i_numberToAnalyze)
        {
            int max = i_numberToAnalyze[0]-'0';
            int valueAsDecimalNumber;
            for(int i=1; i<i_numberToAnalyze.Length; i++)
            {
                valueAsDecimalNumber = i_numberToAnalyze[i] - '0';
                if (valueAsDecimalNumber > max)
                {
                    max = valueAsDecimalNumber;
                }
            }
            return max;
        }

        private static int FindMinNumInString(string i_numberToAnalyze)
        {
            
            int min = i_numberToAnalyze[0]-'0';
            int valueAsDecimalNumber;
            for (int i = 1; i < i_numberToAnalyze.Length; i++)
            {
                valueAsDecimalNumber = i_numberToAnalyze[i] - '0';
                if (valueAsDecimalNumber < min)
                {
                    min = valueAsDecimalNumber;
                }
            }
            return min;
        }
        private static int howManyDividedByNum(string i_numberToAnalyze, int i_numTobeDividedBy)
        {
            int numOfDigitsDividedByFour = 0;
            for(int i=0; i<i_numberToAnalyze.Length;i++)
            {
                if(isDigitDividedByNum(i_numberToAnalyze[i],i_numTobeDividedBy)==true)
                {
                    numOfDigitsDividedByFour++;
                }
            }
            return numOfDigitsDividedByFour;
        }
        private static bool isDigitDividedByNum(char i_Digit, int i_numTobeDividedBy)
        {
            int digit= i_Digit - '0';
            if ((digit % i_numTobeDividedBy) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int howManyBiggerThanUnityDigit(string i_numberToAnalyze)
        {
            int amountOfNumbersBiggerThanUnityDigit = 0;
            char unityDigit = i_numberToAnalyze[i_numberToAnalyze.Length - 1];
            for(int i=0;i<i_numberToAnalyze.Length-1; i++)
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

