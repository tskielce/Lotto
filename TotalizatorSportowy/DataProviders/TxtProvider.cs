using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DataProviders
{
    public class TxtProvider
    {
        Settings _settings;
        public TxtProvider(Settings settings)
        {
            _settings = settings;
        }

        public void DownloadFile()
        {
            CreateOrAddFolder();
            DeleteExistingFile();

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(_settings.url, _settings.pathFile);
            }
        }

        private void DeleteExistingFile()
        {
            if (string.IsNullOrEmpty(_settings.pathFile))
            {
                File.Delete(_settings.pathFile);
            }
        }

        private void CreateOrAddFolder()
        {
            if (!Directory.Exists(_settings.path))
            {
                Directory.CreateDirectory(_settings.path);
            }
        }

        private string ReadDataFromFile()
        {
            DownloadFile();

            using (StreamReader streamReader = new StreamReader(_settings.pathFile))
            {
                return streamReader.ReadToEnd();
            }
        }

        public DateTime ReplaceStringToDataTime(string dateTime)
        {
            var day = Convert.ToInt32(dateTime.Split('.')[0]);
            var month = Convert.ToInt32(dateTime.Split('.')[1]);
            var year = Convert.ToInt32(dateTime.Split('.')[2]);

            DateTime result = new DateTime(year, month, day, 0, 0, 0);

            return result;
        }

        public List<DataSchema> CollectionDataLotto()
        {
            var collectionDuzyLotek = new List<DataSchema>();
            List<int> tab = new List<int>();

            var Stream = ReadDataFromFile().Split('\n');

            foreach (var item in Stream)
            {
                if (item.ToString().IndexOf("\r") >= 0)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        tab.Add(Convert.ToInt32(item.Split(' ')[2].Split(',')[i]));
                    }

                    collectionDuzyLotek.Add(new DataSchema
                    {
                        id = Convert.ToInt32(item.Split('.')[0]),
                        LottoDate = ReplaceStringToDataTime(item.Split(' ')[1]),
                        numbers = tab
                    });
                    tab = new List<int>();
                }
            }

            return collectionDuzyLotek;
        }
    }
}