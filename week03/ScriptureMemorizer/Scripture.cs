using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = Math.Max(1, words.Count / 5); // Hide a few words at a time

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return words.TrueForAll(w => w.GetDisplayText().Contains("_"));
    }

    public string GetDisplayText()
    {
        return reference.GetDisplayText() + " - " + string.Join(" ", words.ConvertAll(w => w.GetDisplayText()));
    }
}
