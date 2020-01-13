using System;

namespace DataProviders
{
    public interface ITxtProvider
    {
        DateTime ReplaceStringToDataTime(string dateTime);
    }
}