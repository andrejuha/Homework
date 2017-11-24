namespace Homework.Interfaces
{
    public interface ICloudReaderProvider
    {
        string ForwardData(string data);
        string ProcessData(string data);
        void Read();
    }
}