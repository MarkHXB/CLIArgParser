using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLIArgParser
{
    public interface IParser
    {
        IList<Argument> Arguments { get; }
        void TryToParse();
        Task TryToParseAsync();
    }
}
