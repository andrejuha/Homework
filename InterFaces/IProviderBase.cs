namespace Homework.Interfaces
{
   public interface IProviderBase<T, R>
    {
        R ForwardData(T data);

        R ProcessData(T data);
    }
}