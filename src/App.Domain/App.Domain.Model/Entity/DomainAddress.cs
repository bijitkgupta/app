using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class DomainAddress : ICreatable, IReadable, IUpdatable, IDeletable
    {
        private DomainAddress() { }
        public DomainAddress(int domainId, Address address, AddressType addressType)
        {
            BusinessEntityID = domainId;
            Address = address;
            AddressType = addressType;
        }

        public int BusinessEntityID { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
    }
}