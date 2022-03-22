using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VH3Q8P_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RiderController : ControllerBase
    {
        readonly IRiderLogic riderLogic;

        public RiderController(IRiderLogic riderLogic)
        {
            this.riderLogic = riderLogic;
        }

        // GET: api/Rider/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Rider> Get()
        {
            return riderLogic.ReadAll();
        }

        // GET api/Rider/1
        [HttpGet("{id}")]
        public Rider Get(int id)
        {
            return riderLogic.Read(id);
        }

        // POST api/Rider/Create
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Rider rider)
        {
            var result = new ApiResult(true);
            try
            {
                riderLogic.Create(rider);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }
            return result;
        }

        // PUT api/Manufacture/update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Rider rider)
        {
            var result = new ApiResult(true);
            try
            {
                riderLogic.Update(rider);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }
            return result;
        }

        // DELETE api/Rider/2
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);
            try
            {
                riderLogic.Delete(id);
            }
            catch (Exception)
            {
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
