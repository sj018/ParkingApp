using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingApp.Models
{
    public class Parking
    {
        public long Id {get;set;}
        public Car Car {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}
    }
}