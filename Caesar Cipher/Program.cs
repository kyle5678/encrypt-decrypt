using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt
{
    class Program
    {
        public static string[] Alphabet = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
        "s", "t", "u", "v", "w", "x", "y", "z"};

        static void Main(string[] args)
        {
            try
            {
                Code();
            }
            catch (Exception e)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("You broke it!");
                Console.WriteLine("How dare you!");
                Console.WriteLine("\n{0}\n", e);
                Console.WriteLine("Because of your behavior (bad), you will be forced to exit the program now.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        }

        public static void Code()
        {
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            Random rnd = new Random();

            // Startup Message
            Console.WriteLine("Welcome to Encrypt Decrypt! (Caesar Cipher)");
            Console.WriteLine("Please note that when encrypting or decrypting, only lowercase numbers will be changed.");
            Console.WriteLine("Please enter a command. Type \"help\" for help.");

            // Command
            for (; ; )
            {
                string command = Input();

                if (command == "exit")
                    break;

                else if (command == "help")
                {
                    Console.WriteLine("Help is coming");
                    Console.WriteLine(" encrypt:  Encrypt a message by moving each letter in one direction.");
                    Console.WriteLine(" decrypt:  Try to decrypt a message by moving each letter in one direction.");
                    Console.WriteLine("    help:  Get help the different commands available.");
                    Console.WriteLine("    exit:  Exit the program.");
                }

                else if (command == "encrypt")
                {
                    // Encryption

                    Console.WriteLine("Input message to encrypt");
                    string message = Input();

                    Console.WriteLine("Input cipher. Only accepts +,-. Example: +1");
                    string cipher = Input();

                    List<int> numMessage = new List<int>();

                    int cipherNum = Convert.ToInt32(cipher.Substring(1));

                    Console.WriteLine("Converting to number form...");

                    for (int i = 0; i < message.Length; i++)
                    {
                        char letterChar = message[i];
                        string letter = Convert.ToString(letterChar);

                        numMessage.Add(Array.IndexOf(Alphabet, letter));
                    }

                    Console.WriteLine("Ciphering number form...");
                    List<int> cipherNumMessage = new List<int>();

                    if (cipher[0] == '+')
                    {
                        for (int i = 0; i < message.Length; i++)
                        {
                            int num = numMessage[i];

                            int newNum = num + cipherNum;

                            cipherNumMessage.Add(newNum);
                        }
                    }
                    else if (cipher[0] == '-')
                    {
                        for (int i = 0; i < message.Length; i++)
                        {
                            int num = numMessage[i];

                            int newNum = num - cipherNum;

                            cipherNumMessage.Add(newNum);
                        }
                    }

                    else
                    {
                        throw new Exception("You were caught using an invalid cipher code. You may only use the symbols + and -. Nothing else. You disobeyed that rule and used " + cipher[0] + ".");
                    }

                    Console.WriteLine("Converting cipher number to string...");

                    string ciphertext = "";

                    for (int i = 0; i < message.Length; i++)
                    {
                        int num = cipherNumMessage[i];
                        int outOfBounds;

                        if (num > Alphabet.Length - 1)
                        {
                            outOfBounds = num / 26;
                            num -= 26 * outOfBounds;
                        }

                        if (num < 0)
                        {
                            outOfBounds = num / (0-26);
                            num += 26 * (outOfBounds + 1);
                        }

                        char a = message[i];
                        if (Array.Exists(Alphabet, element => element == a.ToString()))
                            ciphertext += Alphabet[num];
                        else
                            ciphertext += a.ToString();
                    }

                    Console.WriteLine("Encryption complete!");
                    Console.WriteLine("Here is your encrypted message: {0}", ciphertext);
                }

                else if (command == "decrypt")
                {
                    Console.WriteLine("Input message to decrypt");
                    string message = Input();

                    Console.WriteLine("Here are all the possible decryptions for \"{0}\" using the Caesar cipher:", message);
                    Console.WriteLine("(potential cipher, potential plaintext)");

                    for (int j = 1; j < 26; j++)
                    {
                        List<int> numMessage = new List<int>();

                        for (int i = 0; i < message.Length; i++)
                        {
                            char letterChar = message[i];
                            string letter = Convert.ToString(letterChar);

                            numMessage.Add(Array.IndexOf(Alphabet, letter));
                        }

                        List<int> cipherNumMessage = new List<int>();

                        for (int i = 0; i < message.Length; i++)
                        {
                            int num = numMessage[i];

                            int newNum = num - j;

                            cipherNumMessage.Add(newNum);
                        }

                        string ciphertext = "";

                        for (int i = 0; i < message.Length; i++)
                        {
                            int num = cipherNumMessage[i];

                            if (num > Alphabet.Length - 1)
                                num -= 26;
                            if (num < 0)
                                num += 26;

                            char a = message[i];
                            if (Array.Exists(Alphabet, element => element == a.ToString()))
                                ciphertext += Alphabet[num];
                            else
                                ciphertext += a.ToString();
                        }

                        Console.WriteLine(" +{0}:\t{1}", j, ciphertext);
                    }
                }

                // Easter Egg
                else if (command == "throw")
                {
                    Console.WriteLine("Ok sure. I'll throw an exception.");
                    throw new Exception("I threw an exception.");
                }
            }
        }

        public static string Input()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}