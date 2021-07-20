using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_ADO.NET.Model
{
    public class Customer
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public SqlDateTime Birthdate { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
