
public static class PigLatin
{
    public static string Translate(string word)
    {
        string[] words = word.Split(' ');

        for (int j = 0; j < words.Length; j++)
        {
            string current = words[j];

            if ("aeiou".Contains(current[0]) ||
                current.StartsWith("xr") ||
                current.StartsWith("yt"))
            {
                words[j] = current + "ay";
                continue;
            }

            int i = 0;

            while (i < current.Length)
            {
                if (i + 1 < current.Length &&
                    current.Substring(i, 2) == "qu")
                {
                    i += 2;
                    break;
                }

                if ("aeiou".Contains(current[i]))
                    break;

                if (current[i] == 'y' && i > 0)
                    break;

                i++;
            }

            words[j] = current.Substring(i) +
                       current.Substring(0, i) + "ay";
        }

        return string.Join(" ", words);
    }
}