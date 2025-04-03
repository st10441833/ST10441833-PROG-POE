using System;
using System.Media;
using System.IO;

namespace secure_bot_apk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display the ASCII art logo with border
            DisplayLogo();

            // Play the greeting audio
            if (!PlayGreeting())
            {
                Console.WriteLine("Skipping greeting due to missing or unreadable file.");
            }

            // Ask the user for their name with validation
            string userName = GetUserName();

            // Display a personalized welcome message with a divider
            DisplayWelcomeMessage(userName);

            // Start the basic response system with enhanced structure
            StartResponseSystem(userName);
        }

        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(@"
      ████████████████████████████
      █░░░░░░░░░░░░░░░░░░░░░░░░░█
      █░░██████░░░██████░░██████░█
      █░░█░░░░█░░█░░░░░█░█░░░░░█░█
      █░░██████░░██████░░██████░█
      █░░█░░░░█░░█░░░░░█░█░░░░░█░█
      █░░██████░░██████░░█░░░░░█░█
      █░░░░░░░░░░░░░░░░░░░░░░░░░█
      ████████████████████████████
              🔒 SECURE BOT 🔒
    ");
            Console.WriteLine(new string('=', 50));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Cybersecurity Assistant – Keeping You Safe Online!");
            Console.ResetColor();
            Console.WriteLine(new string('=', 50));
        }

        static bool PlayGreeting()
        {
            try
            {
                string filePath = @"C:\Users\mudau\source\repos\secure_bot_apk\secure_bot_apk\bin\Debug\greetings.wav.wav";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: Audio file not found at " + filePath);
                    return false;
                }

                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.PlaySync(); // Ensures the sound plays before continuing
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting: " + ex.Message);
                return false;
            }
        }

        static string GetUserName()
        {
            string userName;
            do
            {
                Console.Write("\nPlease enter your name: ");
                userName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(userName));

            return userName;
        }

        static void DisplayWelcomeMessage(string userName)
        {
            string border = new string('=', 50);
            Console.WriteLine(border);

            // Dynamic Greeting Based on Time
            string greeting = GetTimeBasedGreeting();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{greeting}, {userName}! Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("I'm here to help you stay safe online.");
            Console.ResetColor();
            Console.WriteLine(border);
            Console.WriteLine();
        }

        static string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 12) return "Good morning";
            else if (hour < 18) return "Good afternoon";
            else return "Good evening";
        }

        static void StartResponseSystem(string userName)
        {
            string divider = new string('-', 50);
            Console.WriteLine(divider);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Feel free to ask me any questions about cybersecurity.");
            Console.ResetColor();
            Console.WriteLine(divider);

            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit")
                {
                    Console.WriteLine("Thank you for chatting! Stay safe online.");
                    break;
                }

                RespondToUser(userInput);
            }
        }

        static void RespondToUser(string question)
        {
            string divider = new string('-', 50);
            Console.ForegroundColor = ConsoleColor.Yellow;

            switch (question)
            {
                case "how are you?":
                    TypingEffect("Bot: I'm just a program, but I'm here to help you!");
                    break;
                case "what's your purpose?":
                    TypingEffect("Bot: My purpose is to provide you with information on cybersecurity best practices.");
                    break;
                case "what can i ask you about?":
                    TypingEffect("Bot: You can ask me about password safety, phishing, safe browsing, and more!");
                    break;
                case "password safety":
                    TypingEffect("Bot: Always use strong, unique passwords and consider using a password manager.");
                    break;
                case "phishing":
                    TypingEffect("Bot: Be cautious of unsolicited emails or messages asking for personal information.");
                    break;
                case "safe browsing":
                    TypingEffect("Bot: Use secure websites (https) and avoid clicking on suspicious links.");
                    break;
                default:
                    TypingEffect("Bot: I didn't quite understand that. Could you rephrase?");
                    break;
            }

            Console.ResetColor();
            Console.WriteLine(divider);
        }

        static void TypingEffect(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(50);  // Slight delay for typing effect
            }
            Console.WriteLine();
        }
    }
}

