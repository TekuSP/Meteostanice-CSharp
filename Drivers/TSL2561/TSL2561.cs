﻿using DriverBase;
using DriverBase.Enums;
using DriverBase.Helpers;
using System.Device.I2c;

namespace TSL2561
{
    public class TSL2561 : DriverBaseI2C
    {
        #region Public Constructors

        public TSL2561(int I2CBusID, int deviceAddress = 0x39) : base("TSL2561", I2CBusID, deviceAddress)
        {
        }

        public TSL2561(int I2CBusID, I2cConnectionSettings connectionSettings, int deviceAddress = 0x39) : base("TSL2561", I2CBusID, connectionSettings, deviceAddress)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override long ReadData(byte pointer)
        {
            byte[] result = new byte[1];
            I2CDevice.WriteRead(new byte[] { (byte)((pointer & 0x0F) | 0x80) }, result);
            return result[0];
        }

        public override long ReadData(params byte[] data)
        {
            byte[] result = new byte[1];
            I2CDevice.WriteRead(data, result);
            return result[0];
        }

        public override string ReadDeviceId()
        {
            return ReadData(0x0A).ToString();
        }

        public override string ReadManufacturerId()
        {
            return "Not supported";
        }

        public long ReadResultData(byte pointer)
        {
            byte[] result = new byte[2];
            I2CDevice.WriteRead(new byte[] { (byte)((pointer & 0x0F) | 0x80) }, result);
            return ((uint)result[0]).LowWord().HighWord(result[1]);
        }

        public override string ReadSerialNumber()
        {
            return "Not supported";
        }

        public override void WriteData(params byte[] data)
        {
            data[0] = (byte)((data[0] & 0x0F) | 0x80);
            I2CDevice.Write(data);
        }

        #endregion Public Methods
    }
}