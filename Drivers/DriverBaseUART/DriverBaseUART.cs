﻿using TekuSP.Drivers.DriverBase.Enums;
using TekuSP.Drivers.DriverBase.Interfaces;

using System.IO.Ports;

namespace TekuSP.Drivers.DriverBase
{
    /// <summary>
    /// Base driver for UART (Serial) devices
    /// </summary>
    public abstract class DriverBaseUART : IDriverBase
    {
        #region Protected Fields

        protected string serialBusID;
        protected SerialPort serialDevice;

        #endregion Protected Fields

        #region Public Constructors

        /// <summary>
        /// Constructs Serial Driver, but does not start it, call <see cref="Start"/> for starting it
        /// </summary>
        /// <param name="name">Name of the device</param>
        /// <param name="serialBusID">Serial Bus ID <see cref="SerialDevice.GetDeviceSelector"/></param>
        public DriverBaseUART(string name, string serialBusID)
        {
            this.serialBusID = serialBusID;
            Name = name;
            CommunicationType = CommunicationType.Serial;
        }

        #endregion Public Constructors

        #region Public Properties

        public virtual CommunicationType CommunicationType { get; }

        /// <summary>
        /// Serial Devices do not have address
        /// </summary>
        public virtual int DeviceAddress => -1;

        public virtual bool IsRunning => serialDevice != null;
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
            if (serialDevice != null)
                return; //We are already running
            serialDevice = new SerialPort(serialBusID);
        }

        public virtual void Stop()
        {
            serialDevice?.Dispose();
            serialDevice = null;
        }

        public abstract void WriteData(byte[] data);

        #endregion Public Methods
    }
}