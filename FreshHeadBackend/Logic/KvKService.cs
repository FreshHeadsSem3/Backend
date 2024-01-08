using FreshHeadBackend.Interfaces;
using static System.Net.WebRequestMethods;

namespace FreshHeadBackend.Logic
{
    public class KvKService : IKvKService
    {
        private readonly string baseUrl = "https://api.kvk.nl/test/api/v1/zoeken";
        private readonly string apiKey = "l7xx1f2691f2520d487b902f4e0b57a0b197";

        public async Task<bool> VerifyKvKNumber(string kNumber)
        {
            if (kNumber.Length != 8)
            {
                return false;//handle error
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("ApiKey", $"{apiKey}");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                var requestUrl = $"{baseUrl}?kvkNummer={kNumber}&pagina=1&aantal=10";

                try
                {
                    var response = await httpClient.GetAsync(requestUrl);
                    Console.WriteLine(response.StatusCode);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return false;
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
                catch (HttpRequestException ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
