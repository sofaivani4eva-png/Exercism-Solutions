
using System;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;

    public Anagram(string baseWord)
    {
        _baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        string normalizedBase = _baseWord.ToUpperInvariant();
        string sortedBase = SortLetters(normalizedBase);

        return potentialMatches
            .Where(word =>
                word.ToUpperInvariant() != normalizedBase &&
                SortLetters(word.ToUpperInvariant()) == sortedBase)
            .ToArray();
    }

    private static string SortLetters(string word)
    {
        return new string(word.OrderBy(c => c).ToArray());
    }
}