using Data;
using DataProviders.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DataProviders
{

    public class TxtProvider
    {
        IPathProvider _pathSettings;
        public TxtProvider(IPathProvider PathsSettings)
        {
            _pathSettings = PathsSettings;
        }

        public void DownloadFile()
        {
            CreateOrAddFolder();
            DeleteExistingFile();

            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(_pathSettings.Url, _pathSettings.PathFile);
            }
        }

        private void DeleteExistingFile()
        {
            if (string.IsNullOrEmpty(_pathSettings.PathFile))
            {
                File.Delete(_pathSettings.PathFile);
            }
        }

        private void CreateOrAddFolder()
        {
            if (!Directory.Exists(_pathSettings.Path))
            {
                Directory.CreateDirectory(_pathSettings.Path);
            }
        }

        private string ReadDataFromFile()
        {
            DownloadFile();

            using (StreamReader streamReader = new StreamReader(_pathSettings.PathFile))
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