using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QualiFactsCodeChallenge.Models;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;

//QUALIFACTS CODE CHALLENGE
namespace QualiFactsCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Uri baseAddress = new Uri("https://localhost:7264/api/Calculator");
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client= new HttpClient(); 
            _client.BaseAddress = baseAddress;  
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

        [HttpPost]
        public JsonResult CalculateApi(int input1, int input2, int size)
        {
            List<CalculationResult> results = new List<CalculationResult>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + String.Format("?input1={0}&input2={1}&size={2}", input1, input2,size)).Result;
            String data = "";

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                results = JsonConvert.DeserializeObject<List<CalculationResult>>(data);
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