using System.Text;
using System.Text.RegularExpressions;

Generator generator = new Generator();
Console.WriteLine(generator.Generate(10).Shuffle());
Console.WriteLine(generator.Generate(10).Shuffle());

[Flags]
public enum PasswordChars
{
    Alphabet = 1,
    Numbers = 2,
    Symbols = 4
}
class Generator
{
    public readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    public readonly string Numbers = "1234567890";
    public readonly string Symbols = "~@#$%^&*()_+-=?";
    public string Generate(int length)
    {
        string generatedPassword = string.Empty;
        PasswordChars passwordChars = PasswordChars.Alphabet | PasswordChars.Numbers | PasswordChars.Symbols;
        List<string> passwordCharsListing = new();
        #region Flags checking
        if (passwordChars.HasFlag(PasswordChars.Alphabet))
        {
            passwordCharsListing.Add(Alphabet);
        }

        if (passwordChars.HasFlag(PasswordChars.Numbers))
        {
            passwordCharsListing.Add(Numbers);
        }

        if (passwordChars.HasFlag(PasswordChars.Symbols))
        {
            passwordCharsListing.Add(Symbols);
        }
        #endregion

        int minimumCountOfChars = length / passwordCharsListing.Count;
        int remainder = length % passwordCharsListing.Count;
        foreach (var item in passwordCharsListing)
        {
            for(int i = 0; i < minimumCountOfChars; i++)
            {
                Random rnd = new ();
                generatedPassword += item[rnd.Next(item.Length)];
            }
        }
        string passwordSet = string.Join("", passwordCharsListing);
        for (int i = 0; i < remainder; i++)
        {
            Random rnd = new();
            generatedPassword += passwordSet[rnd.Next(passwordSet.Length)];
        }
        return generatedPassword;
    }
}

public static class Extensions
{ 
    public static string Shuffle(this string s)
    {
        char[] charArray = s.ToCharArray();
        Random rng = new Random();
        int n = charArray.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = charArray[k];
            charArray[k] = charArray[n];
            charArray[n] = value;
        }
        return new string(charArray);
    }
    public static void Swap(char a, char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }
}
