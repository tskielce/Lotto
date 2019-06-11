using Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataProviders
{
    public class MsSqlProvider
    {
        public void InsertDataFromCollection(List<DataSchema> list, Settings settings)
        {
            Query queries = new Query();

            using (SqlConnection connection = new SqlConnection(settings.connectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(queries.TruncateDataFromTable(),connection);
                sqlCommand.ExecuteNonQuery();

                foreach (var item in list)
                {
                    sqlCommand = new SqlCommand(queries.InserQuery(item), connection);
                    sqlCommand.ExecuteNonQuery();
                }
                

                sqlCommand = new SqlCommand(queries.MergeData() , connection);
                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }
    }

}
