public abstract class Word
{
    protected string name;
    protected List<string> befores = new List<string>();
    protected List<string> afters = new List<string>();

    public Word(string name, string befores, string afters){
        this.name = name;
        addBefores(befores);
        addAfters(afters);
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

    public override string ToString()
    {
        return $"{Name}\nParent: {toStringBefores()}\nChilderens: {toStringAfters()}";
    }
}