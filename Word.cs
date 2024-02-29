public class Word{
    protected string name;
    protected List<string> befores = new List<string>();
    protected List<string> afters = new List<string>();

    public Word(string name, string befores, string afters){
        this.name = name;
        AddBefore(befores);
    }

    public string Name{
        get => name;
    }

    public List<string> Befores{
        get => befores;
    }

    public List<string> Afters{
        get => afters;
    }

    public void AddBefore(string before)
    {
        if (string.IsNullOrWhiteSpace(before))
            throw new ArgumentNullException(nameof(AddBefore));
        befores.Add(before);
    }
}