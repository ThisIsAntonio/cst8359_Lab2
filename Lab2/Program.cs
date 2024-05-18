using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        IList<string>? words = null;
        while (true)
        {
            string? option = ShowMenu();

            switch (option)
            {
                case "1":
                    Console.Write("Enter the file name (with extension): ");
                    string? filePath = Console.ReadLine();
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        words = ImportWordsFromFile(filePath);
                    }
                    else
                    {
                        Console.WriteLine("Invalid file path.");
                    }
                    break;
                case "2":
                    if (IsWordsListNull(words)) break;
                    BubbleSort(words!);
                    break;
                case "3":
                    if (IsWordsListNull(words)) break;
                    LINQSort(words!);
                    break;
                case "4":
                    if (IsWordsListNull(words)) break;
                    CountDistinctWords(words!);
                    break;
                case "5":
                    if (IsWordsListNull(words)) break;
                    GetLast10Words(words!);
                    break;
                case "6":
                    if (IsWordsListNull(words)) break;
                    ReverseWords(words!);
                    break;
                case "7":
                    if (IsWordsListNull(words)) break;
                    GetWordsEndingWithD(words!);
                    break;
                case "8":
                    if (IsWordsListNull(words)) break;
                    GetWordsStartingWithQ(words!);
                    break;
                case "9":
                    if (IsWordsListNull(words)) break;
                    GetWordsWithAAndMoreThan3Chars(words!);
                    break;
                case "X":
                case "x":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static string? ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Import Words from File");
        Console.WriteLine("2. Bubble Sort words");
        Console.WriteLine("3. LINQ/Lambda sort words");
        Console.WriteLine("4. Count Distinct Words");
        Console.WriteLine("5. Take the last 10 words");
        Console.WriteLine("6. Reverse print the words");
        Console.WriteLine("7. Get and display the words that end with 'd'");
        Console.WriteLine("8. Get and display the words that start with letter 'q'");
        Console.WriteLine("9. Get and display the words that are more than 3 characters long and contain the letter 'a'");
        Console.WriteLine("X. Exit");
        Console.Write("Select an option: ");
        return Console.ReadLine();
    }

    static bool IsWordsListNull(IList<string>? words)
    {
        if (words == null)
        {
            Console.WriteLine("Please import words from a file first.");
            return true;
        }
        return false;
    }

    static IList<string> ImportWordsFromFile(string path)
    {
        IList<string> words = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? word;
                while ((word = reader.ReadLine()) != null)
                {
                    if (word != null)
                    {
                        words.Add(word);
                    }
                }
            }
            Console.WriteLine($"Number of words read: {words.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return words;
    }

    static IList<string> BubbleSort(IList<string> words)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < words.Count - 1; i++)
        {
            for (int j = 0; j < words.Count - i - 1; j++)
            {
                if (string.Compare(words[j], words[j + 1], StringComparison.Ordinal) > 0)
                {
                    string temp = words[j];
                    words[j] = words[j + 1];
                    words[j + 1] = temp;
                }
            }
        }
        watch.Stop();
        Console.WriteLine($"Bubble Sort Time: {watch.ElapsedMilliseconds} ms");
        return words;
    }

    static IList<string> LINQSort(IList<string> words)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var sortedWords = words.OrderBy(w => w).ToList();
        watch.Stop();
        Console.WriteLine($"LINQ Sort Time: {watch.ElapsedMilliseconds} ms");
        return sortedWords;
    }

    static int CountDistinctWords(IList<string> words)
    {
        int distinctCount = words.Distinct().Count();
        Console.WriteLine($"Distinct Words Count: {distinctCount}");
        return distinctCount;
    }

    static IList<string> GetLast10Words(IList<string> words)
    {
        var last10Words = words.Skip(Math.Max(0, words.Count - 10)).ToList();
        Console.WriteLine("Last 10 Words:");
        foreach (var word in last10Words)
        {
            Console.WriteLine(word);
        }
        return last10Words;
    }

    static IList<string> ReverseWords(IList<string> words)
    {
        var reversedWords = words.AsEnumerable().Reverse().ToList();
        Console.WriteLine("Reversed Words:");
        foreach (var word in reversedWords)
        {
            Console.WriteLine(word);
        }
        return reversedWords;
    }

    static IList<string> GetWordsEndingWithD(IList<string> words)
    {
        var wordsEndingWithD = words.Where(w => w != null && w.EndsWith("d")).ToList();
        Console.WriteLine($"Words ending with 'd': {wordsEndingWithD.Count}");
        foreach (var word in wordsEndingWithD)
        {
            Console.WriteLine(word);
        }
        return wordsEndingWithD;
    }

    static IList<string> GetWordsStartingWithQ(IList<string> words)
    {
        var wordsStartingWithQ = words.Where(w => w != null && w.StartsWith("q")).ToList();
        Console.WriteLine($"Words starting with 'q': {wordsStartingWithQ.Count}");
        foreach (var word in wordsStartingWithQ)
        {
            Console.WriteLine(word);
        }
        return wordsStartingWithQ;
    }

    static IList<string> GetWordsWithAAndMoreThan3Chars(IList<string> words)
    {
        var wordsWithA = words.Where(w => w != null && w.Length > 3 && w.Contains("a")).ToList();
        Console.WriteLine($"Words with more than 3 characters and containing 'a': {wordsWithA.Count}");
        foreach (var word in wordsWithA)
        {
            Console.WriteLine(word);
        }
        return wordsWithA;
    }
}
