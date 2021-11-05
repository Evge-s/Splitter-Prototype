using System.Collections.Generic;
using System.Linq;

namespace TextSplitter
{
    public class WordComparer
    {
        private List<string> finalResult = new List<string>();
        private List<string> temporatyResult = new List<string>();
        private Dictionary<char, List<string>> dictionary = new Dictionary<char, List<string>>();

        public WordComparer(List<string> dictionaryWords)
        {
            FillDictionary(dictionaryWords);
        }

        private WordComparer() { }

        private void FillDictionary(List<string> dictionaryWords)
        {
            foreach (var item in dictionaryWords)
            {
                if (dictionary.ContainsKey(item[0]))
                {
                    dictionary[item[0]].Add(item);
                }
                else
                {
                    dictionary.Add(item[0], new List<string>() { item });
                }
            }
        }

        private bool CheckExist(string str, bool isFirstSearch)
        {
            foreach (var item in dictionary[str[0]].OrderBy(s => s.Length).Reverse())
            {
                if (item.Length == str.Length)
                {
                    if (item.Equals(str))
                    {
                        if (isFirstSearch)
                        {
                            isFirstSearch = false;
                        }
                        else
                        {
                            temporatyResult.Add(item);
                            return true;
                        }
                    }
                }
                else if (item.Length < str.Length)
                {
                    if (item.Equals(str.Substring(0, item.Length)))
                    {
                        temporatyResult.Add(item);
                        return CheckExist(str.Substring(item.Length), false);
                    }
                }
            }
            temporatyResult.Clear();
            return false;
        }

        private string CreateFinalString(string word)
        {
            string finalString = $"(in) { word } -> (out) ";
            if (temporatyResult.Count > 0)
            {
                foreach (var item in temporatyResult)
                    finalString += item + ",";

                finalString = finalString.TrimEnd(',');
                finalString += "\n";
                temporatyResult.Clear();
            }
            else
                finalString += word + "\n";
            return finalString;
        }

        public List<string> WordSeparator(List<string> words)
        {
            foreach (var item in words)
            {
                CheckExist(item.ToLower(), true);
                finalResult.Add(CreateFinalString(item));

            }
            return finalResult;
        }
    }
}
