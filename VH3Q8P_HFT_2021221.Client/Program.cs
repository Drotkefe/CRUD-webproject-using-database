using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Models.Models;

namespace VH3Q8P_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BikeService
            var httpService = new HttpService("Bike", "http://localhost:26061/api/");

            // Get All
            var bikes = httpService.GetAll<Bike>();
            DisplayBikes(bikes);

            // Get one
            Console.WriteLine("Check Get one");
            var oneBike = httpService.Get<Bike, int>(bikes.First().Id);
            DisplayBike(oneBike);

            // Create
            var newBike = new Bike()
            {
                Model_Name = "Bicikli",
                Price = 1,
                RiderId = 2,
                BrandId = 3
            };

            var result = httpService.Create(newBike);

            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was successfull");
            }
            else
            {
                Console.WriteLine("Creation was unsuccessfull");
            }
           

            // Check
            Console.WriteLine("check");
            bikes = httpService.GetAll<Bike>();
            DisplayBikes(bikes);

            // Update
            var bikeForUpdate = bikes.Last();
            bikeForUpdate.Model_Name = "Updated_bicikli_name";

            result = httpService.Update(bikeForUpdate);

            if (result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }
            else
            {
                Console.WriteLine("Update was Not succesfull");
            }

            // Check
            bikes = httpService.GetAll<Bike>();
            DisplayBikes(bikes);

            // Delete
            result = httpService.Delete(bikes.Last().Id);

            if (result.IsSuccess)
            {
                Console.WriteLine("Delete was successfull.");
            }
            else
            {
                Console.WriteLine("Delete was Not succesfull.");
            }

            // Check
            bikes = httpService.GetAll<Bike>();
            DisplayBikes(bikes);

            // Get Manufacture averages
            var Averages = httpService.GetAll<AverageModel>("GetAverages");
            DisplayGetManuAverages(Averages);

            // Get Bike amounts per Rider
            var Amounts = httpService.GetAll<AmountOfBikesModel>("GetAmounts");
            DisplayGetAmounts(Amounts);

            // Get Rider with most bikes
            var Mostbikes = httpService.GetAll<MostBikeModel>("GetMostBikesUser");
            DisplayGetMostBikesUser(Mostbikes);

            // Get Oldest brand sold bike amount
            var OldestBrandAmount = httpService.GetAll<OldestBrandAmountsModel>("GetOldestBrandAmounts");
            DisplayGetOldestBrandAmount(OldestBrandAmount);
          
            //Get People spent money on bikes
            var prices = httpService.GetAll<PricePerPersonModel>("GetPricePerPeople");
            DisplayPricesPerPeople(prices);
            #endregion

            #region RiderService
            var Rider_Services = new HttpService("Rider", "http://localhost:26061/api/");
            // Get All
            var riders = Rider_Services.GetAll<Rider>();

            // Get one
            var oneRider = Rider_Services.Get<Rider, int>(riders.First().Id);
            DisplayRider(oneRider);

            // Create
            var newRider = new Rider()
            {
                Name = "Tom",
                Age= 16
            };

            var rider_result = Rider_Services.Create(newRider);

            if (rider_result.IsSuccess)
            {
                Console.WriteLine("Creation was successfull");
            }
            else
            {
                Console.WriteLine("Creation was unsuccessfull");
            }

            // Check
            Console.WriteLine("check");
            riders = Rider_Services.GetAll<Rider>();
            DisplayRiders(riders);

            // Update
            var RiderForUpdate = riders.Last();
            RiderForUpdate.Name = "Csoki bácsi";
            RiderForUpdate.Age = 47;

            rider_result = Rider_Services.Update(RiderForUpdate);

            if (rider_result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }
            else
            {
                Console.WriteLine("Update was Not succesfull");
            }

            // Check
            riders = Rider_Services.GetAll<Rider>();
            DisplayRiders(riders);

            // Delete
            rider_result = Rider_Services.Delete(4);

            if (rider_result.IsSuccess)
            {
                Console.WriteLine("Delete was successfull.");
            }
            else
            {
                Console.WriteLine("Delete was Not succesfull.");
            }
            Console.WriteLine("check");
            riders = Rider_Services.GetAll<Rider>();
            DisplayRiders(riders);
            #endregion

            #region ManufactureService
            var manu_Service = new HttpService("Manufacture", "http://localhost:26061/api/");

            // Get All
            var manus = manu_Service.GetAll<Manufacture>();
            DisplayManus(manus);

            // Get one
            Console.WriteLine("Check Get one");
            var oneManu = manu_Service.Get<Manufacture, int>(manus.First().Id);
            DisplayManu(oneManu);

            // Create
            var newManu = new Manufacture()
            {
                Name = "Neuzer Kerékpár Kft",
                Establishment_year=1987,
                Income = 50
            };

            var manu_result = manu_Service.Create(newManu);

            if (manu_result.IsSuccess)
            {
                Console.WriteLine("Creation was successfull");
            }
            else
            {
                Console.WriteLine("Creation was unsuccessfull");
            }


            // Check
            Console.WriteLine("check");
            manus = manu_Service.GetAll<Manufacture>();
            DisplayManus(manus);

            // Update
            var manuForUpdate = manus.Last();
            manuForUpdate.Income = 1000000000;
            manuForUpdate.Name = "Neuzer is on Fire";

            manu_result = manu_Service.Update(manuForUpdate);

            if (manu_result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }
            else
            {
                Console.WriteLine("Update was Not succesfull");
            }

            // Check
            manus = manu_Service.GetAll<Manufacture>();
            DisplayManus(manus);

            // Delete
            manu_result = manu_Service.Delete(manus.Last().Id);

            if (manu_result.IsSuccess)
            {
                Console.WriteLine("Delete was successfull.");
            }
            else
            {
                Console.WriteLine("Delete was Not succesfull.");
            }

            // Check
            manus = manu_Service.GetAll<Manufacture>();
            DisplayManus(manus);
            #endregion
            Console.ReadLine();

        }

        private static void DisplayManu(Manufacture oneManu)
        {
            Console.WriteLine($"Id: {oneManu.Id} Name: {oneManu.Name} Income: {oneManu.Income} Establishment year: {oneManu.Establishment_year}");
        }

        private static void DisplayManus(List<Manufacture> manus)
        {
            foreach (var item in manus)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Income: {item.Income} Establishment year: {item.Establishment_year}");
            }
        }

        private static void DisplayRider(Rider oneRider)
        {
            Console.WriteLine($"Id: {oneRider.Id} Name:{oneRider.Name} Age: {oneRider.Age}");
        }

        private static void DisplayRiders(List<Rider> riders)
        {
            foreach(var item in riders)
            {
                Console.WriteLine($"Id: {item.Id} Name:{item.Name} Age: {item.Age}");
            }
        }

        private static void DisplayPricesPerPeople(List<PricePerPersonModel> prices)
        {
            Console.WriteLine("Ki mennyit költött biciklire");
            foreach (var item in prices)
            {
                Console.WriteLine($"{item.RiderName}  {item.Price*1000} Eurót költött");
            }
        }

        private static void DisplayGetOldestBrandAmount(List<OldestBrandAmountsModel> oldestBrandAmount)
        {
            Console.WriteLine("Legrégebbi gyártó által eladatott bringák darabszáma?");
            foreach (var item in oldestBrandAmount)
            {
                Console.WriteLine($"{item.ManufactureName}  {item.Amount}");
            }
        }

        private static void DisplayGetMostBikesUser(List<MostBikeModel> mostbikes)
        {
            Console.WriteLine("Melyik legtöbb bringával rendelkező személy, bringáinak márkái és darabszáma?");
            int i = 0;
            foreach (var item in mostbikes)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{item.RiderName}");
                }
                Console.WriteLine($"{item.ManufactureName}  {item.Amount}");
                i++;
            }
        }

        private static void DisplayGetAmounts(List<AmountOfBikesModel> amounts)
        {
            Console.WriteLine("Kinek hány biciklije van?");
            foreach (var item in amounts)
            {
                Console.WriteLine($"{item.RiderName}  {item.Amount}");
            }
        }



        private static void DisplayGetManuAverages(List<AverageModel> averages)
        {
            Console.WriteLine("Mennyi az átlagos ára egy bringának gyártókként?");
            foreach (var item in averages)
            {
                Console.WriteLine($"{item.ManufactureName} - {item.Avarage*1000} euró");
            }
        }

        private static void DisplayBikes(List<Bike> bikes)
        {
            foreach (var item in bikes)
            {
                    Console.WriteLine($"Id: {item.Id}  Name: {item.Model_Name} Price: {item.Price} BrandId: {item.BrandId} RiderId:{item.RiderId}");
            }
        }
        private static void DisplayBike(Bike bike)
        {
            Console.WriteLine($"Id: {bike.Id}  Name: {bike.Model_Name} Price: {bike.Price} BrandId: {bike.BrandId} RiderId:{bike.RiderId}");
        }
        
    }
}
