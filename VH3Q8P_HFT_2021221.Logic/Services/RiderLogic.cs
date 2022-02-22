using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Repository.Interfaces;

namespace VH3Q8P_HFT_2021221.Logic.Services
{
    public class RiderLogic : IRiderLogic
    {
        IRiderRepository _riderRepository;

        public RiderLogic(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }

        public Rider Create(Rider entity)
        {
            var exist = _riderRepository.ReadAll().Any(x => x.Id == entity.Id && x.Name == entity.Name && x.Age == entity.Age);
            if (entity.Name == null)
            {
                throw new NullReferenceException("Undefined or already existed entity create attempt");
            }
            else
            {
                if (!exist)
                {
                    var result = _riderRepository.Create(entity);
                    return result;
                }
                throw new Exception("Already exists");
            }
        }

        public void Delete(int id)
        {
            //Validate
            var exist = _riderRepository.ReadAll().Any(x => x.Id == id);
            if (exist)
            {
                _riderRepository.Delete(id);
            }
            else
            {
                throw new Exception("This id does not exist");
            }
        }

        public Rider Read(int id)
        {
            return _riderRepository.Read(id);
        }

        public IList<Rider> ReadAll()
        {
            return _riderRepository.ReadAll().ToList();
        }

        public Rider Update(Rider entity)
        {
            var exist = _riderRepository.ReadAll().Any(x => x.Id == entity.Id);
            if (exist)
            {
                var result = _riderRepository.Update(entity);
                return result;
            }
            else
            {
                throw new Exception("Does not exist");
            }
        }
    }
}
