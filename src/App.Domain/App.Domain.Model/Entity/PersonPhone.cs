using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class PersonPhone : ICreatable, IReadable, IUpdatable, IDeletable
    {
        private PersonPhone() { }
        public PersonPhone(Person p, string pn, PhoneNumberType pnt)
        {
            Person = p;
            PhoneNumber = pn;
            PhoneNumberType = pnt;
        }

        public Person Person { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
