using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationData;
using NUnit;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class TrouserHemmingRepositoryTests
    {
        private TrouserHemmingRepository _trouserHemmingRepository;

        [SetUp]
        public void Init()
        {
            _trouserHemmingRepository = new TrouserHemmingRepository(Configuration.ProductDbConnectionString);
        }

        [Test]
        public void GetProductCodeTest()
        {
            // Act 
            var productCode = _trouserHemmingRepository.GetProductCode();

            // Assert
            Assert.IsNotEmpty(productCode);
        }
    }
}
