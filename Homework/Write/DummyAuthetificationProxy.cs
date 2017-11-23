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
            return "dummy text from  DummyAuthetificationProxy.GetStringFile";
        }

        internal void WriteStringFile(string path, string StringFile)
        {
           Console.Write (path+" file: "+StringFile);
        }
    }
}