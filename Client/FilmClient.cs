namespace swapi_backend.Client
{
    public class FilmClient : BaseClass
    {
        String url;
        public FilmClient()
        {
            url = this.getBaseUri() + "/films";
        }
        public async Task<HttpResponseMessage> getAllFilms()
        {
            try
            {
                return await this.GetAsync($"{url}");
            }
            catch (Exception)
            {
                throw new Exception("Request failed");
            }
        }
    }
}
