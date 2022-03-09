using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab6zadachaWpfApp1
{
    internal class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        private int precipitation;

        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }

        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }

        public int Precipitation
        {
            get => precipitation;
            set => precipitation = value;
        }

        private static string PrecipitationText(int precipitation)
        {
            int n = precipitation;
            string precipitationText;
            switch (n)
            {
                case 0:
                    {
                        precipitationText = "sunny";
                        return precipitationText;
                    }
                case 1:
                    {
                        precipitationText = "cloudy";
                        return precipitationText;
                    }
                case 3:
                    {
                        precipitationText = "rainy";
                        return precipitationText;
                    }
                case 4:
                    {
                        precipitationText = "snowy";
                        return precipitationText;
                    }
                default:
                    {
                        precipitationText = "fault";
                        return precipitationText;
                    }
            }
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(string windDirection, int windSpeed, int precipitation, int temperature)
        {
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Precipitation = precipitation;
            this.Temperature = temperature;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),      //property name
                typeof(int),              //property type
                typeof(WeatherControl),   //property owner
                new FrameworkPropertyMetadata( //property metadata
                    0, //значение по умолчанию
                    FrameworkPropertyMetadataOptions.AffectsMeasure | //Flags
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null, //метод при изменении свойства
                    new CoerceValueCallback(CoerceTemperature)), //метод обратного вызова для коррекции значения при необходимости
                new ValidateValueCallback(ValidateTemperature));  //экземпляр делегата валидации
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
        public string Print()
        {
            return $"{Temperature} {Precipitation} {WindDirection} {WindSpeed}";
        }
    }
}
