using Lesson_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Models
{

    public class WeatherForecast
    {

        public DateTime Date { get; set; }

        public float TemperatureC { get; set; }

        public float TemperatureF => 32 + (TemperatureC / 0.5556f);

        public WeatherForecast(DateTime date, float temperature) { Date = date; TemperatureC = temperature; }

        public override string ToString() => $"{Date} {TemperatureC}";

    }
}
