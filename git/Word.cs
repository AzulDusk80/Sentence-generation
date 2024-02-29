public class Word(){
    protected string name;
    protected List<string> befores;
    protected List<string> afters = new List<string>;

    public Word(string name, string befores, string afters){
        this.name = name;
        Befores = befores;
        Afters = afters;
    }

    public string Name{
        get => name;
    }

    public List<string> Befores{
        get => befores;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(Befores));
            befores.add(value);
        }

    }

    public List<string> Afters{
        get => afters;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(Afters));
            afters.add(value);
        }
    }

}