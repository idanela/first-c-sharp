using System;

namespace C20_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            preformAnalisysOnBinaryNumbers();
        }
        public static void preformAnalisysOnBinaryNumbers()
        {
           int i_NumOfBinaryNumbers = 4;
            string[] output = new string[i_NumOfBinaryNumbers];
                Console.WriteLine("please enter 4 numbers in a binary format 8 digit each: ");
            for (int i = 0; i < i_NumOfBinaryNumbers; i++)
            {
                output[i] = getInputFromUser();
                bool i_isValidBinaryNum = checkIfInputIsValid(output[i]);
                if (!i_isValidBinaryNum)
                {
                    Console.WriteLine("the input you have entered is invalid. please try again. ");
                    i = 0; //If one of the numbers is invalid, gets new input.
                }
            }
            int i_AverageNumbersOfOnes;
            int i_AverageNumbersOfzero= caluculateAverageNumbersOfZeros(output,  i_NumOfBinaryNumbers);
            int i_AverageNumbersOfOnes=
            checkHowManyArePowerOfTWO(output, int i_NumOfBinaryNumbers);
            HowManyAreAscendingSeries(output, int i_NumOfBinaryNumbers);
            averageOfNumbers(output, int i_NumOfBinaryNumbers);
        }

    
    private static String getInputFromUser()
    {
        string io_BinaryNumber = Console.ReadLine();
        return io_BinaryNumber;
    }
        private static bool checkIfInputIsValid(string i_binaryNum)
        {
            if(i_binaryNum.Length!=8)
            {
                return false;
            }
            for (int i = 0; i < i_binaryNum.Length; i++)
            {
               if( i_binaryNum[i]!='1' && i_binaryNum[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        private static float caluculateAverageNumbersOfZero(string[] BinaryNumbers, int i_NumOfBinaryNumbers)
        {
          float i_numOfZeros = 0;
         
            for (int i=0; i<  i_NumOfBinaryNumbers; i++)
            {
                for(int j=0; j<BinaryNumbers[i].Length; j++)
                {
                    if(BinaryNumbers[i][j]=='0')
                    {
                        i_numOfZeros++;
                    }
                    
                }
            }
            float o_AverageNumberOfZeros= i_numOfZeros / i_NumOfBinaryNumbers;// Calculate average number of zeros.
            return o_AverageNumberOfZeros; // Returns average number of zeros.
        }
    }
}

private static float caluculateAverageNumbersOfZero(string[] BinaryNumbers, int i_NumOfBinaryNumbers)
{
    float i_numOfOnes = 0;

    for (int i = 0; i < i_NumOfBinaryNumbers; i++)
    {
        for (int j = 0; j < BinaryNumbers[i].Length; j++)
        {
            if (BinaryNumbers[i][j] == '1')
            {
                i_numOfOnes++;
            }

        }
    }
    float O_AverageNumberOfOnes = i_numOfOnes / i_NumOfBinaryNumbers;// Calculate average number of zeros.
    return O_AverageNumberOfOnes; // Returns average number of zeros.
}
    }
}
