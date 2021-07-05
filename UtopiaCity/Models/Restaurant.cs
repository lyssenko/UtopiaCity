using System;
using UtopiaCity.Enums;

namespace UtopiaCity.Models
{
    public class Restaurant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Status Status { get; set; }
        public int Seats { get; set; }
    }
}