﻿using System;

namespace Service.API.DTOs
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}