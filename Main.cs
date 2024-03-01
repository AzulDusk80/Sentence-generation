using System.Globalization;

public static class main{
    private static void Main()
    {
        //required to work: word list and algorithms
        List<Word> words = new List<Word>();
        Algorithms algorithms = new Algorithms();

        //example sentence, anything below can be removed**************************************************
        String sentence = "It is always a good idea to remind people it is important to clear their sidewalks as soon as they can. It is also important to remind people to watch their steps when they take the risk of walking over ice and to stay focused on keeping themselves balanced to decrease the danger. Ignoring this increases the risk of injury and death.";
        String[] split = sentence.Split(" ");

        //given a split string and word array it will add the split into the word
        algorithms.addStringArrayToList(split, words);

        //testing
        for (int i = 0; i < words.Count; ++i)
        {
            Console.WriteLine(words[i] + "\n");
        }


        //User input, DO NOT DELETE BELOW THIS!!!**********************************************************
        bool notValid = true;
        String currentWord = "";
        String generatedSentece = "";
        while (notValid)
        {
            Console.WriteLine("\nEnter an uncomplete sentence, do not end with a space:");
            String userSentence = Console.ReadLine();
            if (string.IsNullOrEmpty(userSentence))
            {
                Console.WriteLine("Not valid");
            }
            else
            {
                generatedSentece = userSentence;
                string[] tempArray = userSentence.Split(" ");
                currentWord = tempArray[tempArray.Length - 1];
                if (algorithms.duplicates(currentWord, words))
                {
                    if (words[algorithms.indexList(currentWord, words)] is EndWord)
                        Console.WriteLine($"Sorry but {currentWord} is an end word.");
                    else
                        notValid = false;
                }
                else
                    Console.WriteLine($"Sorry but {currentWord} is not in our libary");
            }
        }

        Console.WriteLine("\nFinishing the sentence...");

        notValid = true;
        while (notValid)
        {
            Word current = words[algorithms.indexList(currentWord, words)];
            currentWord = current.nextWord();
            generatedSentece += " " + currentWord;

            if (words[algorithms.indexList(currentWord, words)] is EndWord)
                notValid = false;

        }

        Console.WriteLine("\n" + generatedSentece);
    }
}
 
