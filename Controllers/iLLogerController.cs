using Microsoft.AspNetCore.Mvc;

namespace asp_empty.Controllers
{
    public class iLLogerController : Controller
    {
        private readonly ILogger<iLLogerController> _logger;

        public iLLogerController(ILogger<iLLogerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/sum/{a}/{b}")]
        public int sum(int a,int b)
        {
            if (IsSumOver(a, b))
            {
                _logger.LogWarning("values is not cool (");
            }
            else
            {
                _logger.LogInformation($"good {a} - {b} on time {DateTime.Now}"); 
            }
             return a + b;
        }

        [HttpGet("divide/{a}/{b}")]
        public float divide(float a,float b) 
        {
            if (
                    b == 0)
            {
                _logger.LogWarning($"Divide a {a} {b} is not cool ( ");
            }
            else{
                _logger.LogInformation($"{a} {b}");
            }

            return a ;   
        }



        private bool IsSumOver(int a, int b)
        {
            // Проверка, если сумма a и b больше 50000
            if ((long)a + b > 50000)
            {
                return true;
            }

            try
            {
                checked
                {
                    int res = a + b;
                    return false;
                }
            }
            catch (OverflowException)
            {
                return true;
            }
        }


    }
}
