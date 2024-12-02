using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakmaERP
{
    /// <summary>
    /// Create-Read-Update-Delete operations for database.
    /// </summary>
    public class CRUD
    {
        private static readonly string connectionString = "Data Source=...;Initial Catalog=...;Integrated Security=True";

        public static void Create(string tableName, Dictionary<string, object> data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string columns = string.Join(", ", data.Keys);
                string parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var item in data)
                    {
                        command.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable Read(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void Update(string tableName, Dictionary<string, object> data, string condition)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {condition}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var item in data)
                    {
                        command.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string tableName, string condition)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM {tableName} WHERE {condition}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
