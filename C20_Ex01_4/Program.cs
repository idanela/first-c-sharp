using System;

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
            int decimalRepresentation;
            string letterString = getValidLetterStringFroUser();
            bool v_IsPalidrom = isTheStringAPalindrom(letterString, 0, letterString.Length - 1);
            bool v_IsNumberString = int.TryParse(letterString, out decimalRepresentation);

            if (v_IsNumberString == true)
            {
                bool v_isDividedBythree = CheckIfDividedByThree(decimalRepresentation);
            }
            else
            {
                int howManyLowerCase = CountLowerCase(letterString);
            }
        }
        public static string getValidLetterStringFroUser()
        {
            string letterString = "";
            bool v_IsValidInput = false;

            Console.WriteLine("please enter twelve letter string");
            while (v_IsValidInput)
            {
                letterString = Console.ReadLine();
                if (C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, 'a', 'z', 12) == true || C20_Ex01_1.Program.checkIfInputIsValidRanged(letterString, 'A', 'Z', 12) == true || C20_Ex01_1.Program.checkIfInputIsValidRanged( letterString, '0', '9', 12) == true)
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

            if (i_To - i_From == 1 || i_To - i_From == 0)
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

        public static bool CheckIfDividedByThree(int i_PotentialDividedByThreeNumber)
        {
            return (i_PotentialDividedByThreeNumber % 3 == 0);
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
            int numOfUppercase = 0;
            for (int i = 0; i < i_LetterString.Length; i++)
            {
                if (C20_Ex01_1.Program.checkIfInputIsValidRanged(i_LetterString[i].ToString(), 'a', 'z', 12) == true)
                {
                    numOfUppercase++;
                }
            }
            return numOfUppercase;
        }
    }
}