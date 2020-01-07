using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UniSearch.Models;

namespace UniSearch.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string FirstName = "", string LastName = "", string address = "")
        {
            Random random = new Random();

            List<SourceViewModel> model = new List<SourceViewModel>();

            SourceViewModel academyModel = new SourceViewModel()
            {
                Name = "Academy",
                LeadText = "Benefits and council tax records"
            };

            SourceViewModel ccmModel = new SourceViewModel()
            {
                Name = "Corporate Case Management",
                LeadText = "The corporate system for case management records " +
                            "such as complaints and ASB"
            };

            SourceViewModel idoxModel = new SourceViewModel()
            {

                Name = "IDOX",
                LeadText = "Planning and licensing applications"
            };

            string name = FirstName + " " + LastName;
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                //add to academy
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = name,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " receives housing benefit"
                            : " is in arrears for council tax",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    academyModel.Results.Add(result);
                }

                //add to ccm
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = name,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " has a current open case with the 'CORP COMPLAINTS' team"
                            : " has a closed case with the 'WELFARE RIGHTS' team",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    ccmModel.Results.Add(result);
                }

                //add to idox
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = name,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " has submitted a planning application"
                            : " holds a personal alcohol licence",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    idoxModel.Results.Add(result);
                }
            }

            if (!string.IsNullOrWhiteSpace(address))
            {
                //add to academy
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = address,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " receives housing benefit"
                            : " is in arrears for council tax",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    academyModel.Results.Add(result);
                }

                //add to ccm
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = address,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " has a current open case with the 'CORP COMPLAINTS' team"
                            : " has a closed case with the 'WELFARE RIGHTS' team",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    ccmModel.Results.Add(result);
                }

                //add to idox
                for (int i = 0; i < random.Next(5); i++)
                {
                    SearchResultViewModel result = new SearchResultViewModel()
                    {
                        EntityMatch = address,
                        HeaderFollowText = random.Next(10) % 2 == 0
                            ? " has submitted a planning application"
                            : " holds a personal alcohol licence",
                        Stamp = DateTime.Now.AddDays(random.Next(-1000, 0)),
                        LeadText = "Some smaller detail about this record here?"
                    };
                    idoxModel.Results.Add(result);
                }
            }

            model.Add(academyModel);
            model.Add(ccmModel);
            model.Add(idoxModel);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoSearch([FromForm]SearchViewModel model)
        {
            RouteValueDictionary pairs = new RouteValueDictionary();
            pairs.Add("FirstName", model.FirstName);
            pairs.Add("LastName", model.LastName);
            pairs.Add("Address", model.Address);

            return RedirectToAction("Index", pairs);
        }
    }
}