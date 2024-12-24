using Microsoft.AspNetCore.Mvc;

namespace SHURALE.Controllers
{
    public class WeatherDara
    {
        public int id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }

    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherDara> weatherDatas = new()
        {
            new WeatherDara() {id = 2, Date=  "21.01.2022", Degree = 10, Location = "Мурманск"},
            new WeatherDara() {id = 23, Date=  "10.08.2019", Degree = -20, Location = "Взаперздрановск"},
            new WeatherDara() {id = 51, Date=  "05.11.2020", Degree = 15, Location = "Омск"},
            new WeatherDara() {id = 59, Date=  "07.02.2021", Degree = 0, Location = "Томск"},
            new WeatherDara() {id = 1, Date=  "30.05.2022", Degree = 3, Location = "Бурбздумск"},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherDara> GetAll()
        {
            return weatherDatas;
        }

        [HttpGet("{id}")]
        public IActionResult GetByIndex(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Такая запись не найдена");
        }

        [HttpGet("find-by-city")]
        public IActionResult GetCountByCityName(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return BadRequest("Имя города не должно быть пустым");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Location.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                {
                    return Ok("Запись с указанным городом имеется в списке");
                }
            }
            return BadRequest("Запись с указанным городом не обнаружена");
        }

        [HttpPost]
        public IActionResult Add(WeatherDara data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].id == data.id)
                {
                    return BadRequest("Запись с таким ID уже существует");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(WeatherDara data)
        {
            // Проверка значения поля Id
            if (data.id < 0)
            {
                return BadRequest("Id не может быть меньше 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].id == data.id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // Проверка значения поля Id
            if (id < 0)
            {
                return BadRequest("Id не может быть меньше 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }
    }
}

