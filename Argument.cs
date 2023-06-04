using System;

namespace CLIArgParser
{
    public class Argument
    {
        public string Name { get; }
        public string Value { get; set; } = string.Empty;
        public string HelpVerbose { get; }

        public Argument(string name, string helpVerbose = "")
        {
            Name = name;
            HelpVerbose = helpVerbose;
        }
    }
}
