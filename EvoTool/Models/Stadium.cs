﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Stadium
    {

        public Stadium(ushort ID)
        {
            this.ID = ID;
        }

        public ushort ID { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public ushort Country { get; set; }
        public ushort Capacity { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
