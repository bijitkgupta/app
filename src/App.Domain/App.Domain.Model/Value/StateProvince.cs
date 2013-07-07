using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class StateProvince : IReadable, HasID
    {
        private StateProvince() { }
        public StateProvince(CountryRegion cr)
        {
            if (cr == null)
                throw new ArgumentNullException("CountryRegion");

            CountryRegion = cr;
        }
        public StateProvince(string spCode, CountryRegion cr, bool onlyState, string name)
        {
            if (cr == null)
                throw new ArgumentNullException("CountryRegion");
            if (string.IsNullOrWhiteSpace(spCode))
                throw new ArgumentNullException("StateProvinceCode");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name");

            StateProvinceCode = spCode;
            CountryRegion = cr;
            IsOnlyStateProvinceFlag = onlyState;
            Name = name;
        }

        public string StateProvinceCode { get; set; }
        public CountryRegion CountryRegion { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }

        public int ID { get; set; }
    }
}
