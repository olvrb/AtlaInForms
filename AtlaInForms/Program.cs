using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace TransAtla
{
    class Program
    {
        static Dictionary<char, string> translator;


        static void Main(string[] args)
        {
            hackerMan();
            InitialiseDictionary();
            UserIO();
        }


        public static void UserIO()
        {
            string name = "";
            string input = "";
            Console.WriteLine("What do you want to translate?");
            input = Console.ReadLine();
            name = input;
            /*
            Console.WriteLine("Output for " + '"' + name + '"' + " :");
            Console.WriteLine('"' + name + '"' + " Translates to: " + binTranslate(name) + " in binary,"); // bin translator for name
            Console.WriteLine("Or: " + base64Translate(name) + "in base64,"); // base64 translator for name
            Console.WriteLine(translateMorse(input) + "in Morse Code,"); // morse translator for name
            int inputInInt = 0;
            try
            {
                inputInInt = int.Parse(input);
                Console.WriteLine("Or: " + ToTrenary(inputInInt) + " in ternary,");
                string octalString = Convert.ToString(int.Parse(input), 8);
                Console.WriteLine("Or: " + octalString + " in octal");

            }
            catch
            {
                Console.WriteLine("You didn't input a number, so convert to ternary or octal is impossible");
            }
            Console.WriteLine("Or: " + hexTranslate(name) + " in hexadecimal."); // hex translator for name
            Console.WriteLine("And finally, in ASCII code: ");
            Console.WriteLine(Convert.ToString(ASCIICodeTranslate(name))); // ascii translator for name
            
            */
            string output = "Output for " + '"' + name + '"' + " :\n" +
                '"' + name + '"' + " Translates to: " + binTranslate(name) + " in binary,\n" +
                "Or: " + base64Translate(name) + "in base64,\n" +
                translateMorse(input) + "in Morse Code,\n" +
                "Or: " + hexTranslate(name) + " in hexadecimal.\n" +
                "And finally, in ASCII code: " +
                ASCIICodeTranslate(name);
            MessageBox.Show(output);
            Console.WriteLine("Want to continue? (yes/no)");
            Console.WriteLine("(this will clear everything on this window)");
            sudoSandwich();
            Console.ReadKey();
        }

        private static void sudoSandwich()
        {

            sudo:
            string continu = "";
            continu = Console.ReadLine();
            string sudo = continu;
            if (sudo == "sudo make me a sandwich")
            {
                Console.WriteLine("Okay.");
            }
            else if (sudo == "make me a sandwich")
            {
                Console.WriteLine("Insufficient permissons.");
                sudo = "";
                goto sudo;

            }
            else if (continu == "yes")
            {
                Console.Clear();
                UserIO();
            }
            else if (continu == "no")
            {
                Environment.Exit(0);
            }
        }


        private static void InitialiseDictionary() //morse dictionnary
        {

            translator = new Dictionary<char, string>()
            {
                {'a', string.Concat('.', '-')},
                {'b', string.Concat('-', '.', '.', '.')},
                {'c', string.Concat('-', '.', '-', '.')},
                {'d', string.Concat('-', '.', '.')},
                {'e', '.'.ToString()},
                {'f', string.Concat('.', '.', '-', '.')},
                {'g', string.Concat('-', '-', '.')},
                {'h', string.Concat('.', '.', '.', '.')},
                {'i', string.Concat('.', '.')},
                {'j', string.Concat('.', '-', '-', '-')},
                {'k', string.Concat('-', '.', '-')},
                {'l', string.Concat('.', '-', '.', '.')},
                {'m', string.Concat('-', '-')},
                {'n', string.Concat('-', '.')},
                {'o', string.Concat('-', '-', '-')},
                {'p', string.Concat('.', '-', '-', '.')},
                {'q', string.Concat('-', '-', '.', '-')},
                {'r', string.Concat('.', '-', '.')},
                {'s', string.Concat('.', '.', '.')},
                {'t', string.Concat('-')},
                {'u', string.Concat('.', '.', '-')},
                {'v', string.Concat('.', '.', '.', '-')},
                {'w', string.Concat('.', '-', '-')},
                {'x', string.Concat('-', '.', '.', '-')},
                {'y', string.Concat('-', '.', '-', '-')},
                {'z', string.Concat('-', '-', '.', '.')},
                {'0', string.Concat('-', '-', '-', '-', '-')},
                {'1', string.Concat('.', '-', '-', '-', '-')},
                {'2', string.Concat('.', '.', '-', '-', '-')},
                {'3', string.Concat('.', '.', '.', '-', '-')},
                {'4', string.Concat('.', '.', '.', '.', '-')},
                {'5', string.Concat('.', '.', '.', '.', '.')},
                {'6', string.Concat('-', '.', '.', '.', '.')}, //kms why am i even using '.' and '-' and not . / - //nvm fixed it
                {'7', string.Concat('-', '-', '.', '.', '.')},
                {'8', string.Concat('-', '-', '-', '.', '.')},
                {'9', string.Concat('-', '-', '-', '-', '.')},
                {'å', string.Concat('.', '-', '-', '.', '-') },
                {'ä', string.Concat('.', '-', '.', '-') },
                {'ö', string.Concat('-', '-', '-', '.') },
                {' ', string.Concat("/")}
            };
        }

        private static string translateMorse(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input)
            {

                if (translator.ContainsKey(character))
                {
                    sb.Append(translator[character] + " ");
                }
                else if (character == ' ')
                {
                    sb.Append("/ ");
                }
                else
                {
                    sb.Append(character + " ");
                }

            }
            sb = sb.Replace(" ", "  ");
            return sb.ToString();
        }
        private static string binTranslate(string name) //something anyone who doesn't write code would call an algorithm
        {
            string bin = "";
            foreach (char ch in name)
            {
                bin += Convert.ToString((int)ch, 2);
            }
            return bin;
        }
        private static string base64Translate(string name)
        {
            string input = name;
            string base64 = "";
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        private static string hexTranslate(string name)
        {
            byte[] ba = Encoding.Default.GetBytes(name);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;
        }
        private static int ASCIICodeTranslate(string name)
        {
            int sum = 0;
            int numCHarInName = 0;
            int numCHar = 0;
            numCHarInName = name.Length;
            foreach (int c in name)
            {
                numCHar++;
                sum += c;
            }
            return sum;
        }
        public static String ToTrenary(int value)
        {
            if (value == 0)
                return "";

            StringBuilder Sb = new StringBuilder();
            Boolean signed = false;

            if (value < 0)
            {
                signed = true;
                value = -value;
            }

            while (value > 0)
            {
                Sb.Insert(0, value % 3);
                value /= 3;
            }

            if (signed)
                Sb.Insert(0, '-');

            return Sb.ToString();
        }
        public static void hackerMan()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

    }
}
