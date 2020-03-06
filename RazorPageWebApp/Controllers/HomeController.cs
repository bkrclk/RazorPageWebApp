using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RazorPageWebApp.Models;
using RazorPageWebApp.Models.Validations;

namespace RazorPageWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Country> countryList;
        List<Country> districtList;
        List<Country> cityList;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            DummyData();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        { return View(); }
        [HttpPost]
            public IActionResult Privacy(UserModel userModel)
        {

            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(userModel);
            if (result.IsValid)
            {

                if (userModel.UserName.Equals("bekir") && userModel.Password.Equals("12346578"))
                {
                    HttpContext.Session.SetString("username", userModel.UserName);

                    var username = HttpContext.Session.GetString("username");

                    return RedirectToPage("Index");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult Hakkimda()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ShowForm()
        {
            //Bağlı optionlarda ilk option itemlarını göstermek için
            ViewBag.CountryList = countryList;
            return View();
        }


        public IActionResult AutoComplate()
        {
            return View();
        }
        public IActionResult GetCityList(int cityParentId)
        {
            // Yöntem 1
            var filteredCityList = cityList.Where(q => q.ParentId == cityParentId).ToList();

            // Yöntem 2
            var filteredCityList2 = new List<Country>();
            foreach (var city in cityList)
            {
                if (city.ParentId == cityParentId)
                {
                    filteredCityList2.Add(city);
                }
            }
            return Json(filteredCityList);
        }
        public IActionResult GetDistrictList(int districtParentId)
        {
            // Yöntem 1
            var filtereddistrictList = districtList.Where(q => q.ParentId == districtParentId).ToList();

            return Json(filtereddistrictList);
        }
        public IActionResult DistrictChange(string countryName, string cityName, string districtName)
        {
            string text = "</br>"+countryName + "</br>" + cityName+ "</br>" + districtName;

            return Json(text);
        }
        public void DummyData()
        {
            countryList = new List<Country>  {

        new Country(){ Id=1, ParentId=0, Name="Türkiye"},
        new Country(){ Id=2, ParentId=0, Name="Almanya"},
        new Country(){ Id=3, ParentId=0, Name="Amerika"}
        };

            cityList = new List<Country>  {
        new Country(){ Id=4, ParentId=1, Name="Sivas"},
        new Country(){ Id=5, ParentId=1, Name="İzmir"},
        new Country(){ Id=6, ParentId=1, Name="İstanbul"},
        new Country(){ Id=7, ParentId=2, Name="Münih"},
        new Country(){ Id=8, ParentId=2, Name="Köln"},
        new Country(){ Id=9, ParentId=2, Name="Berlin"},
        new Country(){ Id=10, ParentId=3, Name="New York"},
        new Country(){ Id=11, ParentId=3, Name="California"},
        new Country(){ Id=12, ParentId=3, Name="New Jersey"}
        };

            districtList = new List<Country>   {

        new Country(){ Id=13, ParentId=4, Name="Kangal"},
        new Country(){ Id=14, ParentId=4, Name="Zara"},


        new Country(){ Id=15, ParentId=5, Name="Çeşme"},
        new Country(){ Id=16, ParentId=5, Name="Alsancak"},


        new Country(){ Id=17, ParentId=6, Name="Kadıköy"},
        new Country(){ Id=18, ParentId=6, Name="Beşiktaş"},


        new Country(){ Id=19, ParentId=7, Name="Schwabing"},
        new Country(){ Id=20, ParentId=7, Name="Solln"},


        new Country(){ Id=21, ParentId=8, Name="Altstadt"},
        new Country(){ Id=22, ParentId=8, Name="Zentrum"},


        new Country(){ Id=23, ParentId=9, Name="Kreuzberg"},
        new Country(){ Id=24, ParentId=9, Name="Pankow"},


        new Country(){ Id=25, ParentId=10, Name="Brooklyn"},
        new Country(){ Id=26, ParentId=10, Name="Manhattan"},


        new Country(){ Id=27, ParentId=11, Name="San Francisco"},
        new Country(){ Id=28, ParentId=11, Name="Yolo"},


        new Country(){ Id=29, ParentId=12, Name="Atlantic"},
        new Country(){ Id=30, ParentId=12, Name="Union"}

        };
        }
    }
}
