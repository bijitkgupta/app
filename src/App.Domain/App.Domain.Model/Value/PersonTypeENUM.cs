using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public enum PersonTypeENUM
    {
        SC = 0,//Store Contact
        IN = 1,//Individual (retail) customer
        SP = 2,//Sales person
        EM = 3,//Employee (non-sales)
        VC = 4,//Vendor contact
        GC = 5,//General contact
    }
}
