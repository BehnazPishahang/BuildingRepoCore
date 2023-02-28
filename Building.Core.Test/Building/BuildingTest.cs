using Application.Building;
using Moq;
using ServiceModel.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers.Building;
using Xunit;

namespace Building.Core.Test.Building
{
    public class BuildingTest
    {

        private readonly Mock<Application.UnitOfWork.IUnitOfWork> _unitOfWork = new();
        private readonly BuildingController controller;

        public BuildingTest()
        {
            controller = new BuildingController(_unitOfWork.Object);

        }

        [Fact]
        public async Task Building_RequestIsNull_ShouldReturnRequestIsNullOrCorrupt()
        {

            //Arrange

            BuildingRequest request=new BuildingRequest();
            request=null;

            //Act
            _unitOfWork.Setup(repo => repo.Repositorey<IBuildingRepository>().GetById(It.IsAny<Guid>()))
                     .ReturnsAsync((Domain.Building.Building)null);

            var result = await controller.GetById(request);

            //Assert

            Assert.Equal(result.Result.Code,-101);
        }

        [Fact]
        public async Task Building_TheBuildingContractIsNull_ShouldReturnRequestIsNullOrCorrupt()
        {

            //Arrange

            BuildingRequest request = new BuildingRequest();
            request.theBuildingContract = null;

            //Act
            _unitOfWork.Setup(repo => repo.Repositorey<IBuildingRepository>().GetById(It.IsAny<Guid>()))
                     .ReturnsAsync((Domain.Building.Building)null);

            var result = await controller.GetById(request);

            //Assert

            Assert.Equal(result.Result.Code, -101);
        }

        [Fact]
        public async Task Building_IdIsNotValid_ShouldReturnRequestIsNullOrCorrupt()
        {

            //Arrange

            BuildingRequest request = new BuildingRequest();
            Guid NewID = new Guid();
            request.theBuildingContract.Id = NewID;

            //Act
            _unitOfWork.Setup(repo => repo.Repositorey<IBuildingRepository>().GetById(It.IsAny<Guid>()))
                     .ReturnsAsync((Domain.Building.Building)null);

            var result = await controller.GetById(request);

            //Assert

            Assert.Equal(result.Result.Code, -102);
        }
    }
}
