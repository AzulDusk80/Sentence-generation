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



        //You can add a new word
        Console.WriteLine("Add your own word!");
        //addWord(words, algorithms);

        //User input, DO NOT DELETE BELOW THIS!!!**********************************************************
        String[] userInput = getUserWord(words, algorithms);

        Console.WriteLine("\nFinishing the sentence...");

        String generatedSentence = finishSentence(words, algorithms, userInput[0]);

        Console.WriteLine(userInput[1] + generatedSentence);       
    }

    public static void addWord(List<Word> words, Algorithms algorithms) //added word must have a before an after
    {
        String name = "";
        String before = "";
        String after = "";
        
        bool looping = true;
        while (looping)//loops for valid input on name
        {
            Console.WriteLine("What is the name: ");
            name = Console.ReadLine();
            if (!String.IsNullOrEmpty(name))
            {
                if(algorithms.duplicates(name, words))
                {
                    bool looping2 = true;
                    while (looping2)//loops in case of duplicate
                    {
                        Console.WriteLine("This is a already inside, do you want to add to? (Y/N):");
                        String response = Console.ReadLine();
                        if (String.IsNullOrEmpty(response))
                        {
                            Console.WriteLine("Invalid input");
                        }
                        else if (response.Equals("Y"))
                        {
                            looping2 = false;
                            looping = false;
                        }
                        else if (response.Equals("N"))
                        {
                            looping2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }
                }
                else
                {
                    looping = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        looping = true;

        while (looping)//loops for valid before
        {
            Console.WriteLine("What are the words before it? Seperate with space:");
            before = Console.ReadLine();
            if(validList(before, algorithms, words))
                looping = false;
        }

        looping = true;

        while (looping)//loops for valid after
        {
            Console.WriteLine("What are the words after it? Seperate with space:");
            after = Console.ReadLine();
            if (validList(after, algorithms, words))
                looping = false;
        }

        Console.WriteLine("Adding word");
        algorithms.addWordBasedOnString(name, before.Split(" "), after.Split(" "), words);

    }

    public static bool validList(String s, Algorithms algorithms, List<Word> word)//verifies if the list is valid
    {
        String[] arrayBefore = s.Split(" ");
        bool space = false;
        bool repeats = true;
        String fails = "";
        for (int i = 0; i < arrayBefore.Length; i++)
        {
            if (String.IsNullOrEmpty(arrayBefore[i]))
                space = true;
            else if (arrayBefore[i].Equals(" "))
                space = true;
            if (!algorithms.duplicates(arrayBefore[i], word))
            {
                repeats = false;
                fails += arrayBefore[i] + " ";
            }
        }

        if (space)
        {
            Console.WriteLine("Invalid input in words");
        }
        else if (!repeats)
        {
            Console.WriteLine($"Word is not in the libary: {fails}");
        }
        else
        {
            return true;
        }
        return false;
    } 

    public static string[] getUserWord(List<Word> words, Algorithms algorithms) //given words and algorithms, it returns a valid word and the sentence the user inputted
    {
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
        String[] user = {currentWord, generatedSentece};
        return user;
    }

    public static string finishSentence(List<Word> words, Algorithms algorithms, string currentWord)//given words, algorithms, and valid word. Returns a string generated sentence
    {
        bool notValid = true;
        string generatedSentece = "";
        while (notValid)
        {
            Word current = words[algorithms.indexList(currentWord, words)];
            currentWord = current.nextWord();
            generatedSentece += " " + currentWord;

            if (words[algorithms.indexList(currentWord, words)] is EndWord)
                notValid = false;

        }

        return generatedSentece;
    }
}
 