using System.Text.RegularExpressions;
using Humanizer;

namespace Oqtane.Shared
{
    public static class Pluralization
    {
        public static string ReplaceModuleWithPlural(string input, string singular)
        {
            var regexPlural = new Regex(@"\[Module\]s");
            var regexSingular = new Regex(@"\[Module\]");

            var matchPlural = regexPlural.Match(input);
            input =
                matchPlural.Success
                    ? regexPlural.Replace(input, Pluralize(singular))
                    : input;

            var matchSingular = regexSingular.Match(input);
            input =
                matchSingular.Success
                    ? regexSingular.Replace(input, singular)
                    : input;

            return input;
        }

        public static string Pluralize(string singular)
        {
            return string.IsNullOrWhiteSpace(singular) ? string.Empty : singular.Pluralize();
        }
    }

}