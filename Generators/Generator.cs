using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{
    public abstract class Generator
    {
        public abstract IEnumerable<string> Generate(bool useUpperCase, bool useNumbers, bool useSymbols, int passwordLength, int passwordsListLength);
    }
}
