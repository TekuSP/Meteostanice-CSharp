﻿namespace ESP32_DriverBase.Helpers
{
    public static class BitHelper
    {
        #region Public Methods

        public static bool GetBit(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber - 1)) != 0;
        }

        public static byte SetBit(this byte b, int pos, bool value)
        {
            if (value)
                return (byte)(b | (1 << pos));
            return (byte)(b & ~(1 << pos));
        }

        #endregion Public Methods
    }
}