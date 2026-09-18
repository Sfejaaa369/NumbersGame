using System.Threading.Channels;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool for being able to end while loop after 5 guess attempts
            //starting with true, gets changes to false later on if player decides to notplay again
            bool play = true;

            //bool for being able to end for loop or write out message if number not guessed in 5 attempts
            //starting with false, gets changed to true later on if the user guesses the correct number
            bool GuessedCorrectly = false;

            //as long as the bool play is true, the game can be played again
            while (play)
            {
                //outside of the for loop because I don't want to select a new random number for every guess
                //inside of the while loop because I want to get a new secret number for each time the player plays the game
                Random random = new Random();
                int secretNumber = random.Next(1, 21);

                //outside of the for loop because I don't want to repeat this message every time they guess
                //inside of the while loop because I want to show this message for the first guess of each game
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

                //for loop, because we know in advance how many times we want to loop maximum (5)
                for (int attempts = 1; attempts <= 5; attempts++)
                {
                    int userNumber = int.Parse(Console.ReadLine());
                    CheckGuess(userNumber, secretNumber);

                    //if they guessed the correct number, we end the loop
                    if (userNumber == secretNumber)
                    {
                        GuessedCorrectly = true; //bool gets updated from false to true when user guesses the correct number
                        break;
                    }
                }

                //outside of the for loop, otherwise it always writes out this message
                if (GuessedCorrectly == false) //if user didn't manage to guess correct number
                {
                    Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                }

                Console.WriteLine("Vill du spela igen? Svara gärna med 'ja' eller 'nej':");
                string userPlayAgain = Console.ReadLine();

                //if user no longer wants to play, change bool to false to end while loop
                if (userPlayAgain == "nej") 
                {
                    play = false;
                }
            }
        }

        public static void CheckGuess(int guess, int secret) 
        {
            if (guess > secret) //if they guessed too high
            {
                Console.WriteLine("Tyvärr,du gissade för högt!");
            }
            else if (guess < secret) //if they guessed too low
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
            }
            else //if they guessed exactly right
            {
                Console.WriteLine("Woohoo! Du klarade det!");
            }
        }
    }
}