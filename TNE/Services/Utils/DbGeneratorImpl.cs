using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using TNE.Data;
using TNE.Models;

namespace TNE.Services.Utils
{
    public class DbGeneratorImpl : IDbGenerator
    {
        private static Random random = new Random();
        private readonly ILeadDivisionRepository _leadDivisionRepository;
        private readonly ISubDivisionRepository _subDivisionRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IDbUtils _dbUtils;
        private readonly IElectricityMeterRepository _electricityMeterRepository;
        private readonly ICurrentTransformerRepository _currentTransformerRepository;
        private readonly IVoltageTransformerRepository _voltageTransformerRepository;

        public DbGeneratorImpl(ILeadDivisionRepository leadDivisionRepository, ISubDivisionRepository subDivisionRepository, IProviderRepository providerRepository, IDbUtils dbUtils, IElectricityMeterRepository electricityMeterRepository, ICurrentTransformerRepository currentTransformerRepository, IVoltageTransformerRepository voltageTransformerRepository)
        {
            _leadDivisionRepository = leadDivisionRepository;
            _subDivisionRepository = subDivisionRepository;
            _providerRepository = providerRepository;
            _dbUtils = dbUtils;
            _electricityMeterRepository = electricityMeterRepository;
            _currentTransformerRepository = currentTransformerRepository;
            _voltageTransformerRepository = voltageTransformerRepository;
        }

        public async Task Start()
        {
            Log.Debug("Drop Database...");
            _dbUtils.DropDb();
            
            Log.Debug("Add Lead Divisions...");
            foreach (var item in GenerateLeadDivisions())
            {
                await _leadDivisionRepository.CreateAsync(item);
            }
            Log.Debug("Add Sub Divisions...");
            foreach (var item in GenerateSubDivisions())
            {
                await _subDivisionRepository.CreateAsync(item);
            }
            Log.Debug("Add Providers...");
            foreach (var item in GenerateProviders())
            {
                await _providerRepository.CreateAsync(item);
            }
            Log.Debug("Add CurrentTransformers...");
            foreach (var item in GenerateCurrentTransformers())
            {
                await _currentTransformerRepository.CreateAsync(item);
            }
            Log.Debug("Add VoltageTransformers...");
            foreach (var item in GenerateVoltageTransformers())
            {
                await _voltageTransformerRepository.CreateAsync(item);
            }
            Log.Debug("Add ElectricityMeters...");
            foreach (var item in GenerateElectricityMeters())
            {
                await _electricityMeterRepository.CreateAsync(item);
            }
        }

        private static List<LeadDivision> GenerateLeadDivisions()
        {
            return new List<LeadDivision>
            {
                new LeadDivision
                {
                    Name = "ТГК-1",
                    Address = new Address
                    {
                        PostCode = 197198,
                        Country = "РФ",
                        Region = "Санкт-Петербург",
                        City = "Санкт-Петербург",
                        Street = "Проспект Добролюбова",
                        Building = "16, корп.2 лит.А"
                    }
                },
                new LeadDivision
                {
                    Name = "ТГК-2",
                    Address = new Address
                    {
                        PostCode = 150003,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Ярославль",
                        Street = "улица Пятницкая",
                        Building = "6"
                    }
                }
            };
        }

        private List<SubDivision> GenerateSubDivisions()
        {
            var leadDivisionsList = _leadDivisionRepository.GetAllDtoAsync().Result;
            return new List<SubDivision>
            {
                new SubDivision()
                {
                    LeadDivisionId = leadDivisionsList[0].Id,
                    Name = "Филиал Выборг",
                    Address = new Address()
                    {
                        PostCode = 188800,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Выборг",
                        Street = "улица Советская",
                        Building = "12"
                    }
                },
                new SubDivision()
                {
                    LeadDivisionId = leadDivisionsList[0].Id,
                    Name = "Филиал Усть-Луга",
                    Address = new Address()
                    {
                        PostCode = 188471,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Усть-Луга",
                        Street = "улица Сосновая",
                        Building = "54"
                    }
                },
                new SubDivision()
                {
                    LeadDivisionId = leadDivisionsList[1].Id,
                    Name = "Филиал Рыбинск",
                    Address = new Address()
                    {
                        PostCode = 152934,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Рыбинск",
                        Street = "улица Герцена",
                        Building = "26"
                    }
                },
                new SubDivision()
                {
                    LeadDivisionId = leadDivisionsList[1].Id,
                    Name = "Филиал Гаврилов-Ям",
                    Address = new Address()
                    {
                        PostCode = 152240,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Гаврилов-Ям",
                        Street = "улица Советская",
                        Building = "5"
                    }
                }
            };
            
        }
        
