using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Helpers;

namespace V2
{
    class Program
    {
        static void Main(string[] args)
        {
            VoerUitXMaal("abcdefghijklmnopqrstuvwxyz", 1);
        }

        private static void VoerUitXMaal(string startstring, int aantalKeer)
        {
            for (int i = 0; i < aantalKeer; i++)
            {
                var result = CalculateOpgave(startstring);
                Console.WriteLine(result);
                startstring = result;
            }
        }

        private static string CalculateOpgave(string opgave)
        {
            var result = "";

            foreach (var letter in opgave)
            {
                result += ProcessLetter(letter);
            }

            return result;
        }

        private static string ProcessLetter(in char letter)
        {
            // convert to nummer
            var start = AlphabetNumberHelper.CharacterToNumeric(letter.ToString());

            var first = start - 7;
            var second = first - 1;
            var third = second - 3;

            var product = first * second;

            var topRes = product * -1;
            var midRes = (int)(Math.Pow(first, 4) * -2);
            var botRes = (int) (Math.Pow(third, 6) * 8);

            var sum = topRes + midRes + botRes;
            var resultInt = sum % 23;
            if (resultInt < 0)
            {
                resultInt = 23 + resultInt;
            }

            return AlphabetNumberHelper.NumericToCharacter(resultInt);
        }

        private static string ReverseProcessLetter(in char letter)
        {



            throw new NotImplementedException();
        }
    }
}
