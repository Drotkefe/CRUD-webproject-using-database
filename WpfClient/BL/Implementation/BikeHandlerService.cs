using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_HFT_2021221.Models.DTOs;
using VH3Q8P_SG1_21_22_2.WpfClient.Infrastructure;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace VH3Q8P_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class BikeHandlerService : IBikeHandlerService
    {
        readonly IMessenger messenger;
        readonly IBikeEditorService editorService;
        readonly IBikeDisplayService bikeDisplayService;
        HttpService httpService;

        public void AddBike(IList<BikeModel> collection)
        {
            BikeModel bikeToEdit = null;
            bool operationFinished = false;

            do
            {
                var newBike = editorService.EditBike(bikeToEdit);

                if (newBike != null)
                {
                    var operationResult = httpService.Create(new BikeDTO()
                    {
                        BrandId = newBike.BrandID,
                        Model_Name = newBike.Model_name,
                        Price = newBike.Price,
                        RiderId=newBike.RiderID
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
            throw new NotImplementedException();
        }

        public IList<BikeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<BikeModel> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public void ModifyBike(IList<BikeModel> collection, BikeModel bike)
        {
            throw new NotImplementedException();
        }

        public void ViewCar(BikeModel bike)
        {
            throw new NotImplementedException();
        }
    }
}
