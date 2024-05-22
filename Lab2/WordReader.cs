using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordReader
{
    static void Main()
    {
        // Initialize a nullable list of strings to hold words
        IList<string>? words = null;

        // Infinite loop to continuously show the menu until the user exits
        while (true)
        {
            // Display the menu and get the user's choice
            string? option = ShowMenu();

            // Handle the user's choice using a switch statement
            switch (option)
            {
                case "1":
                    // Prompt the user to enter the file name
                    Console.WriteLine("==========================\n");
                    Console.Write("Enter the file name (with extension): ");
                    string? filePath = Console.ReadLine();
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        // Import words from the specified file
                        Console.WriteLine("==========================\n");
                        words = ImportWordsFromFile(filePath);
                        Console.WriteLine("\n==========================\n");
                    }
                    else
                    {
                        // Display an error message if the file path is invalid
                        Console.WriteLine("Invalid file path.");
                    }
                    break;
                case "2":
                    // Check if the words list is null, if not, perform bubble sort
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    BubbleSort(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "3":
                    // Check if the words list is null, if not, perform LINQ sort
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    LINQSort(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "4":
                    // Check if the words list is null, if not, count distinct words
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    CountDistinctWords(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "5":
                    // Check if the words list is null, if not, get the last 10 words
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    GetLast10Words(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "6":
                    // Check if the words list is null, if not, reverse print the words
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    ReverseWords(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "7":
                    // Check if the words list is null, if not, get words ending with 'd'
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    GetWordsEndingWithD(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "8":
                    // Check if the words list is null, if not, get words starting with 'q'
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    GetWordsStartingWithQ(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "9":
                    // Check if the words list is null, if not, get words with more than 3 characters and containing 'a'
                    if (IsWordsListNull(words)) break;
                    Console.WriteLine("==========================\n");
                    GetWordsWithAAndMoreThan3Chars(words!);
                    Console.WriteLine("\n==========================\n");
                    break;
                case "X":
                case "x":
                    // Exit the application
                    Console.WriteLine("==========================\n");
                    Console.WriteLine("Exiting from the application.");
                    Console.WriteLine("\n==========================\n");
                    return;
                default:
                    // Display an error message for invalid options
                    Console.WriteLine("==========================\n");
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("\n==========================\n");
                    break;
            }
        }
    }

    // Method to display the menu and get the user's choice
    static string? ShowMenu()
    {
        Console.WriteLine("================= Menu: =================");
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

    // Method to check if the words list is null and display an error message if it is
    static bool IsWordsListNull(IList<string>? words)
    {
        if (words == null)
        {
            Console.WriteLine("Please import words from a file first.");
            return true;
        }
        return false;
    }

    // Method to import words from a file and return a list of words
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

    // Method to perform bubble sort on the list of words
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

    // Method to perform LINQ sort on the list of words
    static IList<string> LINQSort(IList<string> words)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var sortedWords = words.OrderBy(w => w).ToList();
        watch.Stop();
        Console.WriteLine($"LINQ Sort Time: {watch.ElapsedMilliseconds} ms");
        return sortedWords;
    }

    // Method to count the distinct words in the list
    static int CountDistinctWords(IList<string> words)
    {
        int distinctCount = words.Distinct().Count();
        Console.WriteLine($"Distinct Words Count: {distinctCount}");
        return distinctCount;
    }

    // Method to get the last 10 words from the list
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

    // Method to reverse the list of words and print them
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

    // Method to get words ending with 'd' from the list
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

    // Method to get words starting with 'q' from the list
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

    // Method to get words with more than 3 characters and containing 'a'
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
