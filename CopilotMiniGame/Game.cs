using System;

namespace CopilotMiniGame{
    public class Game{
        public static GameMove GetUserMove()
        {
            GameOption userMove;

            while (true)
            {
                Console.Write("Enter your move: ");
                string userInput = Console.ReadLine();

                if (Enum.TryParse(userInput, true, out userMove) && Enum.IsDefined(typeof(GameOption), userMove))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Please enter a valid game option.");
                }
            }

            return new GameMove(userMove);
        }

        public static GameMove GetComputerMove()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(GameOption));
            GameOption randomMove = (GameOption)values.GetValue(random.Next(values.Length));

            return new GameMove(randomMove);
        }

        public static void Play()
        {
            int userScore = 0;
            int computerScore = 0;
            int totalRounds = 0;

            while (true)
            {
                GameMove userMove = GetUserMove();
                GameMove computerMove = GetComputerMove();

                if (userMove.WinsOver(computerMove))
                {
                    Console.WriteLine("You won!");
                    userScore++;
                }
                else if (computerMove.WinsOver(userMove))
                {
                    Console.WriteLine("You lost!");
                    computerScore++;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                Console.WriteLine($"Computer's move: {computerMove.Option.ToString()}");

                Console.Write($"User Score: {userScore}  ||  ");
                Console.WriteLine($"Computer Score: {computerScore}");
                totalRounds++;

                Console.WriteLine("Do you want to play again? (Y/N)");
                string playAgainInput = Console.ReadLine();

                if (playAgainInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Total rounds: {totalRounds}.Thanks for playing!");
                    break;
                }
            }
        }
    }
}