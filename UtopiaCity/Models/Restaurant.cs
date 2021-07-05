﻿using System;
using UtopiaCity.Enums;

namespace UtopiaCity.Models
{
    public class Restaurant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public int Seats { get; set; }
        public int Stars { get; set; }
        public string RestaurantTypeId { get; set; }
        public RestaurantType RestaurantType { get; set; }
    }
}