using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Controllers
{
    public class ApitestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Movie()
        {
            string endPoint = "https://www.omdbapi.com/?i=tt3896198&apikey=b3b0877c";
            MovieApi movie = new MovieApi();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(endPoint))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<MovieApi>(apiResponse);
                }
            }
            return View(movie);
        }
    }
}