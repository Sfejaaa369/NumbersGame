namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool for being able to end while loop after guess attempts
            //starting with true, gets changes to false later on if player decides to not play again
            bool play = true;

            //as long as the bool play is true, the game can be played again
            while (play)
            {
                //bool for being able to end for loop or write out message if number not guessed in attempts
                //starting with false, gets changed to true later on if the user guesses the correct number
                //bool has to be in while loop in case user wishes to play multiple times to ensure the "sorry you didn't magae to guess in x tries" gets shown
                bool guessedCorrectly = false;

                //bool to show if user played a game or not
                //needed to ensure right info is shown when user writes another number than 1-3 when choosing level 
                bool playedGame = false;

                //ask user for which level they wish to play
                Console.WriteLine("Hej! Välj en nivå genom att skriva en siffra mellan 1 och 3:\n" +
                    "[1] Easy\n" +
                    "[2] Medium\n" +
                    "[3] Difficult");

                //save user input and convert from string to int
                try
                {
                    int userLevel = int.Parse(Console.ReadLine());
                
                switch (userLevel)
                {
                    case 1: //code for the easy game: number 1-10, 5 tries
                        Random randomCase1 = new Random();
                        int secretNumberCase1 = randomCase1.Next(1, 11);

                        Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 10. Kan du gissa vilket? Du får fem försök.");

                        for (int attempts = 1; attempts <= 5; attempts++)
                        {
                            int userNumber = int.Parse(Console.ReadLine());
                            CheckGuess(userNumber, secretNumberCase1);

                            //if they guessed the correct number, we end the loop
                            if (userNumber == secretNumberCase1)
                            {
                                guessedCorrectly = true; //bool gets updated from false to true when user guesses the correct number
                                break;
                            }
                        }

                        //outside of the for loop, otherwise it always writes out this message
                        if (guessedCorrectly == false) //if user didn't manage to guess correct number
                        {
                            Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                        }
                            playedGame = true;
                        break;

                    case 2: //code for the medium game: 1-20, 5 tries
                        Random randomCase2 = new Random();
                        int secretNumberCase2 = randomCase2.Next(1, 21);

                        Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. Kan du gissa vilket? Du får fem försök.");

                        for (int attempts = 1; attempts <= 5; attempts++)
                        {
                            int userNumber = int.Parse(Console.ReadLine());
                            CheckGuess(userNumber, secretNumberCase2);

                            if (userNumber == secretNumberCase2)
                            {
                                guessedCorrectly = true;
                                break;
                            }
                        }

                        if (guessedCorrectly == false) 
                        {
                            Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
                        }

                            playedGame = true;
                        break;

                    case 3: //code for the difficult game: 1-20, 3 tries
                        Random randomCase3 = new Random();
                        int secretNumberCase3 = randomCase3.Next(1, 21);

                        Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. Kan du gissa vilket? Du får tre försök.");

                        for (int attempts = 1; attempts <= 3; attempts++)
                        {
                            int userNumber = int.Parse(Console.ReadLine());
                            CheckGuess(userNumber, secretNumberCase3);

                            if (userNumber == secretNumberCase3)
                            {
                                guessedCorrectly = true;
                                break;
                            }
                        }

                        if (guessedCorrectly == false)
                        {
                            Console.WriteLine("Tyvärr, du lyckades inte gissa talet på tre försök!");
                        }
                            playedGame = true;

                        break;

                        default: //in case the user writes a number that's not between 1 and 3
                            Console.WriteLine("Du måste skriva en siffra mellan 1 och 3!");
                            break;
                }

                    //keep this out of the switch cases since it applies to all cases
                    if (playedGame == true)
                    {
                        Console.WriteLine("Vill du spela igen? Svara gärna med 'ja' eller 'nej':");
                        string userPlayAgain = Console.ReadLine();

                        //if user no longer wants to play, change bool to false to end while loop
                        if (userPlayAgain == "nej")
                        {
                            play = false;
                        }
                    }
                
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du måste skriva en siffra!");
                }
            }
        }

        public static void CheckGuess(int guess, int secret) 
        {
            //array with multiple text options about the guess being too high
            string[] tooHigh = 
                {"Det var för högt. Försök igen!", 
                "Oops, det var för högt. Försök igen.", 
                "Hoppsan, det var för högt. Gissa igen.", 
                "Nope, för högt. Försök igen!", 
                "Trevligt att du gissar men det var för högt. Försök igen." 
                };

            //array with multiple text options about the guess being too high
            string[] tooLow = 
                {"Det var för lågt. Försök igen!",
                "Oops, det var för lågt. Försök igen.",
                "Hoppsan, det var för lågt. Gissa igen.",
                "Nope, för lågt. Försök igen!",
                "Trevligt att du gissar men det var för lågt. Försök igen."
                };


            if (guess > secret) //if they guessed too high
            {
                Random tooHighAnswer = new Random(); //create a new instance of random
                int tooHighText = tooHighAnswer.Next(tooHigh.Length); //choose a random answer from the array
                Console.WriteLine(tooHigh[tooHighText]); //write out the randomly chosen text from the array

                //code that I had before adding an array for varied messages if the user guessed too high
                //Console.WriteLine("Tyvärr,du gissade för högt!");
            }
            else if (guess < secret) //if they guessed too low
            {
                Random tooLowAnswer = new Random(); //create a new instance of random
                int tooLowText = tooLowAnswer.Next(tooLow.Length); //choose a random answer from the array
                Console.WriteLine(tooLow[tooLowText]); //write out the randomly chosen text from the array

                //code that I had before adding an array for varied messages if the user guessed too low
                //Console.WriteLine("Tyvärr, du gissade för lågt!");
            }
            else //if they guessed exactly right
            {
                Console.WriteLine("Woohoo! Du klarade det!");
            }
        }
    }
}