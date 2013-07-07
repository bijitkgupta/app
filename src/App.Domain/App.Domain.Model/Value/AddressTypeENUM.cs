using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public enum AddressTypeENUM : int
    {
        Archive = 1,//Store Contact
        Billing = 2,//Individual (retail) customer
        Home = 3,//Sales person
        MainOffice = 4,//Employee (non-sales)
        Primary = 5,//Vendor contact
        Shipping = 6,//General contact
    }
}
