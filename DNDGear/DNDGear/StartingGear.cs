﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    public interface IStartingGear<Gear>
    {
        List<Gear> startGear { get; set; }
    }
}
