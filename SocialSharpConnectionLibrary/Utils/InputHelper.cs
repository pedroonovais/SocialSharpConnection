using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.utils
{
    public static class InputHelper
    {
        public static string GetInputString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input inválido, por favor, digite algo válido.");
                    continue;
                }
                return input;
            }
        }

        public static string GetInputEmail(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || !input.Contains("@"))
                {
                    Console.WriteLine("Input inválido, por favor, digite um email válido.");
                    continue;
                }
                return input;
            }
        }

        public static int GetInputInteger(string message, int min = -1, int max = -1)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int result))
                {
                    Console.WriteLine("Input inválido, por favor, digite um número válido.");
                    continue;
                }

                if (min != -1 && result < min)
                {
                    Console.WriteLine($"Input inválido, por favor, digite um número maior ou igual a {min}.");
                    continue;
                }

                if (max != -1 && result > max)
                {
                    Console.WriteLine($"Input inválido, por favor, digite um número menor ou igual a {max}.");
                    continue;
                }

                return result;
            }
        }
    }
}
