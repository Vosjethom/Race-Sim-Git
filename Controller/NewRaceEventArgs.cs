﻿using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NewRaceEventArgs : EventArgs
    {
        public NewRaceEventArgs()
        {
            Data.NextRace();
        }
    }
}
