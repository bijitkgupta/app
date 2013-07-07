using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class PersonEmail : ICreatable, IReadable, IUpdatable, IDeletable, HasID
    {
        private PersonEmail() { }
        public PersonEmail(Person p, string ea)
        {
            Person = p;
            EmailAddress = ea;
        }

        public Person Person { get; set; }
        public string EmailAddress { get; set; }

        public int ID { get; set; }
    }
}
