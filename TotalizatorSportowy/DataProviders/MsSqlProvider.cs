using Data;
using DataProviders.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataProviders
{
    public class MsSqlProvider
    {
        public void InsertDataFromCollection(List<DataSchema> list, IConnectionStringProvider connectionStringProvider, IDatabaseProvider databaseProvider)
        {
            var query = new Query(databaseProvider);

            using (SqlConnection connection = new SqlConnection(connectionStringProvider.ConnectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query.TruncateDataFromTable(),connection);
                sqlCommand.ExecuteNonQuery();

                foreach (var item in list)
                {
                    sqlCommand = new SqlCommand(query.InserQuery(item), connection);
                    sqlCommand.ExecuteNonQuery();
                }
                

                sqlCommand = new SqlCommand(query.MergeData() , connection);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
