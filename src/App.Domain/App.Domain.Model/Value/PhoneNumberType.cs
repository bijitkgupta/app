﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Model
{
    public class PhoneNumberType : IReadable, HasID
    {
        public string Name { get; set; }

        public int ID { get; set; }
    }
}
