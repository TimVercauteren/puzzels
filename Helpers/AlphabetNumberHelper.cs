using System;

namespace Helpers
{
    public static class AlphabetNumberHelper
    {
        private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string NumersNulTotNegen = "0123456789";

        /// <summary>
        /// Returns the corresponding number in the alphabet for the characer eg (h = 8 or h = 7 if zero based)
        /// </summary>
        /// <param name="c">One character c in string notation</param>
        /// <param name="isBaseZero">If a = 0 set to true, else a = 1 (default so no need to change)</param>
        /// <returns></returns>
        public static int CharacterToNumeric(string c, bool isBaseZero = false)
        {
            if (c.Length != 1)
            {
                throw new ArgumentException("Mag niet uit meer dan 1 karakter bestaan");
            }
            var index = Alphabet.IndexOf(c.ToLowerInvariant(), StringComparison.Ordinal);

            return isBaseZero ? index : ++index;
        }

        /// <summary>
        /// Returns the corresponding character in the alphabet for the index ( 1 = a, 2 = b, .. 26 = z) in string format (will aways be just 1 character)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string NumericToCharacter(int n)
        {
            if (n < 1 || n > 26)
            {
                throw new ArgumentException("Geef een getal in tussen 1 en 26, voor modulo toe te passen gebruik andere functie");
            }
            var index = n - 1;

            return Alphabet[index].ToString();
        }
    }
}
