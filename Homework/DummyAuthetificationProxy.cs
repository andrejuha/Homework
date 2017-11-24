using System;

namespace Homework
{
    internal class DummyAuthetificationProxy
    {
        internal bool Authentificate(string UserName, string Password)
        {
            return true;
        }

        internal string GetStringFile(string path)
        {
            return "<Employees><title><ID> 1 </ID><FirstName>David</FirstName></title><text></text></Employees>";
        }

        internal void WriteStringFile(string path, string StringFile)
        {
           Console.Write (path+" file: "+StringFile);
        }
    }
}