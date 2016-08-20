using System;
using System.Collections.Generic;

namespace Fingear.Utils
{
    static public class EnumUtils
    {
        static public string GetDisplayName<T>(T enumValue)
        {
            return string.Join(" ", Enum.GetName(typeof(T), enumValue).Split(char.IsUpper));
        }

        static private IEnumerable<string> Split(this string value, Predicate<char> characterSelector)
        {
            string word = "";

            foreach (char c in value)
            {
                if (characterSelector(c) && string.IsNullOrEmpty(word))
                    yield return word;

                word += c;
            }

            yield return word;
        }
    }
}