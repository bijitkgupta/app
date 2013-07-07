using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class Person : ICreatable, IReadable, IUpdatable, IDeletable, HasID
    {
        private Person() { }
        public Person(DomainBase entity)
        {
            if (entity == null)
                throw new ArgumentNullException("DomainBase");
            ID = entity.ID;
        }

        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }

        public PersonTypeENUM PersonType_ENUM
        {
            get { return (PersonTypeENUM)Enum.Parse(typeof(PersonTypeENUM), PersonType, true); }
            set { PersonType = value.ToString(); }
        }
        public NameStyleENUM NameStyle_ENUM
        {
            get { return NameStyle ? NameStyleENUM.Eastern : NameStyleENUM.Western; }
            set { NameStyle = Convert.ToBoolean(value); }
        }
        public EmailPromotionENUM EmailPromotion_ENUM
        {
            get { return (EmailPromotionENUM)EmailPromotion; }
            set { EmailPromotion = (int)value; }
        }

        public int ID { get; set; }
    }
}