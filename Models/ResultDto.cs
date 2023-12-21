using swapi_project_backend.Objects;

namespace swapi_backend.Models
{
    public class ResultDto
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PeopleDto>? results { get; set; }
    }
}