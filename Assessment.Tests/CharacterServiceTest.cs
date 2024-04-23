using Assessment.Model;
using Assessment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Tests
{
    public class CharacterServiceTest
    {
        private readonly CharacterService _characterService;
        public CharacterServiceTest()
        {
            _characterService = new CharacterService();
        }

        [Fact]
        public void GetAllCharacterGivenValidRequestGetResult()
        {
            //Act
            var result = _characterService.GetAllCharacter();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddCharacterGivenValidRequestNewCharacterAddedSuccess()
        {
            //Arrange
            var newCharacter = new Character
            {
                Id = 4,
                Name = "Test Character",
            };

            //Act
            var result = _characterService.AddCharacter(newCharacter);

            //Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data.FirstOrDefault(c => c.Id == 4));
        }

        [Fact]
        public void AddCharacterGivenValidRequestExistingCharacterAddedFailure()
        {
            //Arrange
            var existingCharacter = new Character
            {
                Id = 1,
                Name = "Gollum"
            };

            //Act
            var result = _characterService.AddCharacter(existingCharacter);

            //Assert
            Assert.False(result.Success);
            Assert.Equal("Character Already Exist", result.Message);
        }

        [Fact]
        public void GetCharacterByIdGivenValidRequestExistingCharacterSuccess()
        {
            //Act
            var result = _characterService.GetCharacterById(1);

            //Assert
            Assert.True(result.Success);
            Assert.Equal("Gollum",result.Data.Name);

        }
        [Fact]
        public void GetCharacterByIdGivenValidRequestNonExistingCharacterFailure()
        {
            //Act
            var result = _characterService.GetCharacterById(5);

            //Assert
            Assert.False(result.Success);
            Assert.Equal("Character Doesn't Exist", result.Message);

        }

        [Fact]
        public void UpdateCharacterGivenValidRequestExistingCharacterUpdated()
        {
            //Arrange
            var existingCharacter = new Character
            {
                Id = 2,
                Name = "Goku",
            };
            _characterService.AddCharacter(existingCharacter);

            var updateCharacter = new Character
            {
                Id = 2,
                Name = "Vageta",
            };

            //Act
            var result = _characterService.UpdateCharacter(updateCharacter);

            //Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data.FirstOrDefault(character => character.Name == "Vageta"));
        }

        [Fact]
        public void UpdateCharacterGivenInvalidRequestNonExistingCharacterUpdated()
        {
            // Arrange
            var updateCharacter = new Character
            {
                Id = 5, 
                Name = "Picollo",
            };

            // Act
            var serviceResponse = _characterService.UpdateCharacter(updateCharacter);

            // Assert
            Assert.False(serviceResponse.Success);
            Assert.Equal("Character Doesn't Exist", serviceResponse.Message);
        }

        [Fact]
        public void DeleteCharacterGivenInvalidRequestExistingCharacterDeleted()
        {
            // Arrange
            var characterService = new CharacterService();

            // Act
            var result = characterService.DeleteCharacter(1);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Data.FirstOrDefault(character => character.Id == 1));
        }

        [Fact]
        public void DeleteCharacterGivenInvalidRequestNonExistingCharacterDeleted()
        {
            // Arrange
            var characterService = new CharacterService();

            // Act
            var result = characterService.DeleteCharacter(4);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Character Doesn't Exist", result.Message);
        }
    }
}
