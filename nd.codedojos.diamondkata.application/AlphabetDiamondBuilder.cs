using System.Text;

namespace nd.codedojos.diamondkata.application
{
    public class AlphabetDiamondBuilder
    {
        private const string Spacer = " ";

        private const int FirstCharacterAscii = 65;
        private const int LastCharacterAscii = 90;

        public string BuildDiamond(string alphabetCharacter)
        {
            if (!ValidateInput(alphabetCharacter))
                return "Invalid character. Please provide a valid alphabet character.";

            var givenAlphabetCharacter = Convert.ToChar(alphabetCharacter.ToUpperInvariant());

            return BuildDiamond(givenAlphabetCharacter);
        }

        private bool ValidateInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var upperCasedInput = input.ToUpperInvariant();

            char inputChar;
            if (!char.TryParse(upperCasedInput, out inputChar))
                return false;

            var inputCharAscii = Convert.ToInt32(inputChar);
            if (inputCharAscii < FirstCharacterAscii || inputCharAscii > LastCharacterAscii)
                return false;

            return true;
        }

        private string BuildDiamond(char givenAlphabetCharacter)
        {
            var diamondLength = GetDiamondLength(givenAlphabetCharacter);
            var middleIndex = (diamondLength - 1) / 2;

            var diamondBuilder = new StringBuilder(diamondLength);
            var currentCharacterAscii = FirstCharacterAscii-1;

            for (int i = 0; i <= diamondLength-1; i++)
            {
                if (i <= middleIndex)
                    currentCharacterAscii += 1;
                else
                    currentCharacterAscii -= 1;

                var newLine = BuildLine(diamondLength, middleIndex, currentCharacterAscii);

                diamondBuilder.AppendLine(newLine);
            }

            var diamond = diamondBuilder.ToString();
            return diamond.Remove(diamond.Length - Environment.NewLine.Length);
        }

        private int GetDiamondLength(char givenAlphabetCharacter)
        {
            var givenCharacterAscii = Convert.ToInt32(givenAlphabetCharacter);

            return (givenCharacterAscii - FirstCharacterAscii) * 2 + 1;
        }
        
        private string BuildLine(int diamondLength,  int middleIndex, int currentCharacterASCII)
        {
            var newLine = new StringBuilder().Insert(0, Spacer, diamondLength);

            var currentCharacterIndex = currentCharacterASCII - FirstCharacterAscii;
            newLine[middleIndex - currentCharacterIndex] = Convert.ToChar(currentCharacterASCII);
            newLine[middleIndex + currentCharacterIndex] = Convert.ToChar(currentCharacterASCII);

            return newLine.ToString();
        }
    }
}