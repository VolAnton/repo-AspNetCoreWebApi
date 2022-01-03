using Lesson_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Controllers
{

    [Route("[controller]")]

    [ApiController]

    public class WeatherForecastController : ControllerBase
    {

        private readonly ValuesHolder<WeatherForecast> _holder;

        public WeatherForecastController(ValuesHolder<WeatherForecast> holder) => _holder = holder;

        [HttpPost]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] float temperature)
        {
            _holder.Values.Add(new WeatherForecast(date, temperature));
            return Ok($"\"{_holder.Values[_holder.Values.Count - 1]}\" added.");
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            if (from > to) return BadRequest();
            ValuesHolder<WeatherForecast> tempHolder = new ValuesHolder<WeatherForecast>();
            foreach (var item in _holder.Values)
                if (item.Date >= from.Date && item.Date <= to.Date)
                    tempHolder.Values.Add(item);
            return Ok(tempHolder);
        }

        [HttpPatch]
        public IActionResult Update([FromQuery] DateTime dateTimeToUpdate, [FromQuery] float temperature)
        {
            int updatedItemsCount = 0;
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i].Date.Equals(dateTimeToUpdate))
                {
                    _holder.Values[i].TemperatureC = temperature;
                    updatedItemsCount++;
                }
            }
            return Ok($"Updates items count: {updatedItemsCount}");
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            int deletedItemsCount = 0;
            for (int i = 0; i < _holder.Values.Count; i++)
                if (_holder.Values[i].Date >= from.Date && _holder.Values[i].Date <= to.Date)
                    if (_holder.Values.Remove(_holder.Values[i])) deletedItemsCount++;
            return Ok($"Deleted items count: {deletedItemsCount}");
        }
    }
}
