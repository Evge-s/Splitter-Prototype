using System;

namespace TextSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string dictionaryPath = ".\\Resources\\Dictionary.txt";

            string wordPath = string.Empty;
            string resultPath = string.Empty;

            Console.WriteLine("\n\tEnter the path to the file with words:\n");
            Console.Write("-> ");
            wordPath = Console.ReadLine();
            
            Console.WriteLine("\n\tEnter the path to save the result:\n");
            Console.Write("\n-> ");
            resultPath = Console.ReadLine();

            Console.WriteLine("Start..");
            Console.WriteLine("complete");

            // Pass, there should be a check of the correctness of the path

            WordComparer wordComparer = new WordComparer(FileService.ReadFromFile(dictionaryPath));           
            FileService.WriteToFile(wordComparer.WordSeparator(FileService.ReadFromFile(wordPath)), resultPath);    
        }
    }
}
