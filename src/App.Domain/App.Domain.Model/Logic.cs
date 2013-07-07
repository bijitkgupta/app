using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class Logic
    {
        public IRepository Repository { get; private set; }
        public Logic(IRepository rep)
        {
            if (rep == null)
                throw new ArgumentNullException("repository");
            Repository = rep;
        }
        public IEnumerable<KeyValuePair<NameStyleENUM, string>> NameStyles
        {
            get
            {
                return Enum.GetValues(typeof(NameStyleENUM)).Cast<NameStyleENUM>().Select(n => new KeyValuePair<NameStyleENUM, string>(n, n.ToString()));
            }
        }
        public IEnumerable<KeyValuePair<EmailPromotionENUM, string>> EmailPromotions
        {
            get
            {
                return Enum.GetValues(typeof(EmailPromotionENUM)).Cast<EmailPromotionENUM>().Select(n => new KeyValuePair<EmailPromotionENUM, string>(n, n.ToString()));
            }
        }
        public IEnumerable<KeyValuePair<PersonTypeENUM, string>> PersonTypes
        {
            get
            {
                return Enum.GetValues(typeof(PersonTypeENUM)).Cast<PersonTypeENUM>().Select(n => new KeyValuePair<PersonTypeENUM, string>(n, n.ToString()));
            }
        }

        public IEnumerable<Address> GetAddresses(string type, string domainId)
        {
            string[] children = { "Address" };
            AddressTypeENUM at;
            int did;
            if (Enum.TryParse<AddressTypeENUM>(type, true, out at))
            {
                if (Int32.TryParse(domainId, out did))
                {
                    return Repository.Read<DomainAddress>(da => da.BusinessEntityID == did && da.AddressType.ID == (int)at, children).Select(da => da.Address);
                }
                return Repository.Read<DomainAddress>(da => da.AddressType.ID == (int)at, children).Select(da => da.Address);
            }
            else if (Int32.TryParse(domainId, out did))
            {
                return Repository.Read<DomainAddress>(da => da.BusinessEntityID == did, children).Select(da => da.Address);
            }
            else
                return Repository.Read<Address>();
        }

        public IEnumerable<string> GetPhoneNumbers(string type, string personId)
        {
            PhoneNumberTypeENUM pnt;
            int pid;
            if (Enum.TryParse<PhoneNumberTypeENUM>(type, true, out pnt))
            {
                if (Int32.TryParse(personId, out pid))
                {
                    return Repository.Read<PersonPhone>(pp => pp.Person.ID == pid && pp.PhoneNumberType.ID == (int)pnt).Select(pp => pp.PhoneNumber);
                }
                return Repository.Read<PersonPhone>(pp => pp.PhoneNumberType.ID == (int)pnt).Select(pp => pp.PhoneNumber);
            }
            else if (Int32.TryParse(personId, out pid))
            {
                return Repository.Read<PersonPhone>(pp => pp.Person.ID == pid).Select(pp => pp.PhoneNumber);
            }
            else
                return Repository.Read<PersonPhone>().Select(pp => pp.PhoneNumber);
        }

        public IEnumerable<string> GetEmails(string personId)
        {
            int pid;
            if (Int32.TryParse(personId, out pid))
            {
                return Repository.Read<PersonEmail>(pp => pp.Person.ID == pid).Select(pp => pp.EmailAddress);
            }
            else
                return Repository.Read<PersonEmail>().Select(pp => pp.EmailAddress);
        }
    }
}
