namespace Homework.Provider
{
    public interface IMediatorBase<T, R>
    {
        R ForwardData(T data, ProviderBase<T, R> colleague);
    }
}