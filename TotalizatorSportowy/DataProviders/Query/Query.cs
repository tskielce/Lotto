using DataProviders.Provider;

namespace Data
{
    public class Query
    {
        private string _databaseName;
        private string _schemaName;
        private string _tableName;

        public Query(IDatabaseProvider databaseProvider)
        {
            _databaseName = databaseProvider.DatabaseName;
            _schemaName = databaseProvider.SchemaName;
            _tableName = databaseProvider.TableName;
        }

        public string InserQuery(DataSchema item)
        {
            return $"INSERT INTO {_databaseName}.{_schemaName}.{_tableName} (id, LottoDate, nr1, nr2, nr3, nr4, nr5, nr6)" +
                $"VALUES ({item.id},'{item.LottoDate.ToString("yyyy-MM-dd HH:mm:ss")}',{item.numbers[0]},{item.numbers[1]},{item.numbers[2]},{item.numbers[3]},{item.numbers[4]},{item.numbers[5]})";
        }

        public string TruncateDataFromTable()
        {
            return $"TRUNCATE TABLE {_databaseName}.{_schemaName}.{_tableName}";
        }

        public string MergeData()
        {
            return $"merge dbo." + _tableName + " as tgt " +
"USING temp." + _tableName + " AS src " +
"ON tgt.id = src.id " +
"WHEN NOT MATCHED THEN " +
"INSERT(id, LottoDate, nr1, nr2, nr3, nr4, nr5, nr6, T_UpdateDT) " +
"VALUES(src.id, src.LottoDate, src.nr1, src.nr2, src.nr3, src.nr4, src.nr5, src.nr6, getdate()); ";
        }
    }
}
