
public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();

        if (statement == "")
        {
            return "Fine. Be that way!";
        }

        bool isQuestion = statement.EndsWith("?");
        bool hasLetters = statement.Any(char.IsLetter);
        bool isYelling = hasLetters && statement.ToUpper() == statement;

        if (isYelling && isQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }

        if (isYelling)
        {
            return "Whoa, chill out!";
        }

        if (isQuestion)
        {
            return "Sure.";
        }

        return "Whatever.";
    }
}