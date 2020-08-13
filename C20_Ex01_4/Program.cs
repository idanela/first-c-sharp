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
            bool v_IsPalidrom = isTheStringAPalindrom(letterString, 0, letterString.Length - 1);
            bool v_IsNumberString = long.TryParse(letterString, out decimalRepresentation);
            if (v_IsPalidrom==true)
            {
                msg.Append(", is a Palindrom");
            }
            else
            {
                msg.Append(", is not a Palindrom");
            }
            if (v_IsNumberString == true)
            {
                bool v_IsDividedBythree = CheckIfDividedByCertainNum(decimalRepresentation,3);
               if(v_IsDividedBythree==true)
                {
                    msg.Append(", and divided by three with no reminder");
                }
               else
                {
                    msg.Append(", and doesn't divided by three with no reminder");

                }
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
            string letterString = "";
            bool v_IsValidInput = false;

            Console.WriteLine("please enter twelve letter string");
            while (v_IsValidInput == false)
            {
                letterString = Console.ReadLine();
                if ( C20_Ex01_1.Program.checkIfInputIsValidRanged( letterString, '0', '9', 12) == true|| (C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, 'A', 'z', 12) == true && C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, '[', '`', 12) == false))
                {
                    v_IsValidInput = true;
                }
                else
                {
                    Console.WriteLine("the input you have entered is invalid. please try again.");
                }
            }
            return letterString;
        }
        public static bool isTheStringAPalindrom(string i_LetterString, int i_From, int i_To)
        {
            bool v_IsPalindrom;

            if (i_To <= i_From)
            {
                v_IsPalindrom = true;
            }
            else if (i_LetterString[i_From] != i_LetterString[i_To])
            {
                v_IsPalindrom = false;
            }
            else
            {
                v_IsPalindrom = isTheStringAPalindrom(i_LetterString, i_From + 1, i_To - 1);
            }
            return v_IsPalindrom;
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
    }
}