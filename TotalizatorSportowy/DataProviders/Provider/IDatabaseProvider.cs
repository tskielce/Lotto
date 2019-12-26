namespace DataProviders.Provider
{
    public interface IDatabaseProvider
    {
        string DatabaseName { get; }
        string SchemaName { get; }
        string TableName { get; }
    }
}
