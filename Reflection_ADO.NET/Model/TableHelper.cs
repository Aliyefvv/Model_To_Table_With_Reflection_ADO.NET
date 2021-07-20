using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Reflection_ADO.NET.Model
{
    public class TableHelper
    {
        public TableHelper GenerateTable<T>(T table) where T : class
        {
            // Get Class Type
            var type = table.GetType();

            // Get Table Name
            string tableName = type.Name;

            // Make string for table properties
            List<StringBuilder> properties = new List<StringBuilder>();
            foreach (var prop in type.GetProperties())
            {
                StringBuilder str = new StringBuilder();
                str.Append(prop.Name);
                str.Append(" ");
                switch (prop.PropertyType.Name)
                {
                    case "String":
                        str.Append("NVARCHAR(100)");
                        break;
                    case "Int32":
                        str.Append("INT");
                        break;
                    case "Single":
                        str.Append("FLOAT(2)");
                        break;
                    case "SqlDateTime":
                        str.Append("DATETIME");
                        break;
                    default:
                        str.Append(prop.PropertyType.Name.ToUpper());
                        break;
                }
                str.Append(" NOT NULL");
                properties.Add(str);
            }

            // Database connection
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString))
            {
                con.Open();

                // SQL command for creating new table with properties
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = $"CREATE TABLE {tableName}s (\n" +
                    $"Id INT NOT NULL IDENTITY(1,1),\n" +
                    $"{ string.Join(",\n", properties)}" +
                    $"\n)";
                command.ExecuteNonQuery();

                return this;
            }
        }

        public TableHelper FillData<T>(List<T> datas) where T : class
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = con;

                //Get Table Name
                string tableName = datas[0].GetType().Name;

                // Get Data Type
                var type = datas[0].GetType();

                // List for inserting data (properties / values)
                List<string> properties = new List<string>();
                List<object> values = new List<object>();

                // Fill Propery list
                foreach (var t in type.GetProperties()) properties.Add(t.Name);

                // Fill Value list and execute command
                foreach (var data in datas)
                {
                    int i = 0;
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add("\'" + data.GetType().GetProperty(properties[i++]).GetValue(data) + "\'");
                    values.Add(data.GetType().GetProperty(properties[i++]).GetValue(data));

                    command.CommandText = $"INSERT INTO {tableName}s ({string.Join(",", properties)}) VALUES ({string.Join(",", values)})";
                    command.ExecuteNonQuery();
                    values.Clear();
                }

                return this;
            }
        }
    }
}
