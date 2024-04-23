using Assessment.Model;

namespace Assessment.Service
{
    public class CharacterService
    {
        private static List<Character> _characterList = new List<Character>()
        {
            new Character(),
            new Character(){Name = "Gollum", Id = 1},
        };


        public ServiceResponse<List<Character>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = _characterList
            };
            return serviceResponse;
        }

        public ServiceResponse<List<Character>> AddCharacter(Character newCharacter)
        {
            var oldcharacter = _characterList.FirstOrDefault(c => c.Id == newCharacter.Id);

            var serviceResponse = new ServiceResponse<List<Character>>();

            if (oldcharacter == null)
            {
                _characterList.Add(newCharacter);
                serviceResponse.Data = _characterList;
                serviceResponse.Success = true;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character Already Exist";
            }


            return serviceResponse;

        }

        public ServiceResponse<Character> GetCharacterById(int id)
        {
            var character = _characterList.FirstOrDefault(c => c.Id == id);

            var serviceResponse = new ServiceResponse<Character>();

            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character Doesn't Exist";

                return serviceResponse;
            }

            serviceResponse.Data = character;

            return serviceResponse;
        }

          public ServiceResponse<List<Character>> UpdateCharacter(Character updatedCharacter)
        {
            Character oldCharacter = _characterList.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            var serviceResponse = new ServiceResponse<List<Character>>();
            if (oldCharacter != null)
            {
                oldCharacter.Name = updatedCharacter.Name;
                oldCharacter.HitPoint = updatedCharacter.HitPoint;
                oldCharacter.Strength = updatedCharacter.Strength;
                oldCharacter.Defense = updatedCharacter.Defense;
                oldCharacter.Intelligence = updatedCharacter.Intelligence;
                oldCharacter.CharacterClass = updatedCharacter.CharacterClass;
                serviceResponse.Data = _characterList;
                serviceResponse.Success = true;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character Doesn't Exist";
            }
            return serviceResponse;
        }

        public ServiceResponse<List<Character>> DeleteCharacter(int id)
        {
            Character removeCharacter = _characterList.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<List<Character>>();
            if (removeCharacter != null)
            {
                _characterList.Remove(removeCharacter);
                serviceResponse.Data = _characterList;
                serviceResponse.Success = true;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character Doesn't Exist";
            }
            return serviceResponse;
        }
    }
}
