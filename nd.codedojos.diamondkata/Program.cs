using nd.codedojos.diamondkata.application;

var input = Environment.GetCommandLineArgs().Length > 1 ? Environment.GetCommandLineArgs()[1] : null;

var diamondBuilder = new AlphabetDiamondBuilder();
Console.WriteLine(diamondBuilder.BuildDiamond(input).ReplaceLineEndings(string.Empty));

Console.ReadKey();



