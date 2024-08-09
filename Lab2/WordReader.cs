/*
 * .Net - Lab2
 * Student Name: Marcos Astudillo Carrasco
 * Student Number: 041057439
 * Course: CST8359
 * Lab Section: 301
 */
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
        // Initialize a list to store the words
        IList<string> words = new List<string>();

        try
        {
            // Open the file with a StreamReader
            using (StreamReader reader = new StreamReader(path))
            {
                string? word;

                // Read each line in the file
                while ((word = reader.ReadLine()) != null)
                {
                    // If the line is not null, add it to the list
                    if (word != null)
                    {
                        words.Add(word);
                    }
                }
            }

            // Output the number of words read from the file
            Console.WriteLine($"Number of words read: {words.Count}");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during file reading
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Return the list of words
        return words;
    }


    // Method to perform bubble sort on the list of words
    static IList<string> BubbleSort(IList<string> words)
    {
        var sortedWords = words.ToList();
        // Start a stopwatch to measure the sorting time
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Outer loop to iterate through the list of words
        for (int i = 0; i < sortedWords.Count - 1; i++)
        {
            // Inner loop to compare adjacent words
            for (int j = 0; j < sortedWords.Count - i - 1; j++)
            {
                // Compare the current word with the next word
                if (string.Compare(sortedWords[j], sortedWords[j + 1], StringComparison.Ordinal) > 0)
                {
                    // Swap the words if they are in the wrong order
                    string temp = sortedWords[j];
                    sortedWords[j] = sortedWords[j + 1];
                    sortedWords[j + 1] = temp;
                }
            }
        }

        // Stop the stopwatch after sorting is complete
        watch.Stop();

        // Output the time taken to perform the bubble sort
        Console.WriteLine($"Bubble Sort Time: {watch.ElapsedMilliseconds} ms");

        // Return the sorted list of words
        return sortedWords;
    }


    // Method to perform LINQ sort on the list of words
    static IList<string> LINQSort(IList<string> words)
    {
        // Start a stopwatch to measure the sorting time
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Use LINQ to sort the words in ascending order and convert to a list
        var sortedWords = words.OrderBy(w => w).ToList();

        // Stop the stopwatch after sorting is complete
        watch.Stop();

        // Output the time taken to perform the LINQ sort
        Console.WriteLine($"LINQ Sort Time: {watch.ElapsedMilliseconds} ms");

        // Return the sorted list of words
        return sortedWords;
    }

    // Method to count the distinct words in the list
    static int CountDistinctWords(IList<string> words)
    {
        // Use LINQ to count the number of distinct words in the list
        int distinctCount = words.Distinct().Count();

        // Output the count of distinct words
        Console.WriteLine($"Distinct Words Count: {distinctCount}");

        // Return the count of distinct words
        return distinctCount;
    }

    // Method to get the last 10 words from the list
    static IList<string> GetLast10Words(IList<string> words)
    {
        // Use LINQ to skip elements and get the last 10 words from the list
        var last10Words = words.TakeLast(Math.Max(0, words.Count - 10)).ToList();

        // Output the last 10 words
        Console.WriteLine("Last 10 Words:");
        foreach (var word in last10Words)
        {
            Console.WriteLine(word);
        }

        // Return the list of the last 10 words
        return last10Words;
    }

    // Method to reverse the list of words and print them
    static IList<string> ReverseWords(IList<string> words)
    {
        // Use LINQ to reverse the order of the words in the list
        var reversedWords = words.AsEnumerable().Reverse().ToList();

        // Output the reversed list of words
        Console.WriteLine("Reversed Words:");
        foreach (var word in reversedWords)
        {
            Console.WriteLine(word);
        }

        // Return the reversed list of words
        return reversedWords;
    }

    // Method to get words ending with 'd' from the list
    static IList<string> GetWordsEndingWithD(IList<string> words)
    {
        // Use LINQ to filter words that are not null and end with 'd'
        var wordsEndingWithD = words.Where(w => w != null && w.EndsWith("d")).ToList();

        // Output the count of words ending with 'd'
        Console.WriteLine($"Words ending with 'd': {wordsEndingWithD.Count}");

        // Output each word that ends with 'd'
        foreach (var word in wordsEndingWithD)
        {
            Console.WriteLine(word);
        }

        // Return the list of words ending with 'd'
        return wordsEndingWithD;
    }

    // Method to get words starting with 'q' from the list
    static IList<string> GetWordsStartingWithQ(IList<string> words)
    {
        // Use LINQ to filter words that are not null and start with 'q'
        var wordsStartingWithQ = words.Where(w => w != null && w.StartsWith("q")).ToList();

        // Output the count of words starting with 'q'
        Console.WriteLine($"Words starting with 'q': {wordsStartingWithQ.Count}");

        // Output each word that starts with 'q'
        foreach (var word in wordsStartingWithQ)
        {
            Console.WriteLine(word);
        }

        // Return the list of words starting with 'q'
        return wordsStartingWithQ;
    }

    // Method to get words with more than 3 characters and containing 'a'
    static IList<string> GetWordsWithAAndMoreThan3Chars(IList<string> words)
    {
        // Use LINQ to filter words that are not null, have more than 3 characters, and contain 'a'
        var wordsWithA = words.Where(w => w != null && w.Length > 3 && w.Contains("a")).ToList();

        // Output the count of words that meet the criteria
        Console.WriteLine($"Words with more than 3 characters and containing 'a': {wordsWithA.Count}");

        // Output each word that meets the criteria
        foreach (var word in wordsWithA)
        {
            Console.WriteLine(word);
        }

        // Return the list of words that meet the criteria
        return wordsWithA;
    }

}
