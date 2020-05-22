using System.Text.RegularExpressions;

namespace Oqtane.Shared 
{
    public static class Pluralization 
    {
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