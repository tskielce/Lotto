namespace DataProviders
{
    public interface IPathsProvider
    {
        string PathFile { get; }
        string Url { get; }
        string Path { get; }

    }
}