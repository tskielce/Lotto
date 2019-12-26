using Data;
using DataProviders;
using System;
using System.Configuration;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = ReadAllSettings();

            TxtProvider txtProvider = new TxtProvider(settings);
            MsSqlProvider msSqlProvider = new MsSqlProvider();

            var listData = txtProvider.CollectionDataLotto();

            try
            {
                msSqlProvider.InsertDataFromCollection(listData, settings, settings);

                Console.WriteLine("\nDownload data  - Duzy Lotek - success\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static Settings ReadAllSettings()
        {
            Settings settings = new Settings();

            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    settings = new Settings(
                        appSettings.Get("path"),
                        appSettings.Get("url"),
                        appSettings.Get("fileName"),
                        ConfigurationManager.ConnectionStrings["mssql"].ConnectionString,
                        appSettings.Get("db"),
                        appSettings.Get("table"),
                        appSettings.Get("schema")
                    );
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return settings;
        }
    }
}
