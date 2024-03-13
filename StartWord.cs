﻿public class StartWord : Word
{
	public StartWord(string name, string after, string before = "") : base(name, before, after)
	{
		
	}

    public override void addBefores(string word)
	{
        befores.Add(word);
    }

    public override void addAfters(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            throw new ArgumentNullException(word);
        }
        afters.Add(word);
    }
}
