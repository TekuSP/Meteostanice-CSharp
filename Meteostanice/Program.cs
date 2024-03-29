﻿using System.Diagnostics;
using System.Threading;

using TekuSP.Drivers.CST816D;

using nanoFramework.Hardware.Esp32;
using TekuSP.Drivers.TCS34725;

namespace Meteostanice
{
    public class Program
    {
        #region Public Methods

        public static void Main()
        {
            //Display TEST
            //Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
            //Configuration.SetPinFunction(19, DeviceFunction.SPI1_CLOCK);

            //SSD1331.SSD1331 display = new SSD1331.SSD1331(1, Gpio.IO32, Gpio.IO33, Gpio.IO27, GpioController.GetDefault());
            //display.Start();
            //display.DrawLine(0, 0, 50, 50, 255, 0, 0);

            //HDC1080 TEST
            //Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);
            //Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);

            //HDC1080.HDC1080 hDC1080 = new HDC1080.HDC1080(1);
            //hDC1080.Start();
            //var manu = hDC1080.ReadManufacturerId();
            //var serial = hDC1080.ReadSerialNumber();
            //var devID = hDC1080.ReadDeviceId();
            //var temperature = hDC1080.ReadTemperature();
            //hDC1080.HeatUp(10);
            //var humi = hDC1080.ReadHumidity();
            //MHZ19B TEST
            //Configuration.SetPinFunction(Gpio.IO16, DeviceFunction.COM3_RX);
            //Configuration.SetPinFunction(Gpio.IO17, DeviceFunction.COM3_TX);
            //MHZ19B.MHZ19B mhz = new MHZ19B.MHZ19B("COM3");
            //mhz.Start();
            //Debug.WriteLine("MHZ Started.");
            //while (true)
            //{
            //    int ppm = mhz.ReadCO2Concentration();
            //    Debug.WriteLine("Current limited ppm is: " + ppm);
            //    ppm = mhz.ReadCO2ConcentrationUnlimited();
            //    Debug.WriteLine("Current unlimited ppm is: " + ppm);
            //    int temp = mhz.ReadTemperature();
            //    Debug.WriteLine("Current temperature is: " + temp);
            //    Thread.Sleep(10000);
            //}

            //Configuration.SetPinFunction(Gpio.IO23, DeviceFunction.I2C1_CLOCK);
            //Configuration.SetPinFunction(Gpio.IO18, DeviceFunction.I2C1_DATA);
            //LPS22HB.LPS22HB lPS22HB = new LPS22HB.LPS22HB(1);
            //lPS22HB.Start();
            //var manu = lPS22HB.ReadManufacturerId();
            //var serial = lPS22HB.ReadSerialNumber();
            //var devID = lPS22HB.ReadDeviceId();
            //double temperature;
            //double pressure;
            //Debug.WriteLine($"Initialized device {manu} {devID} - {serial}");
            //while (true)
            //{
            //    temperature = lPS22HB.ReadTemperature(DriverBase.Enums.TemperatureUnit.Celsius);
            //    pressure = lPS22HB.ReadPressure(DriverBase.Enums.PressureType.mBar);
            //    Debug.WriteLine($"Temperature is: {temperature} C");
            //    Debug.WriteLine($"Pressure is: {pressure} mBar");
            //    Thread.Sleep(5000);
            //}
            //Configuration.SetPinFunction(40, DeviceFunction.I2C1_CLOCK);
            //Configuration.SetPinFunction(Gpio.IO39, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(Gpio.IO23, DeviceFunction.I2C1_CLOCK);
            Configuration.SetPinFunction(Gpio.IO18, DeviceFunction.I2C1_DATA);
            //ICM20948.ICM20948 icm = new ICM20948.ICM20948(1);
            //icm.Start();

            //while (true)
            //{
            //    icm.GyroscopeAccelerationRead(out int[] Accel, out int[] Gyro);
            //    icm.MagneticFieldRead(out int[] Mag);
            //    icm.UpdatePitchRollYaw(Accel, Gyro, Mag);
            //    Debug.WriteLine("/-------------------------------------------------------------/");
            //    Debug.WriteLine(string.Format("Roll = {0} , Pitch = {1} , Yaw = {2}", icm.Roll, icm.Pitch, icm.Yaw));
            //    Debug.WriteLine(string.Format("Acceleration:  X = {0} , Y = {1} , Z = {2}", Accel[0], Accel[1], Accel[2]));
            //    Debug.WriteLine(string.Format("Gyroscope:     X = {0} , Y = {1} , Z = {2}", Gyro[0], Gyro[1], Gyro[2]));
            //    Debug.WriteLine(string.Format("Magnetic:      X = {0} , Y = {1} , Z = {2}", Mag[0], Mag[1], Mag[2]));
            //    Thread.Sleep(1000);
            //}
            //SHTC3.SHTC3 sHTC3 = new SHTC3.SHTC3(1);
            //sHTC3.Start();
            //Debug.WriteLine($"Device {sHTC3.ReadManufacturerId()} {sHTC3.ReadDeviceId()} - {sHTC3.ReadSerialNumber()}");
            //while (true)
            //{
            //    Debug.WriteLine($"Temperature is: {sHTC3.ReadTemperature(DriverBase.Enums.TemperatureUnit.Celsius)} C");
            //    Debug.WriteLine($"Humidity is: {sHTC3.ReadHumidity(DriverBase.Enums.HumidityType.Relative)} %");
            //    Thread.Sleep(5000);
            //}
            //CST816D.CST816D cst = new CST816D.CST816D(1, 41, 42);
            //cst.OnStateChanged += (sender, args) =>
            //{
            //    Debug.WriteLine($"Action: {args.Gesture}");
            //    Debug.WriteLine($"X: {args.X}");
            //    Debug.WriteLine($"Y: {args.Y}");
            //    Debug.WriteLine($"Pressure: {args.TouchPressure}");
            //};
            //cst.Start();
            //Debug.WriteLine("Version: " + cst.ReadVersion());
            //Debug.WriteLine("Version info: " + cst.ReadVersionInfo());
            TCS34725 colorSensor = new TCS34725(1, TekuSP.Drivers.TCS34725.Enums.IntegrationTime.TCS34725_INTEGRATIONTIME_101MS, TekuSP.Drivers.TCS34725.Enums.Gain.TCS34725_GAIN_4X);
            colorSensor.Start();
            Debug.WriteLine(colorSensor.ReadDeviceId());
            while (true)
            {
                var colors = colorSensor.GetRGB();
                var kelvin = colorSensor.GetColorTemperature();
                var lux = colorSensor.GetLux();
                Debug.WriteLine($"Colors, R: {colors.R} G: {colors.G} B: {colors.B}");
                Debug.WriteLine($"Kelvins: {kelvin}");
                Debug.WriteLine($"Lux: {lux}");
                Thread.Sleep(1000);
            }
        }

        #endregion Public Methods
    }
}