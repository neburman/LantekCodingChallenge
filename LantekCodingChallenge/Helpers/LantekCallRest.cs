using Newtonsoft.Json;
using System.Text;

namespace LantekCodingChallenge.Helpers
{
    public class LantekCallRest<Data, Response> where Data : class where Response : new()
    {

        public async Task<Response?> CallRestAsync(string url, string method, string authToken, Data? jsonData = null)
        {
            Response? responseObj = new();
            try
            {
                string serializedData = JsonConvert.SerializeObject(jsonData);

                using HttpClient httpClient = new();
                using var request = new HttpRequestMessage(new HttpMethod(method), url);

                if (jsonData != null)
                {
                    request.Content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add("Authorization", $"Basic {authToken}");
                }

                using var response = await httpClient.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();

                responseObj = JsonConvert.DeserializeObject<Response>(result)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                responseObj = default;
            }
            return responseObj;
        }
    }
}
