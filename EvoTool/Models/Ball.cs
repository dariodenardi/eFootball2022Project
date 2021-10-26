﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvoTool.Models
{
    public class Ball
    {
        public Ball(ushort ID)
        {
            this.ID = ID;
        }

        public ushort ID { get; set;  }
        public byte Order { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
