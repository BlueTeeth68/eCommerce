// See https://aka.ms/new-console-template for more information

using Application.Utils;

Console.WriteLine("Hello, World!");

const string input1 = "nguYỄn   văN b   ";
const string input2 = "TRẦn   tHỊ HỒNG     Hạnh  ";

Console.WriteLine("Test case 1: ");
Console.WriteLine($"\"{StringUtils.FormatName(input1)}\"");
Console.WriteLine("Test case 2: ");
Console.WriteLine($"\"{StringUtils.FormatName(input2)}\"");