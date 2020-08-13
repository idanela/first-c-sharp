using System;
using System.Text;
namespace C20_EX01_4
{
    public class Program
    {
        public static void Main()
        {
            stringAnalysis();
        }
        public static void stringAnalysis()
        {
            long decimalRepresentation;
            string letterString = getValidLetterStringFroUser();
            StringBuilder msg = new StringBuilder(letterString);
            bool isPalidrom = isTheStringAPalindrom(letterString, 0, letterString.Length - 1);

            ChoseStringToAppend(ref msg, isPalidrom, " is a plaindrom", " is not a plaindrom");
         
            bool isNumberString = long.TryParse(letterString, out decimalRepresentation);

            if (isNumberString == true)
            {
                bool isDividedBythree = CheckIfDividedByCertainNum(decimalRepresentation,3);

                ChoseStringToAppend(ref msg, isDividedBythree, " and divided by three with no reminder", ", and doesn't divided by three with no reminder");
            }
            else
            {
                int howManyLowerCase = CountLowerCase(letterString);

                msg.AppendFormat(", and has {0} lowercase letters. ", howManyLowerCase);
            }

            Console.WriteLine(msg);
        }
        public static string getValidLetterStringFroUser()
        {
            string letterString = string.Empty;
            bool isValidInput = false;

            Console.WriteLine("please enter twelve letter string");
            while (isValidInput == false)
            {
                letterString = Console.ReadLine();
                isValidInput = (C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, '0', '9', 12) == true || (C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, 'A', 'z', 12) == true && C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, '[', '`', 12) == false));
               if(isValidInput == false)
                {
                    Console.WriteLine("the input you have entered is invalid. please try again.");
                }
            }
            return letterString;
        }
        public static bool isTheStringAPalindrom(string i_LetterString, int i_From, int i_To)
        {
            bool isPalindrom;
            isPalindrom = (i_To <= i_From);
            if(isPalindrom == false)
            {
                isPalindrom = i_LetterString[i_From] == i_LetterString[i_To];
                if(isPalindrom == false)
                {
                    isPalindrom = isTheStringAPalindrom(i_LetterString, i_From + 1, i_To - 1);
                }
            }
            //if (i_To <= i_From)
            //{
            //    isPalindrom = true;
            //}
            //else if (i_LetterString[i_From] != i_LetterString[i_To])
            //{
            //    isPalindrom = false;
            //}
            //else
            //{
            //    isPalindrom = isTheStringAPalindrom(i_LetterString, i_From + 1, i_To - 1);
            //}
            return isPalindrom;
        }

        public static bool CheckIfDividedByCertainNum(long i_PotentialDividedByThreeNumber,int i_Num)
        {
            return (i_PotentialDividedByThreeNumber % i_Num == 0);
        }


        public static int sumDigits(int i_DecimalNumber)
        {
            int sumOfDigits = 0;

            while (i_DecimalNumber != 0)
            {
                sumOfDigits += i_DecimalNumber % 10;
                i_DecimalNumber /= 10;
            }
            return sumOfDigits;
        }

        public static int CountLowerCase(string i_LetterString)
        {
            int numOfLowercase = 0;
            for (int i = 0; i < i_LetterString.Length; i++)
            {
                if (C20_Ex01_1.Program.checkIfInputIsValidRanged(i_LetterString[i].ToString(), 'a', 'z', 1) == true)
                {
                    numOfLowercase++;
                }
            }
            return numOfLowercase;
        }
        public static void ChoseStringToAppend(ref StringBuilder msg, bool i_IsCondition, string i_FirstMessage, string i_SecondMessage)
        {
            if (i_IsCondition == true)
            {
                msg.Append(i_FirstMessage);
            }
            else
            {
                msg.Append(i_SecondMessage);
            }

        }
    }
}