public class Translator
{
    // Translate words from one language to another.

    private static Dictionary<string, string> translations = new Dictionary<string, string>();

    public static void Run()
    {
        AddWord("hello", "hallo");
        AddWord("world", "welt");
        AddWord("cat", "katze");
        AddWord("dog", "hund");
        AddWord("house", "haus");
        AddWord("book", "buch");
        AddWord("water", "wasser");
        AddWord("friend", "freund");

        Console.WriteLine($"hello  -> {Translate("hello")}");
        Console.WriteLine($"world  -> {Translate("world")}");
        Console.WriteLine($"cat    -> {Translate("cat")}");
        Console.WriteLine($"dog    -> {Translate("dog")}");
        Console.WriteLine($"house  -> {Translate("house")}");
        Console.WriteLine($"book   -> {Translate("book")}");
        Console.WriteLine($"water  -> {Translate("water")}");
        Console.WriteLine($"friend -> {Translate("friend")}");
        Console.WriteLine($"car    -> {Translate("car")}");
        Console.WriteLine($"tree   -> {Translate("tree")}");
    }

    private static void AddWord(string word, string translation)
    {
        translations[word] = translation;
    }

    private static string Translate(string word)
    {
        if (translations.TryGetValue(word, out string? translation))
        {
            return translation;
        }
        return "???";
    }
}