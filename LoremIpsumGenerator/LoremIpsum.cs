using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsumGenerator
{
    public static class LoremIpsum
    {
        public const string Path_To_Words = @"C:\\tfs3\\LoremIpsumGenerator\\LoremIpsumGenerator\\Words.txt";
        public static string[] _words;
        public static Random _rnd = new Random();

        public static string Generate(int numParagraphs, bool htmlTags = false)
        {
            var text = File.ReadAllText(Path_To_Words, Encoding.UTF8);
            _words = text.Split(',');
            var generatedText = "";            
            var numSentencesInParagraph = _rnd.Next(2, 5);

            for (var n = 0; n < numParagraphs; n++)
            {
                generatedText += htmlTags == true ? "<p>" : "";

                for (var i = 0; i <= numSentencesInParagraph; i++)
                {
                    generatedText += i > 0 ? " " : "";
                    generatedText += CreateSentence();
                }

                generatedText += htmlTags == true ? "</p>" : "";

                generatedText += Environment.NewLine;
                generatedText += Environment.NewLine;
            }            

            return generatedText;
        }

        private static string CreateSentence()
        {
            var generatedText = "";            
            var numWords = _words.Count();            
            var numWordsInSentence = _rnd.Next(10, 40);
            int? comma = numWordsInSentence > 20 ? (int?)_rnd.Next(10, numWordsInSentence - 5) : null;

            for (var i = 0; i <= numWordsInSentence; i++)
            {
                generatedText += _words[_rnd.Next(0, numWords)];
                generatedText += comma == i ? "," : "";
                generatedText += i == numWordsInSentence ? "." : " ";
            }

            return generatedText.First().ToString().ToUpper() + generatedText.Substring(1);            
        }
    }
}