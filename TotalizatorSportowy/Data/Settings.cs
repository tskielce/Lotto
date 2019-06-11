namespace Data
{
    public class Settings
    {
        public string path { get; set; }
        public string url { get; set; }
        public string fileName { get; set; }
        public string pathFile { get; set; }
        public string connectionString { get; set; }

        public Settings(string path, string url, string fileName, string connectionString)
        {
            this.path = path;
            this.url = url;
            this.fileName = fileName;
            this.connectionString = connectionString;
            pathFile = path + "\\" + fileName;
        }

        public Settings()
        {
        }
    }
}