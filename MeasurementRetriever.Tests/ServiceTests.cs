using MeasurementRetriever.Domain.Interfaces;
using MeasurementRetriever.Integration.ElectisityDatasetRetriver;
using MeasurementRetriever.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MeasurementRetriever.Tests
{

   
    public class ServiceTests 
    {

       
        [Fact]
        public  void Add_TestAgregate()
        {
            var mockUnitOFWork = new Mock<IUnitOfWork>();
            var mockServiceClient = new Mock<IServiceClient>();
            var mockLogger = new Mock<ILogger<MeasurementService>>();
            var service =new MeasurementService(mockUnitOFWork.Object,mockServiceClient.Object,mockLogger.Object);

            var measurements = new Measurement[2]
            {
                new Measurement
                {
                    OBJ_GV_TIPAS="N",
                    OBT_PAVADINIMAS="Butas",
                    TINKLAS="Klaipėdos regiono tinklas",
                    OBJ_NUMERIS=4873840,
                    PL_T=DateTime.Now,
                    PMinus=(decimal)1.3193,
                    PPlus=(decimal)7

                },
                      new Measurement
                {
                    OBJ_GV_TIPAS="N",
                    OBT_PAVADINIMAS="Butas",
                    TINKLAS="Klaipėdos regiono tinklas",
                    OBJ_NUMERIS=48738140,
                    PL_T=DateTime.Now,
                    PMinus=(decimal)1.7193,
                    PPlus=(decimal)2

                }
            };

            var result = service.AgregateRetrivedData(measurements).Result;
            Assert.Equal((decimal)3.0386, result.FirstOrDefault().PMinus);
            Assert.Equal(9, result.FirstOrDefault().PPlus);

        }

    }
}