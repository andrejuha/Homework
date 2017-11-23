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
    }
}