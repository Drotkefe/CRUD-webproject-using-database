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
    public class ManufactureLogic : IManufactureLogic
    {
        IManufactureRepository _manuFactureRepository;

        public ManufactureLogic(IManufactureRepository manuFactureRepository)
        {
            _manuFactureRepository = manuFactureRepository;
        }

        public Manufacture Create(Manufacture entity)
        {
            var exist = _manuFactureRepository.ReadAll().Any(x => x.Id == entity.Id && x.Name == entity.Name && x.Establishment_year == entity.Establishment_year && x.Income==entity.Income);
            if (entity.Name == null)
            {
                throw new NullReferenceException("Undefined or already existed entity create attempt");
            }
            else
            {
                if (!exist)
                {
                    var result = _manuFactureRepository.Create(entity);
                    return result;
                }
                throw new Exception("Already exists");
            }
        }

        public void Delete(int id)
        {
            //Validate
            var exist = _manuFactureRepository.ReadAll().Any(x => x.Id == id);
            if (exist)
            {
                _manuFactureRepository.Delete(id);
            }
            else
            {
                throw new Exception("This id does not exist");
            }
           
        }

        public Manufacture Read(int id)
        {
            return _manuFactureRepository.Read(id);
        }

        public IList<Manufacture> ReadAll()
        {
            return _manuFactureRepository.ReadAll().ToList();
        }

        public Manufacture Update(Manufacture entity)
        {
            var exist = _manuFactureRepository.ReadAll().Any(x => x.Id == entity.Id);
            if (exist)
            {
                var result = _manuFactureRepository.Update(entity);
                return result;
            }
            else
            {
                throw new Exception("Already exists");
            }
        }
    }
}
