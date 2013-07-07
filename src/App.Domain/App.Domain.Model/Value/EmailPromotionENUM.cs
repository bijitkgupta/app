using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public enum EmailPromotionENUM : int
    {
        Strict = 0,//Contact does not wish to receive e-mail promotions
        Medium = 1,//Contact does wish to receive e-mail promotions from AdventureWorks
        Loose = 2,//Contact does wish to receive e-mail promotions from AdventureWorks and selected partners
    }
}
