using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageWebApp.Models;

namespace RazorPageWebApp
{
    public class DefaultModel : PageModel
    {
        public UserModel UserModel { set; get; }
        public Country Country { set; get; }

        public IActionResult OnPostSignin()
        {
            var getUserName = UserModel.UserName;

            return Page();


        }

        public void OnGet()
        {
            List<Country> country = new List<Country>(){

 new Country(){ Id=1, ParentId=0, Name="Türkiye"},
 new Country(){ Id=2, ParentId=0, Name="Almanya"},
 new Country(){ Id=3, ParentId=0, Name="Amerika"}
 };

            List<Country> city = new List<Country>(){
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

            List<Country> district = new List<Country>(){

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
            ViewData["Country"] = country;
            //ViewBag.Aaa = country;
        }
    }
}