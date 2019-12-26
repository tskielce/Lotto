namespace DataProviders.Provider
{
    public interface IPathProvider
    {
        string PathFile { get; }
        string Url { get; }
        string Path { get; }
    }
}