using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class ContactPerson : ICreatable, IReadable, IUpdatable, IDeletable
    {
        public ContactPerson(Person p, ContactType ct)
        {
            Person = p;
            ContactType = ct;
        }

        public Person Person { get; set; }
        public ContactType ContactType { get; set; }
    }
}