        private List<Provider> GenerateProviders()
        {
            var subDivisionsList = _subDivisionRepository.GetAllDtoAsync().Result;
            return new List<Provider>
            {
                new Provider()
                {
                    SubDivisionId = subDivisionsList[0].Id,
                    Name = "ПС110/10 Выборгская",
                    Address = new Address()
                    {
                        PostCode = 188800,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Выборг",
                        Street = "улица Набережная",
                        Building = "69"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[0].Id,
                    Name = "ПС110/6 Автозавод",
                    Address = new Address()
                    {
                        PostCode = 188471,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Выборг",
                        Street = "улица Автозаводская",
                        Building = "126"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[1].Id,
                    Name = "ПС220/10 Центральная",
                    Address = new Address()
                    {
                        PostCode = 188471,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Усть-Луга",
                        Street = "улица Ленина",
                        Building = "26"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[1].Id,
                    Name = "ПС110/6 Западная",
                    Address = new Address()
                    {
                        PostCode = 152240,
                        Country = "РФ",
                        Region = "Ленинградская область",
                        City = "Усть-Луга",
                        Street = "улица Западное кольцо",
                        Building = "123"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[2].Id,
                    Name = "ПС220/6 Рыбинск-1",
                    Address = new Address()
                    {
                        PostCode = 152934,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Рыбинск",
                        Street = "улица Ленина",
                        Building = "16"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[2].Id,
                    Name = "ПС110/10 Судоремонтный завод",
                    Address = new Address()
                    {
                        PostCode = 152934,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Рыбинск",
                        Street = "улица Набержная",
                        Building = "23"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[3].Id,
                    Name = "ПС110/6 Южная",
                    Address = new Address()
                    {
                        PostCode = 152934,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Гаврилов-Ям",
                        Street = "улица Шишкина",
                        Building = "26"
                    }
                },
                new Provider()
                {
                    SubDivisionId = subDivisionsList[3].Id,
                    Name = "ПС220/110/6 Михайловская",
                    Address = new Address()
                    {
                        PostCode = 152240,
                        Country = "РФ",
                        Region = "Ярославская область",
                        City = "Гаврилов-Ям",
                        Street = "улица Емельянова",
                        Building = "5"
                    }
                }
            };
            
        }
        
        private static List<CurrentTransformer> GenerateCurrentTransformers()
        {
            return new List<CurrentTransformer>
            {
                new CurrentTransformer
                {
                    Number = "342434",
                    Type = "TT-11221",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "657754",
                    Type = "TT-32212",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                new CurrentTransformer
                {
                    Number = "456465",
                    Type = "TT-98876",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                new CurrentTransformer
                {
                    Number = "567546",
                    Type = "TT-543743",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "563487",
                    Type = "TT-01534",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "143876",
                    Type = "TT-54665",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "545464",
                    Type = "TT-41323",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                new CurrentTransformer
                {
                    Number = "121134",
                    Type = "TT-87654",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "545411",
                    Type = "TT-85286",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new CurrentTransformer
                {
                    Number = "877434",
                    Type = "TT-22123",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                
            };
        }
        
        private static List<VoltageTransformer> GenerateVoltageTransformers()
        {
            return new List<VoltageTransformer>
            {
                new VoltageTransformer
                {
                    Number = "792979",
                    Type = "TN-22222",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "657759",
                    Type = "TN-72222",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "956965",
                    Type = "TN-98876",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "567596",
                    Type = "TN-597797",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "567987",
                    Type = "TN-02579",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "297876",
                    Type = "TN-59665",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "595969",
                    Type = "TN-92727",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                new VoltageTransformer
                {
                    Number = "222279",
                    Type = "TN-87659",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "595922",
                    Type = "TN-85286",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 765,
                    TransformationRate = 2500
                },
                new VoltageTransformer
                {
                    Number = "877979",
                    Type = "TN-22227",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365,
                    TransformationRate = 1600
                },
                
            };
        }
        
        private static List<ElectricityMeter> GenerateElectricityMeters()
        {
            return new List<ElectricityMeter>
            {
                new ElectricityMeter
                {
                    Number = "345345",
                    Type = "Меркурий-666",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "321644",
                    Type = "Меркурий-666",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "654344",
                    Type = "Меркурий-122",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "654344",
                    Type = "Меркурий-666",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "543333",
                    Type = "Меркурий-122",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "575252",
                    Type = "Меркурий-122",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "548876",
                    Type = "Меркурий-122",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "639285",
                    Type = "Меркурий-666",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "741258",
                    Type = "Меркурий-122",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                },
                new ElectricityMeter
                {
                    Number = "258369",
                    Type = "Меркурий-666",
                    LastVerificationDate = RandomDay(),
                    InterTestingPeriodInDays = 365
                }
            };
        }
        
        private static DateTime RandomDay()
        {
            var start = new DateTime(2019, 1, 1);
            var range = (DateTime.Today - start).Days;           
            return start.AddDays(random.Next(range));
        }
    }
}