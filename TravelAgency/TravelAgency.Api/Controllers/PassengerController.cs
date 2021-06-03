using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Api.Controllers
{
    public class PassengerController : Controller
    {
        // GET: PassengerController
        public ActionResult Index()
        {
            return View();
        }
    }
}
