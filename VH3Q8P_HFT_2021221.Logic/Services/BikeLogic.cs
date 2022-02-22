using System;
using System.Collections.Generic;
using System.Linq;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Models.Models;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Repository.Interfaces;

namespace VH3Q8P_HFT_2021221.Logic.Services
{
    
    public class BikeLogic : IBikeLogic
    {
        IBikeRepository _bikeRepository;
        IManufactureRepository _manuFactureRepository;
        IRiderRepository _riderRepository;

        public BikeLogic(IBikeRepository bikeRepository, IManufactureRepository manuFactureRepository, IRiderRepository riderRepository)
        {
            _bikeRepository = bikeRepository;
            _manuFactureRepository = manuFactureRepository;
            _riderRepository = riderRepository;
        }
        public Bike Create(Bike entity)
        {
            //Validate
            var exist = _bikeRepository.ReadAll().Any(x => x.Id == entity.Id && x.Model_Name == entity.Model_Name && x.Price == entity.Price);
            if (entity.Model_Name==null)
            {
                throw new NullReferenceException("Undefined entity create attempt");
            }
            else
            {
                if (!exist)
                {
                    var result = _bikeRepository.Create(entity);
                    return result;
                }
                throw new Exception("Already exists");
            }
        }

        public void Delete(int id)
        {
            //Validate
            var exist = _bikeRepository.ReadAll().Any(x => x.Id == id);
            if (exist)
            {
                _bikeRepository.Delete(id);
            }
            else
            {
                throw new Exception("This id does not exist");
            }
        }

        public IEnumerable<AmountOfBikesModel> GetAmounts()
        {
            var amounts = from bike in _bikeRepository.ReadAll()
                          group bike by bike.RiderId into grp
                          select new
                          {
                              RiderId = grp.Key,
                              Amount = grp.Count()
                          };
            var result = from rider in _riderRepository.ReadAll()
                         join r in amounts on rider.Id equals r.RiderId
                         select new AmountOfBikesModel
                         {
                             RiderName = rider.Name,
                             Amount = r.Amount
                         };
            return result.ToList();
        }

        public IEnumerable<AverageModel> GetManufactureAvarages()
        {
            var averages = from bike in _bikeRepository.ReadAll()
                           group bike by bike.BrandId into grouped
                           select new
                           {
                               BrandId = grouped.Key,
                               Average = grouped.Average(x => x.Price)
                           };

            var result = from brand in _manuFactureRepository.ReadAll()
                         from average in averages.Where(x => x.BrandId == brand.Id).DefaultIfEmpty()
                         select new AverageModel()
                         {
                             ManufactureName = brand.Name,
                             Avarage = average != null ? average.Average : 0
                         };

            return result.ToList();
        }

        public IEnumerable<MostBikeModel> GetMostBikesUser()
        {
            var persons = from person in _bikeRepository.ReadAll()
                          group person by person.RiderId into grp
                          select new
                          {
                              RiderId = grp.Key,
                              Amount = grp.Count()
                          };

            var names = from rider in _riderRepository.ReadAll()
                        join r in persons on rider.Id equals r.RiderId
                        select new
                        {
                            Name = rider.Name,
                            RiderId = rider.Id,
                            Amount = r.Amount
                        };

            string MostBikeOwner = names.OrderByDescending(x => x.Amount).Select(x => x.Name).Take(1).First();

            var bikes = from bike in _bikeRepository.ReadAll()
                        where names.OrderByDescending(x => x.Amount).Select(x => x.RiderId).Take(1).Any(x => x == bike.RiderId)
                        group bike by bike.BrandId into grp
                        select new
                        {
                            BrandId = grp.Key,
                            Amount = grp.Count()
                        };

            var result = from rider in _riderRepository.ReadAll()
                         where rider.Name == MostBikeOwner
                         from brand in _manuFactureRepository.ReadAll()
                         join b in bikes on brand.Id equals b.BrandId
                         select new MostBikeModel
                         {
                             RiderName = MostBikeOwner,
                             ManufactureName = brand.Name,
                             Amount = b.Amount
                         };

            return result.ToList();
        }

        public IEnumerable<OldestBrandAmountsModel> GetOldestManufactureAmounts()
        {
            var OldestBrand_id = _manuFactureRepository.ReadAll().OrderBy(x => x.Establishment_year).FirstOrDefault().Id;

            var groupof_brands = from bike in _bikeRepository.ReadAll()
                                 group bike by bike.BrandId into grp
                                 select new
                                 {
                                     BrandId = grp.Key,
                                     Amount = grp.Count()
                                 };
            var result = from brand in _manuFactureRepository.ReadAll()
                         where brand.Id == OldestBrand_id
                         join b in groupof_brands on brand.Id equals b.BrandId
                         select new OldestBrandAmountsModel
                         {
                             ManufactureName = brand.Name,
                             Amount = b.Amount
                         };

            return result;
        }

        public IEnumerable<PricePerPersonModel> GetPricePerPeople()
        {
            var prices = from bike in _bikeRepository.ReadAll()
                         group bike by bike.RiderId into grp
                         select new
                         {
                             RiderId = grp.Key,
                             Price = grp.Sum(x => x.Price)
                         };
            var result = from rider in _riderRepository.ReadAll()
                         from price in prices.Where(x => x.RiderId == rider.Id).DefaultIfEmpty()
                         select new PricePerPersonModel
                         {
                             RiderName = rider.Name,
                             Price = price != null ? price.Price : 0
                         };
            return result.ToList();
        }

        public Bike Read(int id)
        {
            return _bikeRepository.Read(id);
        }

        public IList<Bike> ReadAll()
        {
            return _bikeRepository.ReadAll().ToList();
        }

        public Bike Update(Bike entity)
        {

            //Validate
            var exist = _bikeRepository.ReadAll().Any(x => x.Id == entity.Id);
            if (exist)
            {
                var result = _bikeRepository.Update(entity);
                return result;
            }
            else
            {
                throw new Exception("Does not exist");
            }


        }
    }
}
