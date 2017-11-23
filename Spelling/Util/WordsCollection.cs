using System.Collections.Generic;

namespace Spelling.Util
{
    public class WordsCollection
    {
        private int curWord = 0;
        private List<Word> words { get; set; }

        public int Count
        {
            get { return words.Count; }
        }

        public long GetItemId(int position)
        {
            return words[position].Id;
        }

        public string GetItem(int position)
        {
            return words[position].word;
        }

        public WordsCollection(List<Word> allWords)
        {
            words = allWords;
        }

        public string getWord()
        {
            string retWord = words[curWord].word;
            curWord++;
            return retWord;
        }

        public bool hasNext()
        {
            return words.Count >= curWord + 1;
        }

        public void deleteWord(string word)
        {
            foreach(Word lword in words)
            {
                RemoveFromList(lword, word);
            }

            string wordList = "";

            foreach(Word lword in words)
            {
                wordList = ("," + lword).TrimStart(',');
            }

            WordsFileHandler.writeWords(wordList);
        }

        private void RemoveFromList(Word curWord, string delWord)
        {
            if (curWord.word.Equals(delWord))
            {
                words.Remove(curWord);
            }
            return;
        }

    }
}