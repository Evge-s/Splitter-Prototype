using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextSplitter
{
    public class FileService
    {
        public static List<string> ReadFromFile(string filePath)
        {
            List<string> words = new List<string>();
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(line.ToLower());
                }
            }
            return words;
        }

        public static void WriteToFile(List<string> result, string filePath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream fstream = new FileStream(filePath + "\\Result.txt", FileMode.OpenOrCreate))
            {
                StringBuilder temp = new StringBuilder();
                foreach (var item in result)
                {
                    temp.Append(item);
                }
                byte[] array = Encoding.Default.GetBytes(temp.ToString());

                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
