using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using swapi_backend.Client;
using swapi_project_backend.Objects;
using Newtonsoft.Json;
using swapi_backend.Models;

namespace swapi_backend.Controllers
{
    [EnableCors("_allowSpecificOrigin")]
    [Route("api")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController() { }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<PeopleDto>>> GetList()
        {
            try
            {
                using PeopleClient client = new PeopleClient();
                var count = 0;
                List<CharacterNameDto> characterList = new List<CharacterNameDto>();
                var response = await client.getAllPeople(1);
                if (response == null)
                {
                    return NotFound(response);
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseObjects = JsonConvert.DeserializeObject<ResultDto>(responseBody);
                    if(responseObjects == null)
                    {
                        throw new Exception("Error deserializing json objects");
                    }
                    else
                    {
                        if (responseObjects.results == null)
                        {
                            throw new Exception("Error parsing list of characters");
                        }
                        else
                        {
                            foreach (PeopleDto person in responseObjects.results)
                            {
                                CharacterNameDto cName = new CharacterNameDto();
                                cName.name = person.name;
                                characterList.Add(cName);
                            }
                            count = client.GetCount(responseObjects.count);
                            for (int i = 2; i <= count; i++)
                            {
                                var loopResponse = await client.getAllPeople(i);
                                if (loopResponse == null)
                                {
                                    break;
                                }
                                else
                                {
                                    var loopResponseBody = await loopResponse.Content.ReadAsStringAsync();
                                    var loopResponseObjects = JsonConvert.DeserializeObject<ResultDto>(loopResponseBody);
                                    if (loopResponseObjects == null)
                                    {
                                        throw new Exception("Error deserializing json objects in loop");
                                    }
                                    else
                                    {
                                        if (loopResponseObjects.results == null)
                                        {
                                            throw new Exception("Error parsing list of characters in loop");
                                        }
                                        else
                                        {
                                            foreach(PeopleDto person in loopResponseObjects.results)
                                            {
                                                CharacterNameDto cName = new CharacterNameDto();
                                                cName.name = person.name;
                                                characterList.Add(cName);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    
                }
                return Ok(characterList);
            }
            catch (Exception)
            {
                throw new Exception("Failed to fetch list");
            }
        }
    }
}
