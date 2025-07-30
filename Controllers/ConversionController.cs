using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace NumberToWordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberToWordsController : ControllerBase
    {
        // POST api/NumberToWords
        [HttpPost]
        public ActionResult<string> ConvertNumberToWords([FromBody] object input)
        {
            try
            {
                if (input == null)
                    return BadRequest("Input cannot be empty..");

                // Ensure input is a numeric value, reject any alphabetic input
                string inputString = input.ToString();
                if (string.IsNullOrEmpty(inputString) || !decimal.TryParse(inputString, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount))
                {
                    return BadRequest("Input must be numeric value. Letters and special characters are not allowed.");
                }

                if (amount < 0)
                    return BadRequest("Negative numbers are not allowed.");

                if (amount == 0)
                    return Ok("ZERO DOLLARS");

                var dollars = (long)Math.Floor(amount);
                var cents = (long)((amount - dollars) * 100);

                string dollarWords = ConvertToWords(dollars) + " DOLLAR" + (dollars == 1 ? "" : "S");
                string centWords = cents > 0 ? ConvertToWords(cents) + " CENT" + (cents == 1 ? "" : "S") : "";

                return Ok($"{dollarWords}" + (cents > 0 ? " AND " + centWords : ""));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Helper function to convert a number to words
        private string ConvertToWords(long number)
        {
            if (number == 0) return "ZERO";

            string[] thousands = { "", "THOUSAND", "MILLION", "BILLION" };
            string[] ones = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN",
                              "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN",
                              "EIGHTEEN", "NINETEEN" };
            string[] tens = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            string result = "";
            int thousandIndex = 0;

            while (number > 0)
            {
                int part = (int)(number % 1000);
                if (part > 0)
                {
                    string partWords = ConvertHundreds(part, ones, tens);
                    result = partWords + (thousands[thousandIndex] == "" ? "" : " " + thousands[thousandIndex]) + " " + result;
                }
                number /= 1000;
                thousandIndex++;
            }

            return result.Trim();
        }

        private string ConvertHundreds(int number, string[] ones, string[] tens)
        {
            if (number == 0) return "";

            if (number < 20) return ones[number];

            if (number < 100)
                return tens[number / 10] + (number % 10 != 0 ? "-" + ones[number % 10] : "");

            return ones[number / 100] + " HUNDRED" + (number % 100 != 0 ? " AND " + ConvertHundreds(number % 100, ones, tens) : "");
        }
    }
}
