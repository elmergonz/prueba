using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace tarea2.Data
{
    public class UserService
    {
        public async Task<User> GetUserAsync()
        {
            string url = "https://randomuser.me/api/?results=1";
            
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
                                var dataObj = JObject.Parse(data)["results"][0];

                                return new User
                                {
                                    FirstName = dataObj["name"]["first"].ToString(),
                                    LastName = dataObj["name"]["last"].ToString(),
                                    Gender = dataObj["gender"].ToString(),
                                    Location = $"{dataObj["location"]["city"]}, {dataObj["location"]["country"]}",
                                    Email = dataObj["email"].ToString(),
                                    BirthDate = (DateTime) dataObj["dob"]["date"],
                                    Age = (int) dataObj["dob"]["age"],
                                    Phone = dataObj["phone"].ToString(),
                                    Picture = dataObj["picture"]["large"].ToString()
                                };
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
