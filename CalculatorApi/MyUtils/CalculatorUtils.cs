using CalculatorApi.Models;
using System.Drawing;

namespace CalculatorApi.MyUtils
{
    public class CalculatorUtils
    {
        public static List<CalculationResult> calculateResult(int? input1, int? input2, int? size)
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

            return results;
        }
    }
}
