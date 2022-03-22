using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    //This is the interface 
    public interface ICharacterService
    {
        //Getting all the characters
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

        //Method to get chracter by Id
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);


        //Method for Adding the new Character - Passing the parameter as Character details..
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        //Method for updating the Character - 
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);

        //Method for deleting  the characters
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);


    }
}
