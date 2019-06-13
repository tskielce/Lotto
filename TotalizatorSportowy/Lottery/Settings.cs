using DataProviders;

namespace Data
{
    public class Settings : IPathsProvider, IConnectionStringProvider
    {
        public string Path { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string PathFile { get; set; }
        public string ConnectionString { get; set; }

        public Settings(string path, string url, string fileName, string connectionString)
        {
            Path = path;
            Url = url;
            FileName = fileName;
            ConnectionString = connectionString;
            PathFile = path + "\\" + fileName;
        }

        public Settings()
        {
        }
    }
}