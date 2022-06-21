using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Threading.Tasks;
using System.Linq;

namespace OAuth_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            //var token = GetToken();
            var country = new List<CountryCodes>() {
                new CountryCodes(){ LanguageCode = "En", CountryCode="AF",CountryShort="Afghanistan",Name="Afghanistan",IdentiFicationCode ="101",CountryPhoneCode= "+93",IsDisabled=0},
                new CountryCodes(){ LanguageCode = "En", CountryCode="AL",CountryShort="Albania",Name="Albania",IdentiFicationCode ="102",CountryPhoneCode= "+355",IsDisabled=0},
                new CountryCodes(){ LanguageCode = "En", CountryCode="DZ",CountryShort="Algeria",Name="Algeria",IdentiFicationCode ="103",CountryPhoneCode= "+213",IsDisabled=0},
                new CountryCodes(){ LanguageCode = "En", CountryCode="AD",CountryShort="Andorra",Name="Andorra",IdentiFicationCode ="104",CountryPhoneCode= "+376",IsDisabled=0},
                new CountryCodes(){ LanguageCode = "En", CountryCode="BD",CountryShort="Bangladesh",Name="Bangladesh",IdentiFicationCode ="104",CountryPhoneCode= "+880",IsDisabled=0}
            };

            var phoneNumber = "+8801521210694";
            var phoneCode = "+880";
            var CountryShort = "Bangladesh";
            //phoneNumber = phoneNumber.Replace(phoneCode, "");

            //if (phoneNumber.ToLower().Contains('+')) {

            //    List<string> countries_list = new List<string>();
            //    countries_list.Add("+1");
            //    countries_list.Add("+91");
            //    countries_list.Add("+880");

            //    foreach (var countryitem in countries_list)
            //    {
            //        phoneNumber = phoneNumber.Replace(countryitem, "");

            //    }
            //}

            //var pChountryCode = country.FindAll(x => x.CountryShort.Equals(CountryShort));


            //var item = pChountryCode.Select(l => l.CountryPhoneCode).ToList();


            var item = from i in country where CountryShort == "Bangladesh" select i; 
            Console.WriteLine();

            Console.ReadKey();

        }
        public string RemoveCountryCode()
        {
            string phonenumber = "+91123123123";

            List<string> countries_list = new List<string>();
            countries_list.Add("+1");
            countries_list.Add("+91");

            foreach (var country in countries_list)
            {
                phonenumber = phonenumber.Replace(country, "");

            }

            return phonenumber;
        }
        private static string GetToken()
        {
            string baseAddress = "https://int-testing-dmuo4ily.authentication.eu10.hana.ondemand.com/oauth/token";

            string grant_type = "client_credentials";
            string client_id = "sb-cf28d5ff-2906-4a80-867c-38747a3439c2!b134988|it-rt-int-testing-dmuo4ily!b117912";
            string client_secret = "50ee8a69-3abb-4054-add0-49863e1c1db7$GkY9oUC0LRGS1whFe2gxgSViQUtazYr7oqJoc-LjuZU=";

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                };
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync(baseAddress, new FormUrlEncodedContent(form)).Result;
                string tokenString = response.Content.ReadAsStringAsync().Result;

                dynamic data = JsonConvert.DeserializeObject<dynamic>(tokenString);


                return data != null ? data.access_token : string.Empty;
            }

        }
    }
}
