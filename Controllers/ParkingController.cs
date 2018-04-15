using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ParkingApp.Models;
using System;

namespace ParkingApp.Controllers
{
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        private readonly ParkingContext _context;

        public ParkingController(ParkingContext context)
        {
            _context = context;

            if(_context.ParkingItems.Count() == 0)
            {
                Car car1 = new Car();
                car1.carNumber="ABC 123";
                car1.carOwner="Owner1";
                car1.carOwnersContact="123456789";
                _context.ParkingItems.Add(new Parking {Car = car1, StartTime =  DateTime.Now, EndTime = DateTime.Now.AddHours(1)});
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public IEnumerable<Parking> GetAllParkingSpots()
        {
            return _context.ParkingItems.ToList();
        }

        [HttpGet("{id}", Name = "GetParkingSpotById")]
        public IActionResult GetParkingSpotById(long id)
        {
            var parkingSpot = _context.ParkingItems.FirstOrDefault(t => t.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }
            
            return new ObjectResult(parkingSpot);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Parking item)
        {
            if (item == null)
            {
                return BadRequest();
            }

         //   _context.CarItems.Add(item.Car);
            _context.ParkingItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetParkingSpotById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Parking item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var parkingSpot = _context.ParkingItems.FirstOrDefault(t => t.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            parkingSpot.EndTime = item.EndTime;
          
            _context.ParkingItems.Update(parkingSpot);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var parkingSpot = _context.ParkingItems.FirstOrDefault(t => t.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            _context.ParkingItems.Remove(parkingSpot);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}