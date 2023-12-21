namespace swapi_backend.Client
{
    public class PlanetClient:BaseClass
    {
        String url;
        public PlanetClient()
        {
            url = this.getBaseUri() + "/planets";
        }
        public async Task<HttpResponseMessage> getAllFilms(int pageNum)
        {
            try
            {
                return await this.GetAsync($"{url}/?page={pageNum}");
            }
            catch (Exception)
            {
                throw new Exception("Request failed");
            }
        }
        
    }
}
