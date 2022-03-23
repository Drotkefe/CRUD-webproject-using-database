using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_HFT_2021221.Models.DTOs;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_SG1_21_22_2.WpfClient.Infrastructure;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace VH3Q8P_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class BikeHandlerService : IBikeHandlerService
    {
        readonly IMessenger messenger;
        readonly IBikeEditorService editorService;
        readonly IBikeDisplayService bikeDisplayService;
        HttpService httpService_bike;
        HttpService httpService_manu;
        HttpService httpService_rider;

        public BikeHandlerService(IMessenger messenger, IBikeEditorService editorService, IBikeDisplayService bikeDisplayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.bikeDisplayService = bikeDisplayService;
            httpService_bike = new HttpService("Bike", "http://localhost:26061/api/");
            httpService_manu = new HttpService("Manufacture", "http://localhost:26061/api/");
            httpService_rider = new HttpService("Rider", "http://localhost:26061/api/");
        }

        public void AddBike(IList<BikeModel> collection)
        {
            BikeModel bikeToEdit = null;
            bool operationFinished = false;

            do
            {
                var newBike = editorService.EditBike(bikeToEdit);

                if (newBike != null)
                {
                    var operationResult = httpService_bike.Create(new BikeDTO()
                    {
                        BrandId = newBike.BrandID,
                        Model_Name = newBike.Model_name,
                        Price = newBike.Price,
                        RiderId = newBike.RiderID,
                        Fix = newBike.Fix
                    });

                    bikeToEdit = newBike;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        //collection.Add(newCar);
                        RefreshCollectionFromServer(collection);

                        SendMessage("Car add was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Car add has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        private void RefreshCollectionFromServer(IList<BikeModel> collection)
        {
            collection.Clear();
            var newBikes = GetAll();

            foreach (var bike in newBikes)
            {
                collection.Add(bike);
            }
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }

        public void DeleteBike(IList<BikeModel> collection, BikeModel bike)
        {
            if (bike != null)
            {
                var operationResult = httpService_bike.Delete(bike.Id);

                if (operationResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Bike deletion was successful");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Bike deletion failed");
            }
        }

        public IList<BikeModel> GetAll()
        {
            var cars = httpService_bike.GetAll<Bike>();

            return cars.Select(x => new BikeModel(x.Id,x.Model_Name,x.Price,x.BrandId,x.RiderId,x.Fix)).ToList();
        }

        public IList<ManuFactureModel> GetAllBrands()
        {
            var brands = httpService_manu.GetAll<Manufacture>();

            return brands.Select(x => new ManuFactureModel(x.Id,x.Name,x.Establishment_year,x.Income)).ToList();
        }

        public void ModifyBike(IList<BikeModel> collection, BikeModel bike)
        {
            BikeModel bikeToEdit = bike;
            bool operationFinished = false;

            do
            {
                var editedBike = editorService.EditBike(bikeToEdit);

                if (editedBike != null)
                {
                    var operationResult = httpService_bike.Update(new BikeDTO()
                    {
                        Id = bike.Id, // This prop cannot be changed
                        BrandId = editedBike.BrandID,
                        Model_Name = editedBike.Model_name,
                        Price = editedBike.Price
                    });

                    bikeToEdit = editedBike;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);
                        SendMessage("Bike modification was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Bike modification has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }
        public void ViewBike(BikeModel bike)
        {
            bikeDisplayService.BikeDisplay(bike);
        }

        public IList<RiderModel> GetAllRiders()
        {
            var riders = httpService_rider.GetAll<Rider>();

            return riders.Select(x => new RiderModel(x.Id, x.Name, x.Age)).ToList();
        }
    }

        
}
