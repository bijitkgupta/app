using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public enum PhoneNumberTypeENUM : int
    {
        Cell = 1,//Store Contact
        Home = 2,//Individual (retail) customer
        Work = 3,//Sales person
    }
}
