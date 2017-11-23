namespace Spelling.Util
{
    public class Word
    {
        public string word { get; set; }
        public int Id { get; set; }

        public Word(string ipWord,int Id)
        {
            word = ipWord;
        }
    }
}