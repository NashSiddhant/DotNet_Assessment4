using Assessment.Controllers;
using Assessment.Model;
using Assessment.Service;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Tests
{
    public class CharacterControllerTest
    {
        [Fact]
        public void GetCharacterGivenValidRequestGetResult()
        {
            //Arrange
            var cList = new List<Character>()
            {
                new Character(),
                new Character() { Name = "Gollum", Id = 1 },
            };

            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = cList
            };

            var mockService = new Mock<ICharacterService>();

            mockService.Setup(x => x.GetAllCharacter()).Returns(serviceResponse);

            var charController = new CharacterController(mockService.Object);

            //Act
            var result = charController.GetCharacter();
            var okResult = (ObjectResult)result.Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

        }
        [Fact]
        public void PutCharacterGivenValidRequestGetResult()
        {
            // Arrange
            var mockService = new Mock<ICharacterService>();
            var charController = new CharacterController(mockService.Object);
            var updatedCharacter = new Character
            {
                Id = 2,
                Name = "Vageta",
            };
            var serviceResponse = new ServiceResponse<List<Character>>
            {
                Success = true,
                Data = new List<Character> { updatedCharacter }
            };
            mockService.Setup(x => x.UpdateCharacter(updatedCharacter)).Returns(serviceResponse);

            // Act
            var result = charController.UpdateCharacter(updatedCharacter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedServiceResponse = Assert.IsType<ServiceResponse<List<Character>>>(okResult.Value);
            Assert.True(returnedServiceResponse.Success);
            Assert.Equal("Vageta", returnedServiceResponse.Data[0].Name);
        }
        [Fact]
        public void DeleteCharacterGivenValidRequestGetResult()
        {
            // Arrange
            var mockCharacterService = new Mock<ICharacterService>();
            var controller = new CharacterController(mockCharacterService.Object);
            var id = 1;
            var serviceResponse = new ServiceResponse<List<Character>>
            {
                Success = true,
                Data = new List<Character>() 
            };
            mockCharacterService.Setup(service => service.DeleteCharacter(id)).Returns(serviceResponse);

            // Act
            var result = controller.DeleteCharacter(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedServiceResponse = Assert.IsType<ServiceResponse<List<Character>>>(okResult.Value);
            Assert.True(returnedServiceResponse.Success);
        }
    }
}
