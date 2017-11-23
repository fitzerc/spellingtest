using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Spelling.Util
{
    public class WordsFileHandler
    {
        public static string getWords()
        {
            if (!System.IO.File.Exists(getPath()))
            {
                writeWords("");
                return "";
            }

            string words = "";
            using (StreamReader sr = new StreamReader(getPath()))
            {
                words = sr.ReadToEnd();
            }
            return words;
        }

        public static List<Word> GetWordsList()
        {
            List<Word> words = new List<Word>();
            int curId = 0;
            foreach(string lword in getWords().Split(','))
            {
                words.Add(new Word(lword,curId);
                curId++;
            }
            return words;
        }

        public static void appendWord(string word)
        {
            string words = getWords();
            words += "," + word;
            writeWords(words.TrimStart(','));
        }

        public static void writeWords(string words)
        {
            File.WriteAllText(getPath(), words);
        }

        private static string getPath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            return Path.Combine(path, "words.txt");
        }
    }
}