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
    public class ManufactureController : ControllerBase
    {
        readonly IManufactureLogic manuLogic;

        public ManufactureController(IManufactureLogic manuLogic)
        {
            this.manuLogic = manuLogic;
        }

        // GET: api/Manufacture/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Manufacture> Get()
        {
            return manuLogic.ReadAll();
        }
       

        // GET api/Manufacture/5
        [HttpGet("{id}")]
        public Manufacture Get(int id)
        {
            return manuLogic.Read(id);
        }

       
        

        // POST api/Manufacture
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Manufacture manufacture)
        {
            var result = new ApiResult(true);
            try
            {
                manuLogic.Create(manufacture);
            }
            catch (Exception)
            {
                result.IsSucces = false;
            }
            return result;
        }

      

        // PUT api/Manufacture
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Manufacture manufacture)
        {
            var result = new ApiResult(true);
            try
            {
                manuLogic.Update(manufacture);
            }
            catch (Exception)
            {
                result.IsSucces = false;
            }
            return result;
        }

        // DELETE api/Manufacture/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);
            try
            {
                manuLogic.Delete(id);
            }
            catch (Exception)
            {
                result.IsSucces = false;
            }
            return result;
        }

    }
}
