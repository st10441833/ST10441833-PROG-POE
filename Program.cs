using System;

namespace secure_bot_apk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Display the ASCII art logo with border
            DisplayLogo();

            // Ask the user for their name with validation
            string userName = GetUserName();

            // Display a personalized welcome message with a divider
            DisplayWelcomeMessage(userName);
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
    }
}

