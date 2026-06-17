using Assignment_10._3.Data;
using Assignment_10._3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10._3.Services
{
    public static class Records
    {
        public static CarContext context;
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

        public void DeleteCar(int VIN)
        {

        }
    }
}
