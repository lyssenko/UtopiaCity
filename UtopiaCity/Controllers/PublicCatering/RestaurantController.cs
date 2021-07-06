using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicCatering;

namespace UtopiaCity.Controllers.PublicCatering
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _dBcontext;

        public RestaurantController(ApplicationDbContext dBcontext)
        {
            this._dBcontext = dBcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var restaurants = _dBcontext.Restaurants.ToList();
            return View(restaurants);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            if (restaurant == null) return RedirectToAction("Index");
            try
            {
                _dBcontext.Restaurants.Add(restaurant);
                _dBcontext.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var restaurant = _dBcontext.Restaurants.FirstOrDefault(p => p.Id == id);
            if (restaurant == null) return RedirectToAction("Index", "Restaurant");
            _dBcontext.Restaurants.Remove(restaurant);
            _dBcontext.SaveChanges();

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var restaurant = _dBcontext.Restaurants.FirstOrDefault(p => p.Id == id);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            try
            {
                _dBcontext.Restaurants.Update(restaurant);
                _dBcontext.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var restaurant = _dBcontext.Restaurants.FirstOrDefault(p => p.Id == id);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return RedirectToAction("Index");
        }
        
    }
}