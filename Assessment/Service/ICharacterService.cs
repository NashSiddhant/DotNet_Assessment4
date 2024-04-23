using Assessment.Model;

namespace Assessment.Service
{
    public interface ICharacterService
    {
        ServiceResponse<List<Character>> GetAllCharacter();

        ServiceResponse<List<Character>> AddCharacter(Character newCharacter);

        ServiceResponse<List<Character>> UpdateCharacter(Character updateCharacter);
        ServiceResponse<List<Character>> DeleteCharacter(int id);
        ServiceResponse<List<Character>> GetCharacterById(int id);

    }
}
