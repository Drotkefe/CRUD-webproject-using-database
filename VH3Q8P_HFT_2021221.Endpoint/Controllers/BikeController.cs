﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Models.Models;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Models.DTOs;

namespace VH3Q8P_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        readonly IBikeLogic bikeLogic;

        public BikeController(IBikeLogic bikeLogic)
        {
            this.bikeLogic = bikeLogic;
        }

        // GET: api/Bike/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Bike> Get()
        {
            return bikeLogic.ReadAll();
        }

        // GET api/Bike/5
        [HttpGet("{id}")]
        public Bike Get(int id)
        {
            return bikeLogic.Read(id);
        }

        // POST api/Bike/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(BikeDTO bike)
        {
            var result = new ApiResult(true);
            try
            {
                bikeLogic.Create(new Bike()
                {
                    Id=bike.Id,
                    BrandId=bike.BrandId,
                    Model_Name=bike.Model_Name,
                    Price=bike.Price,
                    Fix=bike.Fix,
                    RiderId=bike.RiderId
                }    
                );
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }
            return result;
        }

        // PUT api/Bike/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(BikeDTO bike)
        {
            var result = new ApiResult(true);

            try
            {
                bikeLogic.Update(new Bike()
                {
                    Id = bike.Id,
                    BrandId = bike.BrandId,
                    RiderId = bike.RiderId,
                    Model_Name = bike.Model_Name,
                    Price = bike.Price,
                    Fix = bike.Fix
                    
                });
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }

            return result;
        }

        // DELETE api/Bike/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);
            try
            {
                bikeLogic.Delete(id);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }
            return result;
        }
        //GET api/Bike/GetAmounts
        [HttpGet]
        public IEnumerable<AmountOfBikesModel> GetAmounts()
        {
            return bikeLogic.GetAmounts();
        }
        //GET api/Bike/GetAverages
        [HttpGet]
        public IEnumerable<AverageModel> GetAverages()
        {
            return bikeLogic.GetManufactureAvarages();
        }

        //GET api/Bike/GetMostBikesUser
        [HttpGet]
        public IEnumerable<MostBikeModel> GetMostBikesUser()
        {
            return bikeLogic.GetMostBikesUser();
        }
        //GET api/Bike/GetOldestBrandAmounts
        [HttpGet]
        public IEnumerable<OldestBrandAmountsModel> GetOldestBrandAmounts()
        {
            return bikeLogic.GetOldestManufactureAmounts();
        }
        //Get api/Bike/GetPricePerPeople
        [HttpGet]
        public IEnumerable<PricePerPersonModel> GetPricePerPeople()
        {
            return bikeLogic.GetPricePerPeople();
        }


    }
}
