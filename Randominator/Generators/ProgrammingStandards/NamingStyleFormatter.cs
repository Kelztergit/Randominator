﻿namespace TehGM.Randominator.Generators.ProgrammingStandards.Services
{
    public class NamingStyleFormatter : INamingStyleFormatter
    {
        private readonly IRandomizer _random;

        public NamingStyleFormatter(IRandomizer randomizer)
        {
            this._random = randomizer;
        }

        public string ApplyToWord(LetterCaseStyle style, string word, bool isLeading = false)
        {
            char[] chars = word.ToCharArray();
            switch (style)
            {
                case LetterCaseStyle.PascalCase:
                case LetterCaseStyle.PascalSnakeCase:
                case LetterCaseStyle.PascalKebabCase:
                case LetterCaseStyle.CamelCase when !isLeading:
                case LetterCaseStyle.CamelSnakeCase when !isLeading:
                    chars[0] = char.ToUpperInvariant(chars[0]);
                    return new string(chars);
                case LetterCaseStyle.FlatCase:
                case LetterCaseStyle.KebabCase:
                case LetterCaseStyle.SnakeCase:
                case LetterCaseStyle.CamelCase when isLeading:
                case LetterCaseStyle.CamelSnakeCase when isLeading:
                    return word.ToLowerInvariant();
                case LetterCaseStyle.UpperFlatCase:
                case LetterCaseStyle.ScreamingSnakeCase:
                case LetterCaseStyle.TrainCase:
                    return word.ToUpperInvariant();
                case LetterCaseStyle.PokemonCase:
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (i % 2 == 0)
                            chars[i] = char.ToUpperInvariant(chars[i]);
                        else
                            chars[i] = char.ToLowerInvariant(chars[i]);
                    }
                    return new string(chars);
                case LetterCaseStyle.RandomCase:
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (this._random.GetRandomBoolean())
                            chars[i] = char.ToUpperInvariant(chars[i]);
                        else
                            chars[i] = char.ToLowerInvariant(chars[i]);
                    }
                    return new string(chars);
            }
            return new string(chars);
        }

        public string MergeWords(LetterCaseStyle style, IEnumerable<string> words)
        {
            string separator = string.Empty;
            switch (style)
            {
                case LetterCaseStyle.SnakeCase:
                case LetterCaseStyle.ScreamingSnakeCase:
                case LetterCaseStyle.CamelSnakeCase:
                case LetterCaseStyle.PascalSnakeCase:
                    separator = "_";
                    break;
                case LetterCaseStyle.KebabCase:
                case LetterCaseStyle.TrainCase:
                case LetterCaseStyle.PascalKebabCase:
                    separator = "-";
                    break;
            }
            return string.Join(separator, words);
        }
    }
}
