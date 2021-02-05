using System;
using System.Linq;

namespace Labb3InlamningFinal
{
    internal class Program
    {
        public static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Start program = new Start();
                program.goHome();
            } while (true);
        }

        public static void gameOver()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[4], " ===============================");
            Program.WriteFormattedLine("{0}", Program.colors[4], "===========GAME OVER===========");
            Program.WriteFormattedLine("{0}", Program.colors[4], "===========You Loose=========");
            Console.WriteLine("Do you want to play again (y/n)");
            string usrInput = Console.ReadLine();
            if (usrInput == "y")
            {
                Console.Clear();
                Start f = new Start();
                f.goHome();
            }
            else if (usrInput == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                gameOver();
            }
        }

        //Using formated text to display colored text, bars and add nice visualls

        public static void WriteFormattedLine(string format, ConsoleColor color, params string[] answers)
        {
            int formatText = format.Length;
            int currIndex = 0;
            bool readingNumber = false;
            string numberRead = string.Empty;
            while (currIndex < formatText)
            {
                var colorText = format[currIndex];
                switch (colorText)
                {
                    case '{':
                        Console.ForegroundColor = color;
                        readingNumber = true;
                        numberRead = string.Empty;
                        break;

                    case '}':
                        var number = int.Parse(numberRead);
                        var answer = answers[number];
                        Console.Write(answer);
                        Console.ResetColor();
                        readingNumber = false;
                        break;

                    default:
                        if (readingNumber)
                            numberRead += colorText;
                        else
                            Console.Write(colorText);
                        break;
                }

                currIndex++;
            }

            Console.WriteLine("");
        }
    }
}