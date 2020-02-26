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

        public static string[] Atbash = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
        "s", "t", "u", "v", "w", "x", "y", "z"};

        static void Main(string[] args)
        {
            try
            {
                Code();
            }
            catch (Exception e)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("You broke it!");
                Console.WriteLine("How dare you!");
                Console.WriteLine("\n{0}\n", e);
                Console.WriteLine("Because of your behavior, you will be forced to exit the program now.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        }

        public static void Code()
        {
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            Random rnd = new Random();

            Array.Reverse(Atbash);

            // Startup Message
            Console.WriteLine("Welcome to Encrypt Decrypt! (Atbash Cipher)");
            Console.WriteLine("Please note that when encrypting or decrypting, only lowercase numbers will be changed.");
            Console.WriteLine("This cipher offers very little security and thus should not be used often.");
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
                    Console.WriteLine(" encrypt:  Encrypt or decrypt a message using the Atbash Cipher.");
                    Console.WriteLine(" decrypt:  Same as \"encrypt\".");
                    Console.WriteLine("    help:  Get help the different commands available.");
                    Console.WriteLine("    exit:  Exit the program.");
                }

                else if (command == "encrypt" || command == "decrypt")
                {
                    // Encryption

                    Console.WriteLine("Input message to encrypt/decrypt");
                    string message = Input();

                    Console.Write("Done: ");

                    for (int i = 0; i < message.Length; i++)
                    {
                        if (Array.Exists(Alphabet, element => element == message[i].ToString()))
                            Console.Write(Atbash[Array.IndexOf(Alphabet, message[i].ToString())]);
                        else
                            Console.Write(message[i]);
                    }

                    Console.WriteLine();
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