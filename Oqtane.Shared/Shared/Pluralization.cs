using System.Text.RegularExpressions;

namespace Oqtane.Shared 
{
    public static class Pluralization 
    {
        public static string ReplaceModuleWithPlural(string input, string singular)
        {
            var regexPlural = new Regex(@"\[Module\]s");
            var regexSingular = new Regex(@"\[Module\]");
            var match = regexPlural.Match(input);
            return match.Success ? regexPlural.Replace(input, Pluralize(singular)) : regexSingular.Replace(input, singular);
        }

        public static string Pluralize(string singular)
        {
            return
                string.IsNullOrWhiteSpace(singular)
                    ? ""
                    : singular.EndsWith("y")
                        ? PluralizeY(singular)
                        : singular + "s";
        }

        private static string PluralizeY(string singular) 
        {
            return Regex.Replace(singular, @"y$", "ies");
        }

    }

}