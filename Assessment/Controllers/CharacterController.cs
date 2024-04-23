using Assessment.Model;
using Assessment.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<ServiceResponse<List<Character>>> GetCharacter()
        {
            return Ok(_characterService.GetAllCharacter());
        }


        [HttpGet("id")]
        public ActionResult<ServiceResponse<Character>> GetId(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<ServiceResponse<Character>> PostCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public ActionResult<ServiceResponse<Character>> UpdateCharacter(Character Character)
        {
            return Ok(_characterService.UpdateCharacter(Character));
        }

        [HttpDelete]
        public ActionResult<ServiceResponse<Character>> DeleteCharacter(int id)
        {
            return Ok(_characterService.DeleteCharacter(id));
        }
    }
}
