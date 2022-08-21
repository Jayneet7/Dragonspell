using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Util 
{
    public class WordList
    {
        private static WordList s_instance;
        private string[] words;

        public static WordList Instance
        {
            get 
            {
                return s_instance ?? LoadWord();
            }
        }
        private WordList(string[] words)
        {
            this.words = words;    
        }

        private static bool IsWordOk(string word) 
        {
            if (word.Length < 1)
                return false;

            foreach(char c in word)
            {
                if (!Textutil.IsAlpha(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static WordList LoadWord()
        {
            if(s_instance != null)
            {
                return s_instance;
            }

            HashSet<string> wordlist = new();
            TextAsset asset = Resources.Load("words") as TextAsset;
            TextReader src = new StringReader(asset.text);

            while (src.Peek() != -1)
            {
                string word = src.ReadLine();

                if (IsWordOk(word))
                {
                    wordlist.Add(word);
                }
            }
            Resources.UnloadAsset(asset);
            
            string[] words = new string[wordlist.Count];
            wordlist.CopyTo(words);

            s_instance = new WordList(words);
            return s_instance;
        }
        public string NextWord(int exp)
        {
            int index = (int)(Random.value * (words.Length - 1));
            return words[index];
        }
    }
}
