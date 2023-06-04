using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIArgParser
{
    public class Parser : IParser
    {
        private readonly string[] _args = Array.Empty<string>();
        public IList<Argument> Arguments { get; }

        public Parser(string[] args, IList<Argument> options) : this(args, options, raiseException: true) { }
        public Parser(string[] args, IList<Argument> options, bool raiseException)
        {
            _args = args ?? Array.Empty<string>();
            Arguments = options ?? Array.Empty<Argument>();

            if (raiseException && _args.Length == 0)
            {
                throw new ArgumentNullException(nameof(args));
            }
            if (raiseException && Arguments.Count == 0)
            {
                throw new ArgumentNullException(nameof(args));
            }
        }

        public void TryToParse()
        {
            string name = string.Empty;
            string value = string.Empty;

            for (int i = 0; i < _args.Length;  i++)
            {
                if (i % 2 == 0)
                {
                    name = _args[i].Trim();
                }
                else if (i % 2 != 0)
                {
                    value = _args[i].Trim();
                }

                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(value))
                {
                    ResolveValue(name, value);

                    name = string.Empty;
                    value = string.Empty;
                }
            }
        }
        public async Task TryToParseAsync()
        {
            await Task.Run(() => TryToParse());
        }

        private void ResolveValue(string name, string value)
        {
            var argument = Arguments.FirstOrDefault(x => x.Name == name) ?? throw new ArgumentOutOfRangeException($"{name} not found in arguments.");   

            argument.Value = value;
        }
    }
}
