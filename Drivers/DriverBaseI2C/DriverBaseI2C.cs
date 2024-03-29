﻿using TekuSP.Drivers.DriverBase.Enums;
using TekuSP.Drivers.DriverBase.Interfaces;
using System.Device.I2c;

namespace TekuSP.Drivers.DriverBase
{
    /// <summary>
    /// Base driver class for I2C devices
    /// </summary>
    public abstract class DriverBaseI2C : IDriverBase
    {
        #region Protected Fields

        protected I2cConnectionSettings I2CConnectionSettings;
        protected I2cDevice I2CDevice;

        #endregion Protected Fields

        #region Public Constructors

        /// <summary>
        /// Constructs I2C Driver, but does not start it, call <see cref="Start"/> for starting it
        /// </summary>
        /// <param name="name">Name of the device</param>
        /// <param name="I2CBusID">I2C Bus ID</param>
        /// <param name="deviceAddress">I2C Device Address</param>
        public DriverBaseI2C(string name, int I2CBusID, int deviceAddress)
        {
            Name = name;
            CommunicationType = CommunicationType.I2C;
            DeviceAddress = deviceAddress;
            I2CConnectionSettings = new I2cConnectionSettings(I2CBusID, deviceAddress, I2cBusSpeed.FastMode);
        }

        /// <summary>
        /// Constructs I2C Driver, but does not start it, call <see cref="Start"/> for starting it
        /// </summary>
        /// <param name="name">Name of the device</param>
        /// <param name="I2CBusID">I2C Bus ID</param>
        /// <param name="connectionSettings">I2C Custom connection settings</param>
        /// <param name="deviceAddress">I2C Device Address</param>
        public DriverBaseI2C(string name, int I2CBusID, I2cConnectionSettings connectionSettings, int deviceAddress)
        {
            Name = name;
            CommunicationType = CommunicationType.I2C;
            DeviceAddress = deviceAddress;
            I2CConnectionSettings = connectionSettings;
        }

        #endregion Public Constructors

        #region Public Properties

        public virtual CommunicationType CommunicationType { get; }
        public virtual int DeviceAddress { get; }
        public virtual bool IsRunning => I2CDevice != null;
        public virtual string Name { get; }

        #endregion Public Properties

        #region Public Methods

        public abstract long ReadData(byte pointer);

        public abstract long ReadData(byte[] data);

        public abstract string ReadDeviceId();

        public abstract string ReadManufacturerId();

        public abstract string ReadSerialNumber();

        public virtual void Restart()
        {
            Stop();
            Start();
        }

        public virtual void Start()
        {
            if (I2CDevice != null)
                return; //We are already running
            I2CDevice = new I2cDevice(I2CConnectionSettings);
        }

        public virtual void Stop()
        {
            I2CDevice?.Dispose();
            I2CDevice = null;
        }

        public abstract void WriteData(byte[] data);

        #endregion Public Methods
    }
}