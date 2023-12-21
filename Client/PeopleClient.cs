namespace swapi_backend.Client
{
    public class PeopleClient:HttpClient
    {
        BaseClass bc = new BaseClass();
        String url;
        public PeopleClient() {
            url = bc.getBaseUri() + "/people";
        }

        public async Task<HttpResponseMessage> getAllPeople(int pageNum)
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
        public async Task<HttpResponseMessage> getSpecificPerson(int num)
        {
            try
            {
                return await this.GetAsync($"{url}/{num}/");
            }
            catch (Exception)
            {
                throw new Exception("Request failed");
            }
        }

        public int GetCount(int result)
        {
            var count = 0;
            if(result%10 == 0)
            {
                count = result / 10;
            }
            else
            {
                count = (result / 10) + 1;
            }
            return count;
        }
    }
}
