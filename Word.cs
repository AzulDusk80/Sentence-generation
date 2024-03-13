public abstract class Word
{
    Random rand = new Random();
    protected string name;
    protected List<string> befores = new List<string>();
    protected List<string> afters = new List<string>();

    public Word(string name, string before, string after){
        this.name = name;
        addBefores(before);
        addAfters(after);
    }

    public string Name{
        get => name;
    }

    public String toStringBefores()
    {
        string words = "";
        foreach (string word in befores)
        {
            if (string.IsNullOrEmpty(word))
                words += "\" null \" ";
            else
                words += word + " ";

        }
        return words;
    }

    public abstract void addBefores(string word);

    public String toStringAfters()
    {
        string words = "";
        foreach (string word in afters)
        {
            if (string.IsNullOrEmpty(word))
                words += "\" null \" ";
            else
                words += word + " ";

        }
        return words;
    }

    public abstract void addAfters(string word);
	
	public string nextWord()
	{
        int index = rand.Next(0, afters.Count);
        return afters[index];
	}

    public override string ToString()
    {
        return $"Name: {Name}\nParent: {toStringBefores()}\nChilderens: {toStringAfters()}";
    }
}
