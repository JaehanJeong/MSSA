using Assignment_10._3.Data;
using Assignment_10._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_10._3.Services
{
    public static class Records
    {
        // Bug fix: this was never instantiated, so Records.context was null
        public static CarContext context = new CarContext();
    }

    public class CRUD
    {
        public void AddCar(Car car)
        {
            Records.context.Cars.Add(car);
            Records.context.SaveChanges();
        }

        public List<Car> GetAllCars()
        {
            return Records.context.Cars.ToList();
        }

        public void UpdateCar(Car car)
        {
            var existing = Records.context.Cars.FirstOrDefault(c => c.VIN == car.VIN);
            if (existing != null)
            {
                existing.Make = car.Make;
                existing.Model = car.Model;
                existing.Year = car.Year;
                existing.Price = car.Price;
                Records.context.SaveChanges();
            }
        }

        public void DeleteCar(string VIN)
        {
            var car = Records.context.Cars.FirstOrDefault(c => c.VIN == VIN);
            if (car != null)
            {
                Records.context.Cars.Remove(car);
                Records.context.SaveChanges();
            }
        }
    }
}