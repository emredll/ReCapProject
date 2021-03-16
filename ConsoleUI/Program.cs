﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarGetAllTest();
            //CarAddTest();
            //BrandGetByIdTest();
            //CarDetailsTest();
            //ColorGetByIdTest();
            //CarDeleteTest();
            //CarDetailTest();
            //BrandGetAllTest();

        }

        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId + "--" + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "|" + car.ColorName + "|" + car.DailyPrice + "|" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 4 });
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = colorManager.GetById(1).Data;
            Console.WriteLine(color.ColorName);
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}--{1}--{2}--{3}--{4}", car.CarId, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarName = "Volkswagen Jetta", BrandId = 1, ColorId = 2, ModelYear = "2017", 
                DailyPrice = 210, Description = "Binek Volkswagen Jetta 2017 model Beyaz - 210 TL" });
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = brandManager.GetById(1).Data;
            Console.WriteLine(brand.BrandName);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}--{1}--{2}", car.CarName, car.ModelYear, car.DailyPrice + "TL");
                }
            }
        }
    }
}
