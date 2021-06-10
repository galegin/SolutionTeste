using System;

namespace ConsoleApp2
{
    class ReadWriteExecute
    {
        public static int SymbolicToInt(char letra)
        {
            switch (letra)
            {
                case 'r':
                    return 4;
                case 'w':
                    return 2;
                case 'x':
                    return 1;
                case '-':
                    return 0;
            }

            return 0;
        }

        public static int SymbolicToOctal(string permString)
        {
            if ((permString.Length % 3) != 0)
                return 0;

            var result = string.Empty;
            var soma = 0;

            for (int i = 0; i < permString.Length; i++)
            {
                soma += SymbolicToInt(permString[i]);
                if (((i + 1) % 3) == 0)
                {
                    result += soma;
                    soma = 0;
                }
            }

            return int.Parse(result);
        }

        public static void Main(string[] args)
        {
            // Should write 752
            Console.WriteLine(ReadWriteExecute.SymbolicToOctal("rwxr-x-w-"));
        }
    }
}