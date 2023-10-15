namespace SimpleProject.Helpers
{
    public static class NounHelper
    {
        /// <summary>
        /// статичний метод для отримання множини для іменника відповідно до правил англійської мови
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string GetPluralForm(string word)
        {
            if (string.IsNullOrEmpty(word))
                return word; // Return the original word if it's empty or null

            // Check for some common pluralization rules
            if (word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z") || word.EndsWith("ch") || word.EndsWith("sh"))
            {
                return word + "es"; // Add "es" for words ending in s, x, z, ch, sh
            }
            else if (word.EndsWith("y") && word.Length > 1 && !IsVowel(word[word.Length - 2]))
            {
                // Change "y" to "ies" for words ending in "y" and the preceding letter is not a vowel
                return word.Substring(0, word.Length - 1) + "ies";
            }
            else
            {
                return word + "s"; // Add "s" for most other words
            }
        }
        /// <summary>
        /// статичний метод для перевірки чи є буква голосною
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsVowel(char c)
        {
            // Check if a character is a vowel (in this simple example, we consider 'y' as a consonant)
            return "AEIOUaeiou".IndexOf(c) != -1;
        }
    }
}
