﻿using TekuSP.Drivers.DriverBase.Enums;

namespace TekuSP.Drivers.DriverBase.Interfaces
{
    public interface IDriverBase
    {
        #region Public Properties

        /// <summary>
        /// Communication type driver was written for (I2C, SPI, etc)
        /// </summary>
        CommunicationType CommunicationType { get; }

        /// <summary>
        /// Device address on bus line
        /// </summary>
        int DeviceAddress { get; }

        /// <summary>
        /// Status of the device
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Name of the device
        /// </summary>
        string Name { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Read data from device, if not supported, calls <see cref="WriteData(byte[])"/> and returns -1
        /// </summary>
        /// <param name="pointer">Pointer where to read in device</param>
        /// <returns>Data from device or -1 if not supported</returns>
        long ReadData(byte pointer);

        /// <summary>
        /// Read data from device, if not supported, calls <see cref="WriteData(byte[])"/> and returns -1
        /// </summary>
        /// <param name="data">Data which to read from device</param>
        /// <returns>Lenght of data from device and fills <paramref name="data"/> with data or -1 if not supported</returns>
        long ReadData(byte[] data);

        /// <summary>
        /// Reads device ID from device
        /// </summary>
        /// <returns>Device ID</returns>
        string ReadDeviceId();

        /// <summary>
        /// Reads manufacturer from device
        /// </summary>
        /// <returns>Manufacturer ID</returns>
        string ReadManufacturerId();

        /// <summary>
        /// Reads serial number from device
        /// </summary>
        /// <returns>Serial Number</returns>
        string ReadSerialNumber();

        /// <summary>
        /// Restarts device driver
        /// </summary>
        void Restart();

        /// <summary>
        /// Starts device driver, this is required to call other methods <br/>
        /// To stop it use <see cref="Stop"/> <br/>
        /// To restart it use <see cref="Restart"/>
        /// </summary>
        void Start();

        /// <summary>
        /// Stops device driver and clears memory <br/>
        /// To start it use <see cref="Start"/>
        /// </summary>
        void Stop();

        /// <summary>
        /// Writes data to device, not expecting response
        /// </summary>
        /// <param name="data">Data to write</param>
        void WriteData(byte[] data);

        #endregion Public Methods
    }
}