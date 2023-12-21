namespace swapi_backend.Client
{
    public class VehicleClient:BaseClass
    {
        String url;
        public VehicleClient()
        {
            url = this.getBaseUri() + "/vehicles";
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
