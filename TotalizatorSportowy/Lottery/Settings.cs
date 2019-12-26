using DataProviders;
using DataProviders.Provider;

namespace Data
{
    public class Settings : IPathProvider, IConnectionStringProvider, IDatabaseProvider
    {
        public string Path { get; private set; }
        public string Url { get; private set; }
        public string FileName { get; private set; }
        public string PathFile { get; private set; }
        public string ConnectionString { get; private set; }

        public string DatabaseName { get; private set; }
        public string SchemaName { get; private set; }
        public string TableName { get; private set; }

        public Settings(string Path, string Url, string FileName, string ConnectionString, string DatabaseName, string TableName, string SchemaName)
        {
            this.Path = Path;
            this.Url = Url;
            this.FileName = FileName;
            this.ConnectionString = ConnectionString;
            PathFile = Path + "\\" + FileName;

            this.TableName = TableName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
        }

        public Settings()
        {
        }
    }
}