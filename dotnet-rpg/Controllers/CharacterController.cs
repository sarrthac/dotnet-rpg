using DocumentFormat.OpenXml.Wordprocessing;
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
        public async  Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            //Called the GetAllCharacters method from implemented class - CharacterService
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {

            //Called the GetCharacterById(id) method from implemented class - CharacterService
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddChracter(Character newCharacter)
        {
            //Called the AddCharacter(newCharacter) method from implemented class - CharacterService
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}
