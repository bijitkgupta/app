﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class CountryRegion : IReadable
    {
        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
    }
}
