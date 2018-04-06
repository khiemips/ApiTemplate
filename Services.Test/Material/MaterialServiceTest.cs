using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Common.Repositories;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Repository;
using Services.Materials;

namespace Services.Test.Material
{
    using Material = Entities.Materials.Material;

    [TestClass]
    public class MaterialServiceTest : UnitTestBase
    {
        #region Contractor

        static Mock<IRepository<Material>> _repository { get; set; }
        Mock<IServiceProvider> _serviceProvider { get; set; }

        public MaterialServiceTest()
        {
        }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        [TestInitialize()]
        public void TestInitialize()
        {
        }


        [TestCleanup()]
        public void TestCleanup()
        {
        }

        #endregion

        #region GetAll

        [TestMethod()]
        public void MaterialService_GetAll_Return_Empty_List_If_Not_Found()
        {
            //arrange
            var keyword = string.Empty;
            var service = CreateService();
            
            _repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Material, bool>>>())).Returns(Enumerable.Empty<Material>);

            //act
            var result = service.GetAll(keyword);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod()]
        public void MaterialService_GetAll_Return_List_Of_Material()
        {
            //arrange

            var keyword = "a";
            var materials = new List<Material>
            {
                new Material{ Id = "id1", Name = "abc"},
                new Material{ Id = "id2", Name = "ufab"},
            };

            var service = CreateService();
            
            _repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Material, bool>>>())).Returns(materials);

            //act
            var result = service.GetAll(keyword);

            //assert

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        #endregion

       
        private IMaterialService CreateService()
        {
            _repository = new Mock<IRepository<Material>>();

            _serviceProvider = new Mock<IServiceProvider>();
            _serviceProvider.Setup(x => x.GetService(typeof(IRepository<Material>))).Returns(_repository.Object);

            var service = new MaterialService(_serviceProvider.Object);

            return service;
        }
    }
}
