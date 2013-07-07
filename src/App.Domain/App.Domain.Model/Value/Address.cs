using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class Address : ICreatable, IReadable, IDeletable, HasID
    {
        private Address() { }
        public Address(StateProvince sp)
        {
            if (sp == null)
                throw new ArgumentNullException("StateProvince");

            StateProvince = sp;
        }
        public Address(string addr1, string city, StateProvince sp, string pc)
        {
            if (sp == null)
                throw new ArgumentNullException("StateProvince");

            AddressLine1 = addr1;
            City = city;
            StateProvince = sp;
            PostalCode = pc;
            AddressLine2 = null;
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public StateProvince  StateProvince { get; set; }
        public string PostalCode { get; set; }

        public int ID { get; set; }
    }
}
