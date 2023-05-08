using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLCC.Services.Helpers
{
    public class UpperUnderscoreNamingConvention : INamingConvention
    {
        public Regex SplittingExpression { get; } = new Regex(@"[\p{Lu}0-9]+(?=_?)");

        public string SeparatorCharacter { get { return "_"; } }

        public string ReplaceValue(Match match) => match.Value[0].ToString().ToUpper() + match.Value.Substring(1);


        public string[] Split(string input)
        {
            return input.Split('_', StringSplitOptions.RemoveEmptyEntries);
        }
        public static readonly UpperUnderscoreNamingConvention Instance = new();

    }
}
