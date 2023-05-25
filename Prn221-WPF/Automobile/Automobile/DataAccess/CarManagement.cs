﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobile.DataAccess

{
    public class CarManagement
    {
        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();

        private CarManagement()
        {

        }

        public static CarManagement Instance
        {
            get
            {

                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                }
                return instance;
            }
        }

        //--------------------------------------
        public static IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStoreContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return cars;

        }

        //-------------------------------
        public Car GetCarByID(int? carID)
        {
            Car car = null;
            try
            {
                var myStockDB = new MyStoreContext();
                car = myStockDB.Cars.SingleOrDefault(car => car.CarId == carID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return car;

        }


        //---------------------------------------
        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car == null)
                {
                    var myStockDB = new MyStoreContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();

                }
                else
                {
                    throw new Exception("The car is already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        //--------------------------------------
        public void Update(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarId);
                if (c != null)
                {
                    var myStockDB = new MyStoreContext();
                    myStockDB.Entry<Car>(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();

                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        //------------------------------
        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var myStockDB = new MyStoreContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();


                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    } // end class
}
