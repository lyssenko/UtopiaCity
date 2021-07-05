using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models;

namespace UtopiaCity.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationContext _db;
        public RestaurantController(ApplicationContext db)
        {
            _db = db;
        }
    }
}