using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace POC
{
    public class Builder
    {
        public List<T> Build<T>(string query)
        {
            List<T> objects = new List<T>();

            using (var connection = new SqlConnection("context connection=true"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                //Get the current SQL Server instance name
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        objects.Add((T)Activator.CreateInstance(typeof(T), reader));
                    }
                }

                connection.Close();
            }

            return objects;
        }
    }
}
