using DocumentFormat.OpenXml.Wordprocessing;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController] //-- Attribute
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {


        private readonly ICharacterService _characterService;


        //Contructer -->  we have passed the Interface in the parameter and its implemented class
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async  Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            //Called the GetAllCharacters method from implemented class - CharacterService
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {

            //Called the GetCharacterById(id) method from implemented class - CharacterService
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddChracter(AddCharacterDto newCharacter)
        {
            //Called the AddCharacter(newCharacter) method from implemented class - CharacterService
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
