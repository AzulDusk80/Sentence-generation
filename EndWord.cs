public class EndWord : Word
{
    public EndWord(string name, string before, string after = "") : base(name, before, after)
    {

    }

    public override void addBefores(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            throw new ArgumentNullException(word);
        }
        befores.Add(word);
    }

    public override void addAfters(string word)
    {
        afters.Add(word);
    }
}
﻿
