﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Types {
    class LColour {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

        public LColour(Int32 _colour) {
            this.Red = (byte)(_colour & 0xFF);
            this.Green = (byte)((_colour >> 8) & 0xFF);
            this.Blue = (byte)((_colour >> 16) & 0xFF);
            this.Alpha = (byte)((_colour >> 24) & 0xFF);
        }
    }
}
