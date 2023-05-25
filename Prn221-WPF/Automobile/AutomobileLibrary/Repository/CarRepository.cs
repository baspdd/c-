using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public Car GetCarById(int carId) => CarManagement.Instance.GetCarByID(carId);
        public IEnumerable<Car> GetCars() => CarManagement.GetCarList();

        public void InsertCar(Car car) => CarManagement.Instance.AddNew(car);
        public void UpdateCar(Car car) => CarManagement.Instance.Update(car);
        public void DeleteCar(Car car) => CarManagement.Instance.Remove(car);

    }
}
