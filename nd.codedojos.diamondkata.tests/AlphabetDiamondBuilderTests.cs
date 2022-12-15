using nd.codedojos.diamondkata.application;
using NUnit.Framework;

namespace nd.codedojos.diamondkata.tests
{
    public class AlphabetDiamondBuilderTests
    {
        #region Invalid test cases

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("hello")]
        [TestCase("1")]
        [TestCase("123")]
        public void BuildDiamond_GivenInvalidInput_ThenAnErrorMessageIsReturned(string input)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(input);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual("Invalid character. Please provide a valid alphabet character.", result);
        }

        #endregion

        #region Valid test cases

        private const string Spacer = " ";
        private const int FirstCharacterAscii = 65;

        public record DiamondTestCaseProperties(string AlphabetCharacter, int ExpectedLength, int MiddleIndex);
    
        /// <summary>
        /// Alphabet Character, Expected Diamond Length
        /// </summary>
        private static object[] _diamondBuilderValidTestCases =
        {
            new object[] {new  DiamondTestCaseProperties("A", 1, 0)},
            new object[] {new  DiamondTestCaseProperties("B", 3, 1)},
            new object[] {new  DiamondTestCaseProperties("C", 5, 2)},
            new object[] {new  DiamondTestCaseProperties("D", 7, 3)},
            new object[] {new  DiamondTestCaseProperties("E", 9, 4)},
            new object[] {new  DiamondTestCaseProperties("F", 11, 5)},
            new object[] {new  DiamondTestCaseProperties("G", 13, 6)},
            new object[] {new  DiamondTestCaseProperties("H", 15, 7)},
            new object[] {new  DiamondTestCaseProperties("I", 17, 8)},
            new object[] {new  DiamondTestCaseProperties("J", 19, 9)},
            new object[] {new  DiamondTestCaseProperties("K", 21, 10)},
            new object[] {new  DiamondTestCaseProperties("L", 23, 11)},
            new object[] {new  DiamondTestCaseProperties("M", 25, 12)},
            new object[] {new  DiamondTestCaseProperties("N", 27, 13)},
            new object[] {new  DiamondTestCaseProperties("O", 29, 14)},
            new object[] {new  DiamondTestCaseProperties("P", 31, 15)},
            new object[] {new  DiamondTestCaseProperties("Q", 33, 16)},
            new object[] {new  DiamondTestCaseProperties("R", 35, 17)},
            new object[] {new  DiamondTestCaseProperties("S", 37, 18)},
            new object[] {new  DiamondTestCaseProperties("T", 39, 19)},
            new object[] {new  DiamondTestCaseProperties("U", 41, 20)},
            new object[] {new  DiamondTestCaseProperties("V", 43, 21)},
            new object[] {new  DiamondTestCaseProperties("W", 45, 22)},
            new object[] {new  DiamondTestCaseProperties("X", 47, 23)},
            new object[] {new  DiamondTestCaseProperties("Y", 49, 24)},
            new object[] { new DiamondTestCaseProperties("Z", 51, 25) }
        };

        #region Length tests

        /// <summary>
        /// Tests that there are n number of lines
        /// and tests that each line has a length of n (untrimmed)
        /// where n = expected length
        /// given a valid upper cased alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidCharacter_ThenDiamondLengthsAreCorrect(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter);

            AssertDiamondLengthsAreCorrect(diamondTestCases, result);
        }

        /// <summary>
        /// Tests that there are n number of lines
        /// and tests that each line has a length of n (untrimmed)
        /// where n = expected length
        /// given a valid lower cased alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidLowerCasedCharacter_ThenDiamondLengthsAreCorrect(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter.ToLowerInvariant());

            AssertDiamondLengthsAreCorrect(diamondTestCases, result);
        }

        private void AssertDiamondLengthsAreCorrect(DiamondTestCaseProperties diamondTestCases, string result)
        {
            var newLineSplit = result.Split(Environment.NewLine);

            Assert.AreEqual(diamondTestCases.ExpectedLength, newLineSplit.Length);
            foreach (var line in newLineSplit)
                Assert.AreEqual(diamondTestCases.ExpectedLength, line.Length);
        }

        #endregion

        #region Character count tests

        /// <summary>
        /// Tests that the diamond ends (top and bottom) contain only 1 character after removing newline and spacer
        /// and tests that the other lines contain exactly 2 characters after removing newline and spacer
        /// given a valid upper cased alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidCharacter_ThenCharacterCountsPerLineAreCorrect(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter);

            AssertCharacterCountsPerLineAreCorrect(diamondTestCases, result);
        }

        /// <summary>
        /// Tests that the diamond ends (top and bottom) contain only 1 character after removing newline and spacer
        /// and tests that the other lines contain exactly 2 characters after removing newline and spacer
        /// given a valid lower cased alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidLowerCasedCharacter_ThenCharacterCountsPerLineAreCorrect(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter.ToLowerInvariant());

            AssertCharacterCountsPerLineAreCorrect(diamondTestCases, result);
        }

        private void AssertCharacterCountsPerLineAreCorrect(DiamondTestCaseProperties diamondTestCases, string result)
        {
            var newLineSplit = result.Split(Environment.NewLine);

            //Assert diamond ends (top and bottom)
            Assert.AreEqual(1, newLineSplit[0].ReplaceLineEndings(string.Empty).Replace(Spacer, string.Empty).Length);
            Assert.AreEqual(1,
                newLineSplit[diamondTestCases.ExpectedLength - 1].ReplaceLineEndings(string.Empty).Replace(Spacer, string.Empty)
                    .Length);

            //Assert middle lines
            for (int i = 1; i <= diamondTestCases.ExpectedLength - 2; i++)
                Assert.AreEqual(2, newLineSplit[i].ReplaceLineEndings(string.Empty).Replace(Spacer, string.Empty).Length);
        }

        #endregion

        #region Character position tests

        /// <summary>
        /// Tests that the expected characters per line in the diamond are in their correct position
        /// given a valid alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidCharacter_ThenExpectedCharactersAreInTheCorrectPositionPerLine(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter);

            AssertCharactersAreInTheCorrectPositionPerLine(diamondTestCases, result);
        }

        /// <summary>
        /// Tests that the expected characters per line in the diamond are in their correct position
        /// given a valid lower cased alphabet character.
        /// </summary>
        /// <param name="diamondTestCases"></param>
        [TestCaseSource(nameof(_diamondBuilderValidTestCases))]
        public void BuildDiamond_GivenAValidLowerCasedCharacter_ThenExpectedCharactersAreInTheCorrectPositionPerLine(DiamondTestCaseProperties diamondTestCases)
        {
            var diamondBuilder = new AlphabetDiamondBuilder();

            var result = diamondBuilder.BuildDiamond(diamondTestCases.AlphabetCharacter.ToLowerInvariant());

            AssertCharactersAreInTheCorrectPositionPerLine(diamondTestCases, result);
        }

        private static void AssertCharactersAreInTheCorrectPositionPerLine(DiamondTestCaseProperties diamondTestCases,
            string result)
        {
            var newLineSplit = result.Split(Environment.NewLine);

            //Assert middle line
            var givenAlphabetCharacter = Convert.ToChar(diamondTestCases.AlphabetCharacter);
            Assert.AreEqual(givenAlphabetCharacter, newLineSplit[diamondTestCases.MiddleIndex][0]);
            Assert.AreEqual(givenAlphabetCharacter,
                newLineSplit[diamondTestCases.MiddleIndex][diamondTestCases.ExpectedLength - 1]);

            //Assert diamond ends (top and bottom)
            var firstCharacter = Convert.ToChar(FirstCharacterAscii);
            Assert.AreEqual(firstCharacter, newLineSplit[0][diamondTestCases.MiddleIndex]);
            Assert.AreEqual(firstCharacter, newLineSplit[diamondTestCases.ExpectedLength - 1][diamondTestCases.MiddleIndex]);

            //Assert middle lines
            var middleLinesCount = diamondTestCases.MiddleIndex - 1;
            var currentCharacterAscii = FirstCharacterAscii + 1;
            for (int i = 1; i <= middleLinesCount; i++)
            {
                var currentCharacter = Convert.ToChar(currentCharacterAscii);
                //Top part
                Assert.AreEqual(currentCharacter, newLineSplit[i][diamondTestCases.MiddleIndex - i]);
                Assert.AreEqual(currentCharacter, newLineSplit[i][diamondTestCases.MiddleIndex + i]);
                //Bottom part
                Assert.AreEqual(currentCharacter,
                    newLineSplit[diamondTestCases.ExpectedLength - (i + 1)][diamondTestCases.MiddleIndex - i]);
                Assert.AreEqual(currentCharacter,
                    newLineSplit[diamondTestCases.ExpectedLength - (i + 1)][diamondTestCases.MiddleIndex + i]);

                currentCharacterAscii += 1;
            }
        }

        #endregion

        #endregion
    }
}