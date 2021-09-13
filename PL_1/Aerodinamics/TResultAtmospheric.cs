//Результат интерполяции по данным
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//****************************************************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// Результат интерполяции по данным
    /// </summary>
    public class TResultAtmospheric
    {
        /// <summary>
        /// Получение атмосферных характеристик по высоте
        /// </summary>
        /// <param name="Height">Высота</param>
        /// <returns>1.температура 2.скорость звука 3.давление 4.динамическая вязкость 5.высота</returns>
        public static double[] GetAtmosphericCaracteristicFromHight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] PressureData = TDatabaseAtmospheric.Pressure;
            double[] SpeedOfSound = TDatabaseAtmospheric.SpeedOfSound;
            double[] TemperatureCelsius = TDatabaseAtmospheric.TemperatureOfCelsius;
            double[] AirKinematicalViscosityData = TDatabaseAtmospheric.AirKinematicalViscosity;
            int CountX = TDatabaseAtmospheric.CountX;
            double[] Result = new double[5];
            Result[0] = TLinearyInterpolation.Interpolate(TemperatureCelsius, AttitudeData, CountX, Height);
            Result[1] = TLinearyInterpolation.Interpolate(SpeedOfSound, AttitudeData, CountX, Height);
            Result[2] = TLinearyInterpolation.Interpolate(PressureData, AttitudeData, CountX, Height);
            Result[3] = TLinearyInterpolation.Interpolate(AirKinematicalViscosityData, AttitudeData, CountX, Height);
            Result[4] = Height;
            return Result;
        }
        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Получить давление по высоте со стандатными условиями
        /// </summary>
        /// <param name="Height">Высота (кг/м2)</param>
        /// <returns>Высота (м)</returns>
        public static double GetPressureFromHeight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] PressureData = TDatabaseAtmospheric.Pressure;
            int CountX = TDatabaseAtmospheric.CountX;
            double PressureFromDensity = TLinearyInterpolation.Interpolate(PressureData, AttitudeData, CountX, Height);
            return PressureFromDensity;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить высоту по плотности со стандартными условиями
        /// </summary>
        /// <param name="Density">Плотность (кг/м2)</param>
        /// <returns>Высота (м)</returns>
        public static double GetHeightFromDensity(double Density)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] DensityData = TDatabaseAtmospheric.Density;
            int CountX = TDatabaseAtmospheric.CountX;
            double HeightFromDensity = TLinearyInterpolation.Interpolate(DensityData, AttitudeData, CountX, Density);
            return HeightFromDensity;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить плотность от высоты
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Плотность (кг/м2)</returns>
        public static double GetAirDensityFromHeight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] DensityData = TDatabaseAtmospheric.Density;
            int CountX = TDatabaseAtmospheric.CountX;
            double DensityFromHeight = TLinearyInterpolation.Interpolate(AttitudeData, DensityData, CountX, Height);
            return DensityFromHeight;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить температуру в цельсиях за бортом от высоты для МСА
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Температура (град Цельсия)</returns>
        public static double GetAirTemperatureFromHeightCelsius(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] TemperatureCelsius = TDatabaseAtmospheric.TemperatureOfCelsius;
            int CountX = TDatabaseAtmospheric.CountX;
            double TemperatureFromHeightCelsius = TLinearyInterpolation.Interpolate(AttitudeData, TemperatureCelsius, CountX, Height);
            return TemperatureFromHeightCelsius;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить температуру в Кельвинах за бортом от высоты для МСА
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Температура (град Цельсия)</returns>
        public static double GetAirTemperatureFromHeightKelvin(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] TemperatureKelvin = TDatabaseAtmospheric.TemperatureOfKelvin;
            int CountX = TDatabaseAtmospheric.CountX;
            double TemperatureFromHeightKelvin = TLinearyInterpolation.Interpolate(AttitudeData, TemperatureKelvin, CountX, Height);
            return TemperatureFromHeightKelvin;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить высоту по температуре в цельсиях за бортом для МСА
        /// </summary>
        /// <param name="Temperature">Температура (град Цельсия)x</param>
        /// <returns>Температура (град Цельсия)</returns>
        public static double GetHeightFromAirTemperatureOfCelsius(double Temperature)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] TemperatureCelsius = TDatabaseAtmospheric.TemperatureOfCelsius;
            int CountX = TDatabaseAtmospheric.CountX;
            double HeightFromAirTemperatureOfCelsius = TLinearyInterpolation.Interpolate(TemperatureCelsius, AttitudeData, CountX, Temperature);
            return HeightFromAirTemperatureOfCelsius;
        }
//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить высоту по температуре в Кельвинах за бортом для МСА
        /// </summary>
        /// <param name="Temperature">Температура (град Цельсия)x</param>
        /// <returns>Температура (град Цельсия)</returns>
        public static double GetHeightFromAirTemperatureOfKelvin(double Temperature)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] TemperatureKelvin = TDatabaseAtmospheric.TemperatureOfKelvin;
            int CountX = TDatabaseAtmospheric.CountX;
            double HeightFromAirTemperatureOfKelvin = TLinearyInterpolation.Interpolate(TemperatureKelvin, AttitudeData, CountX, Temperature);
            return HeightFromAirTemperatureOfKelvin;
        }
//---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Получить кинематическую вязкость от высоты для МСА
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Кинематическая вязкость</returns>
        public static double GetAirKinematicalViscosityFromHeight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] AirKinematicalViscosityData = TDatabaseAtmospheric.AirKinematicalViscosity;
            int CountX = TDatabaseAtmospheric.CountX;
            double AirKinematicalViscosity = TLinearyInterpolation.Interpolate(AttitudeData, AirKinematicalViscosityData, CountX, Height);
            return AirKinematicalViscosity;
        }

//---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Получить динамическую вязкость от высоты для МСА
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Динамическая вязкость</returns>
        public static double GetAirDynamicalViscosityFromHeight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] AirDynamicalViscosityData = TDatabaseAtmospheric.AirDynamicalViscosity;
            int CountX = TDatabaseAtmospheric.CountX;
            double AirDynamicalViscosity = TLinearyInterpolation.Interpolate(AttitudeData, AirDynamicalViscosityData, CountX, Height);
            return AirDynamicalViscosity;
        }
//---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Получить скорость звука от высоты для МСА
        /// </summary>
        /// <param name="Height">Высота (м)</param>
        /// <returns>Скорость звука</returns>
        public static double GetAirSpeedFromHeight(double Height)
        {
            double[] AttitudeData = TDatabaseAtmospheric.Attitude;
            double[] SpeedOfSound = TDatabaseAtmospheric.SpeedOfSound;
            int CountX = TDatabaseAtmospheric.CountX;
            double AirSpeed = TLinearyInterpolation.Interpolate(AttitudeData, SpeedOfSound, CountX, Height);
            return AirSpeed;
        }
//---------------------------------------------------------------------------------------------------------
    }
}
