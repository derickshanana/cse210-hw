class Program
{
    static void Main(string[] args)
    {
        // Create a library of KJV scriptures
        List<Scripture> scriptureLibrary = CreateKJScriptureLibrary();

        // Select a random scripture from the library
        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Press any key to exit.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    // Create a library of KJV scriptures
    private static List<Scripture> CreateKJScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        // Add KJV scriptures to the library
        Reference ref1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        library.Add(new Scripture(ref1, text1));

        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        library.Add(new Scripture(ref2, text2));

        Reference ref3 = new Reference("Philippians", 4, 13);
        string text3 = "I can do all things through Christ which strengtheneth me.";
        library.Add(new Scripture(ref3, text3));

        Reference ref4 = new Reference("Psalm", 23, 1);
        string text4 = "The Lord is my shepherd; I shall not want.";
        library.Add(new Scripture(ref4, text4));

        Reference ref5 = new Reference("Romans", 8, 28);
        string text5 = "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.";
        library.Add(new Scripture(ref5, text5));

        Reference ref6 = new Reference("Isaiah", 40, 31);
        string text6 = "But they that wait upon the Lord shall renew their strength; they shall mount up with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint.";
        library.Add(new Scripture(ref6, text6));

        Reference ref7 = new Reference("Matthew", 11, 28);
        string text7 = "Come unto me, all ye that labour and are heavy laden, and I will give you rest.";
        library.Add(new Scripture(ref7, text7));

        return library;
    }
}