namespace swapi_backend.Client
{
    public class StarshipClient:BaseClass
    {
        String url;
        public StarshipClient()
        {
            url = this.getBaseUri() + "/starships";
        }
        public async Task<HttpResponseMessage> getAllSpecies(int pageNum)
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
