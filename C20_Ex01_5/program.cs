using System;

namespace C20_Ex01_5
{
    using C20_Ex01_1;
    public class program
    {
        public static void Main()
        {
            string numberToAnalyze= Program.getInputFromUser();
            preformStatisticAnalysis(numberToAnalyze);    
        }
       
        public static void preformStatisticAnalysis(string i_numberToAnalyze)
        {
            int largestDigit = FindMaxNumInString(i_numberToAnalyze);
            int smallestDigit = FindMinNumInString(i_numberToAnalyze);
            int amountOfNumbersDividedByFour = howManyDividedByNum(i_numberToAnalyze,4);
            int amountOfDigitsBiggerFromUnityDigit = howManyBiggerThanUnityDigit(i_numberToAnalyze);
            string maxMessage = string.Format("the maximal digit is {0}", largestDigit);
            string MinimalDigit = string.Format("the minimal digit is {0}", smallestDigit);

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
            int max = i_numberToAnalyze[0];
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
            
            int min = i_numberToAnalyze[0];
            int valueAsDecimalNumber;
            for (int i = 1; i < i_numberToAnalyze.Length; i++)
            {
                valueAsDecimalNumber = i_numberToAnalyze[i] - '0';
                if (valueAsDecimalNumber > min)
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

