using System;
using System.Text;

namespace RemoveDuplicateWordsTask
{
    /// <summary>
    /// Remove duplicate words.
    /// </summary>
    public static class WordsManipulation
    {
        /// <summary>
        /// Removes all duplicate words from string, leaving only single (first) words entries.
        /// Case sensitivity of finding duplicates depends on the caseSensitive argument.
        /// By word we shall mean the unit that consists only of latin alphabet characters and numbers.
        /// All other characters should be considered delimiters between words.
        /// </summary>
        /// <param name="text">Source text.</param>
        /// <param name="caseSensitive">Defines case sensitivity.</param>
        /// <exception cref="ArgumentException">If source text is null or empty.</exception>
        public static void RemoveDuplicateWords(ref string? text, bool caseSensitive)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Source text is null or empty");
            }

            StringBuilder wordFromText = new StringBuilder();
            List<string> words = new List<string>();
            HashSet<string> wordsWitoutDuplicates = new HashSet<string>(caseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
            StringBuilder result = new StringBuilder();

            foreach (var symbol in text)
            {
                if (char.IsLetterOrDigit(symbol))
                {
                    wordFromText.Append(symbol);
                }
                else
                {
                    if (wordFromText.Length > 0)
                    {
                        words.Add(wordFromText.ToString());
                        wordFromText.Clear();
                    }

                    words.Add(symbol.ToString());
                }
            }

            if (wordFromText.Length > 0)
            {
                words.Add(wordFromText.ToString());
            }

            foreach (var word in words)
            {
                result.Append(wordsWitoutDuplicates.Add(word) || !char.IsLetterOrDigit(word[0]) ? word : string.Empty);
            }

            text = result.ToString();
        }
    }
}
