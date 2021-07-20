using Reflection_ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_ADO.NET.Static_Classes
{
    public static class CustomerDataGenerator
    {
        public static List<Customer> GetData()
        {
            return new List<Customer>
            {
                new Customer()
                {
                    FisrtName = "Ali",
                    LastName = "Aliyev",
                    Phone = "+994552511068",
                    Email = "a.aliyev0205@gmail.com",
                    Birthdate = new System.Data.SqlTypes.SqlDateTime(1999,12,12),
                    City = "Sumqayit",
                    ZipCode = 5001
                },

                new Customer()
                {
                    FisrtName = "Resul",
                    LastName = "Osmanli",
                    Phone = "+994777476666",
                    Email = "o.resul01@gmail.com",
                    Birthdate = new System.Data.SqlTypes.SqlDateTime(1999,12,12),
                    City = "Baku",
                    ZipCode = 5002
                }
            };
        }
    }
}
