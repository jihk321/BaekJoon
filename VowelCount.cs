namespace BaekJoon;

public class VowelCount
{
    static char[] vowel = new char[] { 'a', 'e', 'i', 'o', 'u' };
    static char[] delimiter = { '!', '\n', '?', '.' };

    public VowelCount()
    {
        while (true)
        {
            string text = Input();
            if (string.IsNullOrEmpty(text)) break;
            Console.WriteLine(GetVowelCount(text));
        }
    }
    public string Input()
    {
#nullable disable
        string texts = Console.ReadLine();

        if (texts.Contains("#")) texts = string.Empty;
        return texts;
    }

    public int GetVowelCount(string text)
    {
        int count = 0;

        foreach (char c in text.ToLower().ToCharArray())
        {
            foreach (char cc in vowel)
                if (c.Equals(cc)) count++;
        }

        return count;
    }
}
