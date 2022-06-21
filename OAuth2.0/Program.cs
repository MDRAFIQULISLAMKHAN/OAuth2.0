using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace OAuth2._0
{
    class Program
    {


        static void Main(string[] args)
        {
             string GetToken()
            {
                string url = "https://int-testing-dmuo4ily.authentication.eu10.hana.ondemand.com/oauth/token";
                string userName = "sb-cf28d5ff-2906-4a80-867c-38747a3439c2!b134988|it-rt-int-testing-dmuo4ily!b117912";
                string password = "50ee8a69-3abb-4054-add0-49863e1c1db7$GkY9oUC0LRGS1whFe2gxgSViQUtazYr7oqJoc-LjuZU=";
                url = string.Format(url, "");
                //var nvc = new List<string>();
                //nvc.Add(userName);
                //nvc.Add(password);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("OAuthValidationUser", userName));
                nvc.Add(new KeyValuePair<string, string>("OAuthValidationPass", password));
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(nvc)).Result;
                    string tokenString = response.Content.ReadAsStringAsync().Result;

                    dynamic data = JsonConvert.DeserializeObject<dynamic>(tokenString);


                    return data != null ? data.access_token : string.Empty;
                }

            }
        }
    }
}
