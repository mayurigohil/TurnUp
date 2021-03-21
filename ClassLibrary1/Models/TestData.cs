using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
   public class TestData
    {
        public String Fname;
        public String Lname;
        public String Pname;
        public String Phone;
        public String Mobile;
        public String Email;
        public String Fax;
        public String Address;
        public String Street;
        public String City;
        public String Postcode;
        public String Country;
      

        public TestData(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10, string v11, string v12)
        {
            this.Fname = v1;
            this.Lname = v2;
            this.Pname = v3;
            this.Phone = v4;
            this.Mobile = v5;
            this.Email = v6;
            this.Fax = v7;
            this.Address = v8;
            this.Street = v9;
            this.City = v10;
            this.Postcode = v11;
            this.Country = v12;
        }
   }
}
