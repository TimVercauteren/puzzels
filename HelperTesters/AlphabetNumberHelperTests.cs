using System;
using Helpers;
using Xunit;

namespace HelperTesters
{
    public class AlphabetNumberHelperTests
    {

        [Fact]
        public void CharacterToNumericTests()
        {
            var result1 = 1;
            var result1b = 0;
            var result2 = 26;
            var result2b = 25;

            var output1 = AlphabetNumberHelper.CharacterToNumeric("a", false);
            var output2 = AlphabetNumberHelper.CharacterToNumeric("a", true);

            var output3 = AlphabetNumberHelper.CharacterToNumeric("z", false);
            var output4 = AlphabetNumberHelper.CharacterToNumeric("z", true);


            Assert.Equal(result1, output1);
            Assert.Equal(result1b, output2);
            Assert.Throws<ArgumentNullException>(() => AlphabetNumberHelper.CharacterToNumeric("abc"));
            Assert.Equal(result2, output3);
            Assert.Equal(result2b, output4);

        }

        [Fact]
        public void CharacterToNumericTestsInvariantCase()
        {
            var result1 = 1;
            var result1b = 0;
            var result2 = 26;
            var result2b = 25;

            var output1 = AlphabetNumberHelper.CharacterToNumeric("A", false);
            var output2 = AlphabetNumberHelper.CharacterToNumeric("A", true);

            var output3 = AlphabetNumberHelper.CharacterToNumeric("Z", false);
            var output4 = AlphabetNumberHelper.CharacterToNumeric("Z", true);


            Assert.Equal(result1, output1);
            Assert.Equal(result1b, output2);
            Assert.Equal(result2, output3);
            Assert.Equal(result2b, output4);

        }

        [Fact]
        public void NumericToCharacterTest()
        {
            var result1 = "a";
            var result2 = "z";

            var output = AlphabetNumberHelper.NumericToCharacter(1);
            var output2 = AlphabetNumberHelper.NumericToCharacter(26);

            Assert.Equal(result1, output);
            Assert.Equal(result2, output2);
        }
    }
}
