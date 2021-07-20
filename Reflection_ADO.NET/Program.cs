using Reflection_ADO.NET.Model;
using Reflection_ADO.NET.Static_Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Reflection_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new TableHelper().GenerateTable(new Customer()).FillData(CustomerDataGenerator.GetData());
        }
    }
}
