using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    //This is the interface 
    public interface ICharacterService
    {
        //Getting all the characters
        Task<ServiceResponse<List<Character>>> GetAllCharacters();

        //Method to get chracter by Id
        Task<ServiceResponse<Character>> GetCharacterById(int id);


        //Method for Adding the new Character - Passing the parameter as Character details..
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}
