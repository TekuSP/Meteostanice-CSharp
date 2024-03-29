﻿using TekuSP.Drivers.DriverBase.Interfaces;

namespace TekuSP.Drivers.TCS34725
{
    public class CRGBData : IColorData
    {
        public float C {  get; set; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
    }
}
