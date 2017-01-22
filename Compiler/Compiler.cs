using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Compiler
{
    public class Compiler
    {
        public byte[] BuildProject(string projectPath)
        {
            Thread.Sleep(5000);
            return Encoding.UTF8.GetBytes(projectPath);
        }
    }
}
