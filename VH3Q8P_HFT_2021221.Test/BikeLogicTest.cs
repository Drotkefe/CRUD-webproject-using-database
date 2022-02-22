using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Logic.Services;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Models.Models;
using VH3Q8P_HFT_2021221.Repository.Interfaces;

namespace VH3Q8P_HFT_2021221.Test
{
    [TestFixture]
    public class BikeLogicTest
    {
        #region Constants
        const int Manufacture1Id = 1;
        const int Manufacture2Id = 2;
        const int Manufacture3Id = 3;

        const int Rider1Id = 1;
        const int Rider2Id = 2;
        const int Rider3Id = 3;

        const string Rider1Name = "TestRider1";
        const string Rider2Name = "TestRider2";
        const string Rider3Name = "TestRider3";

        const string Manufacture1Name = "Manufacture1Test";
        const string Manufacture2Name = "Manufacture2Test";
        const string Manufacture3Name = "Manufacture3Test";

        #endregion
        [TestCaseSource(nameof(GetManufactureAvaragesData))]
        public void ManuFactureAvarages(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders, List<AverageModel> expected_result)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            var result = logic.GetManufactureAvarages();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(expected_result));

        }
        static List<TestCaseData> GetManufactureAvaragesData()
        {
            var result = new List<TestCaseData>();
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>(),
                new List<AverageModel>()
            ));

            // One manufacture without bike
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name }
                },
                new List<Rider>(),
                new List<AverageModel>()
                {
                    new AverageModel() { ManufactureName = Manufacture1Name,  Avarage = 0 }
                }
            ));

            // One brand with one car
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture1Id,  Model_Name = "test1", Price = 1200 }
                },
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name }
                },
                new List<Rider>(),
                new List<AverageModel>()
                {
                    new AverageModel() { ManufactureName = Manufacture1Name,  Avarage = 1200 }
                }
            ));

            // One brand without car (bad id)
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture2Id, Model_Name = "test1", Price = 1200 }
                },
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name }
                },
                new List<Rider>(),
                new List<AverageModel>()
                {
                    new AverageModel() { ManufactureName = Manufacture1Name, Avarage = 0 }
                }
            ));

            // Multiple manufacture with multiple bikes
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500 };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400 };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000 };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 2000 };
            var bike5 = new Bike() { Id = 5, BrandId = Manufacture2Id, Model_Name = "Test5", Price = 3001 };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4,bike5
                },
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name },
                    new Manufacture() { Id = Manufacture2Id, Name = Manufacture2Name },
                },
                new List<Rider>(),
                new List<AverageModel>()
                {
                    new AverageModel() { ManufactureName = Manufacture1Name, Avarage = (bike1.Price + bike2.Price) / 2 },
                    new AverageModel() { ManufactureName = Manufacture2Name, Avarage = (bike3.Price + bike4.Price + bike5.Price) / 3.0 }
                }
            ));

            return result;
        }
        [TestCaseSource(nameof(GetBikesPerRiderData))]
        public void AmountOFBikesPerRider(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders, List<AmountOfBikesModel> expected_result)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            var result = logic.GetAmounts();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(expected_result));
        }
        static List<TestCaseData> GetBikesPerRiderData()
        {
            var result = new List<TestCaseData>();
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>(),
                new List<AmountOfBikesModel>()
            ));
            // One Rider without bike
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider()
                    {
                         Id=Rider1Id ,Name=Rider1Name, Age=18
                    }
                },
                new List<AmountOfBikesModel>()
            ));

            // One Rider with one bike
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture1Id,  Model_Name = "test1", Price = 1200, RiderId=Rider1Id }
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){ Id = Rider1Id, Age = 8, Name=Rider1Name}
                },
                new List<AmountOfBikesModel>()
                {
                    new AmountOfBikesModel{ RiderName=Rider1Name, Amount=1}
                }
            ));

            // One Rider without bike (bad id)
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture2Id, Model_Name = "test1", Price = 1200 ,RiderId=Rider2Id}
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){ Id= Rider1Id, Name=Rider1Name,Age=22 }
                },
                new List<AmountOfBikesModel>()

            ));

            // Multiple Rider with multiple bikes
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500, RiderId = Rider1Id };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400, RiderId = Rider1Id };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000, RiderId = Rider2Id };
            var bike4 = new Bike() { Id = 4, BrandId = 3, Model_Name = "Test4", Price = 800, RiderId = Rider2Id };

            var rider1 = new Rider() { Id = Rider1Id, Age = 10, Name = Rider1Name };
            var rider2 = new Rider() { Id = Rider2Id, Age = 11, Name = Rider2Name };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    rider1,rider2
                },
                new List<AmountOfBikesModel>()
                {
                    new AmountOfBikesModel() { RiderName=Rider1Name,Amount = 2},
                    new AmountOfBikesModel() { RiderName=Rider2Name, Amount = 2}
                }
            ));

            return result;

        }
        [TestCaseSource(nameof(MostBikeOwnerData))]
        public void MostBikeOwner(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders, List<MostBikeModel> expected_result)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            var result = logic.GetMostBikesUser();
            //Assert

            Assert.That(result, Is.EquivalentTo(expected_result));
        }
        static List<TestCaseData> MostBikeOwnerData()
        {
            var result = new List<TestCaseData>();
            // One Rider with one bike
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture1Id,  Model_Name = "test1", Price = 1200, RiderId=Rider1Id }
                },
                new List<Manufacture>()
                {
                    new Manufacture{ Id=Manufacture1Id, Name=Manufacture1Name}
                },
                new List<Rider>()
                {
                    new Rider(){ Id = Rider1Id, Age = 8, Name=Rider1Name}
                },
                new List<MostBikeModel>()
                {
                    new MostBikeModel{ RiderName=Rider1Name, ManufactureName=Manufacture1Name, Amount=1}
                }
            ));

            // Multiple Rider with multiple bikes
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500, RiderId = Rider1Id };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400, RiderId = Rider1Id };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000, RiderId = Rider2Id };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 800, RiderId = Rider1Id };

            var manu1 = new Manufacture { Id = Manufacture1Id, Name = Manufacture1Name };
            var manu2 = new Manufacture { Id = Manufacture2Id, Name = Manufacture2Name };

            var rider1 = new Rider() { Id = Rider1Id, Age = 10, Name = Rider1Name };
            var rider2 = new Rider() { Id = Rider2Id, Age = 11, Name = Rider2Name };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4
                },
                new List<Manufacture>()
                {
                    manu1,manu2
                },
                new List<Rider>()
                {
                    rider1,rider2
                },
                new List<MostBikeModel>()
                {
                    new MostBikeModel() { RiderName=Rider1Name, ManufactureName=Manufacture1Name ,Amount = 2},
                    new MostBikeModel() { RiderName=Rider1Name, ManufactureName=Manufacture2Name, Amount = 1}
                }
            ));

            return result;

        }
        [TestCaseSource(nameof(OldestBrandAmountData))]
        public void OldestBrandAmount(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders, List<OldestBrandAmountsModel> expected_result)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            var result = logic.GetOldestManufactureAmounts();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(expected_result));

        }
        static List<TestCaseData> OldestBrandAmountData()
        {

            var result = new List<TestCaseData>();

            // One manufacture without bike
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name, Establishment_year=1950 }
                },
                new List<Rider>(),
                new List<OldestBrandAmountsModel>()
            ));

            // One brand with one car
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture1Id,  Model_Name = "test1", Price = 1200 }
                },
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name, Establishment_year= 1950 }
                },
                new List<Rider>(),
                new List<OldestBrandAmountsModel>()
                {
                    new OldestBrandAmountsModel() { ManufactureName = Manufacture1Name,  Amount = 1 }
                }
            ));

            // Multiple manufacture with multiple bikes
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500 };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400 };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000 };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 2000 };
            var bike5 = new Bike() { Id = 5, BrandId = Manufacture2Id, Model_Name = "Test5", Price = 3001 };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4,bike5
                },
                new List<Manufacture>()
                {
                    new Manufacture() { Id = Manufacture1Id, Name = Manufacture1Name, Establishment_year = 1955 },
                    new Manufacture() { Id = Manufacture2Id, Name = Manufacture2Name, Establishment_year = 1700},
                },
                new List<Rider>(),
                new List<OldestBrandAmountsModel>()
                {
                    new OldestBrandAmountsModel() { ManufactureName = Manufacture2Name, Amount= 3}
                }
            ));

            return result;
        }
        [TestCaseSource(nameof(PricePerPersonData))]
        public void PricePerPerson(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders, List<PricePerPersonModel> expected_result)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            var result = logic.GetPricePerPeople();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EquivalentTo(expected_result));

        }
        static List<TestCaseData> PricePerPersonData()
        {
            var result = new List<TestCaseData>();
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>(),
                new List<PricePerPersonModel>()
            ));

            // One person without bike
            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){Id=Rider1Id ,Name=Rider1Name}
                },
                new List<PricePerPersonModel>()
                {
                    new PricePerPersonModel() {  RiderName = Rider1Name,   Price = 0 }
                }
            ));

            // One person with one bike
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture1Id,  Model_Name = "test1", Price = 1200 , RiderId=Rider1Id}
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){Id=Rider1Id ,Name=Rider1Name}
                },
                new List<PricePerPersonModel>()
                {
                    new PricePerPersonModel() { RiderName = Rider1Name,   Price = 1200 }
                }
            ));

            // One brand without bike (bad id)
            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    new Bike() { Id = 1, BrandId = Manufacture2Id, Model_Name = "test1", Price = 1200, RiderId=Rider2Id }
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){Id=Rider1Id ,Name=Rider1Name}
                },
                new List<PricePerPersonModel>()
                {
                    new PricePerPersonModel() { RiderName=Rider1Name, Price = 0 }
                }
            ));

            // Multiple manufacture with multiple bikes
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500, RiderId = Rider1Id };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400, RiderId = Rider2Id };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000, RiderId = Rider1Id };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 2000, RiderId = Rider2Id };
            var bike5 = new Bike() { Id = 5, BrandId = Manufacture2Id, Model_Name = "Test5", Price = 3001, RiderId = Rider1Id };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4,bike5
                },
                new List<Manufacture>(),
                new List<Rider>()
                {
                    new Rider(){Id=Rider1Id ,Name=Rider1Name},
                    new Rider(){Id=Rider2Id ,Name=Rider2Name}
                },
                new List<PricePerPersonModel>()
                {
                    new PricePerPersonModel() { RiderName = Rider1Name, Price = bike1.Price+bike3.Price+bike5.Price},
                    new PricePerPersonModel() { RiderName = Rider2Name, Price = bike2.Price+bike4.Price }
                }
            ));

            return result;
        }
        [TestCaseSource(nameof(CreateData))]
        public void BikeCreateExceptionTest(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders)
        {
            //Arrange
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => logic.Create(new Bike()));
            //missing Model_name
            Assert.Throws<NullReferenceException>(() => logic.Create(new Bike { Id = 1, Price = 2, BrandId = 3 }));
        }
        static List<TestCaseData> CreateData()
        {
            var result = new List<TestCaseData>();

            result.Add(new TestCaseData(
                new List<Bike>(),
                new List<Manufacture>(),
                new List<Rider>()
            ));
            return result;
        }
        [TestCaseSource(nameof(RiderCreateData))]
        public void RiderCreateTest(List<Rider> riders)
        {
            //Arrange
            var riderRepo = new Mock<IRiderRepository>();
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            var logic = new RiderLogic(riderRepo.Object);
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => logic.Create(new Rider()));
        }
        static List<TestCaseData> RiderCreateData()
        {
            var result = new List<TestCaseData>();

            result.Add(new TestCaseData(

                new List<Rider>()
            ));
            return result;
        }
        [TestCaseSource(nameof(ManufactureCreateData))]
        public void ManufactureCreateTest(List<Manufacture> manufactures)
        {
            //Arrange
            var manuRepo = new Mock<IManufactureRepository>();
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            var logic = new ManufactureLogic(manuRepo.Object);
            //Act
            //Assert
            Assert.Throws<NullReferenceException>(() => logic.Create(new Manufacture()));
        }
        static List<TestCaseData> ManufactureCreateData()
        {
            var result = new List<TestCaseData>();

            result.Add(new TestCaseData(

                new List<Manufacture>()
            ));
            return result;
        }

        [TestCaseSource(nameof(BikeDeleteTestData))]
        public void BikeDeleteTest(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders)
        {
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());
            
            var logic = new BikeLogic(bikeRepo.Object, manuRepo.Object, riderRepo.Object);


            Assert.Throws<Exception>(()=>logic.Delete(8));
            
        }
        static List<TestCaseData> BikeDeleteTestData()
        {
            var result = new List<TestCaseData>();

            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500, RiderId = Rider1Id };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400, RiderId = Rider1Id };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000, RiderId = Rider2Id };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 800, RiderId = Rider1Id };

            var manu1 = new Manufacture { Id = Manufacture1Id, Name = Manufacture1Name };
            var manu2 = new Manufacture { Id = Manufacture2Id, Name = Manufacture2Name };

            var rider1 = new Rider() { Id = Rider1Id, Age = 10, Name = Rider1Name };
            var rider2 = new Rider() { Id = Rider2Id, Age = 11, Name = Rider2Name };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4
                },
                new List<Manufacture>()
                {
                    manu1,manu2
                },
                new List<Rider>()
                {
                    rider1,rider2
                }
            ));
            return result;

        }
        [TestCaseSource(nameof(RiderDeleteTestData))]
        public void RiderDeleteTest(List<Bike> bikes, List<Manufacture> manufactures, List<Rider> riders)
        {
            var bikeRepo = new Mock<IBikeRepository>();
            var manuRepo = new Mock<IManufactureRepository>();
            var riderRepo = new Mock<IRiderRepository>();

            bikeRepo.Setup(x => x.ReadAll()).Returns(bikes.AsQueryable());
            manuRepo.Setup(x => x.ReadAll()).Returns(manufactures.AsQueryable());
            riderRepo.Setup(x => x.ReadAll()).Returns(riders.AsQueryable());

            var logic = new RiderLogic(riderRepo.Object);

            Assert.Throws<Exception>(() => logic.Delete(8));
        }
        static List<TestCaseData> RiderDeleteTestData()
        {
            var result = new List<TestCaseData>();
            var bike1 = new Bike() { Id = 1, BrandId = Manufacture1Id, Model_Name = "Test1", Price = 2500, RiderId = Rider1Id };
            var bike2 = new Bike() { Id = 2, BrandId = Manufacture1Id, Model_Name = "Test2", Price = 1400, RiderId = Rider1Id };
            var bike3 = new Bike() { Id = 3, BrandId = Manufacture2Id, Model_Name = "Test3", Price = 1000, RiderId = Rider2Id };
            var bike4 = new Bike() { Id = 4, BrandId = Manufacture2Id, Model_Name = "Test4", Price = 800, RiderId = Rider1Id };

            var manu1 = new Manufacture { Id = Manufacture1Id, Name = Manufacture1Name };
            var manu2 = new Manufacture { Id = Manufacture2Id, Name = Manufacture2Name };

            var rider1 = new Rider() { Id = Rider1Id, Age = 10, Name = Rider1Name };
            var rider2 = new Rider() { Id = Rider2Id, Age = 11, Name = Rider2Name };

            result.Add(new TestCaseData(
                new List<Bike>()
                {
                    bike1,bike2,bike3,bike4
                },
                new List<Manufacture>()
                {
                    manu1,manu2
                },
                new List<Rider>()
                {
                    rider1,rider2
                }
            ));
            return result;


        }
    }
}
