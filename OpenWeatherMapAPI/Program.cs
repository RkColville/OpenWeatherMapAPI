using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter your API key:");
            var apiKey = Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");

                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var responseFormat = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(responseFormat);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput.ToLower() == "no")
                {
                    break;
                }
            }
        }
    }
}
