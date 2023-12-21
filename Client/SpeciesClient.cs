namespace swapi_backend.Client
{
    public class SpeciesClient:BaseClass
    {
        String url;
        public SpeciesClient()
        {
            url = this.getBaseUri() + "/species";
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
