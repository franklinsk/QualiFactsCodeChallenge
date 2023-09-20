using Microsoft.AspNetCore.Mvc;
using QualiFactsCodeChallenge.Models;
using System.Diagnostics;

//QUALIFACTS CODE CHALLENGE
namespace QualiFactsCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(int input1, int input2, int size)
        {
            List<CalculationResult> results = new List<CalculationResult>();

            
            for (int number = 1; number <= size; number++)
            {
                string result = "N/A";

                if (number % input1 == 0)
                {
                    result = "yes";
                }

                if (number % input2 == 0)
                {
                    if (result == "yes")
                    {
                        result = "I dont know";
                    }
                    else
                    {
                        result = "no";
                    }
                }

                results.Add(new CalculationResult
                {
                    Number = number,
                    Result = result
                });
            }

            return Json(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}