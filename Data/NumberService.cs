using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace tarea2.Data
{
    public class NumberService
    {
        public async Task<string> GetNumAsync(int Num)
        {
            string url = $"https://nal.azurewebsites.net/api/NAL?num={Num}";
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            
                            if (data != null)
                            {
                                var dataObj = JObject.Parse(data);

                                return dataObj["letras"].ToString();
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
