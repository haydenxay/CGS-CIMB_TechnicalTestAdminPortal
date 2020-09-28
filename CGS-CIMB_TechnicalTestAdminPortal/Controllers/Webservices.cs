using CGS_CIMB_TechnicalTestAdminPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CGS_CIMB_TechnicalTestAdminPortal.Controllers
{
    public class Webservices
    {
        public static string Baseurl = "https://localhost:44390/api/";

        public static List<ReportsDTO> GetDataReports()
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            var client = new HttpClient(hndlr) { BaseAddress = new Uri(Baseurl) };

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Reports").Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var datareport = JsonConvert.DeserializeObject< List<ReportsDTO>>(stringData);

            return datareport;
        }

        public static ReportsDTO GetDataReports(string id)
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            var client = new HttpClient(hndlr) { BaseAddress = new Uri(Baseurl) };

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("Reports").Result;
            var stringData = response.Content.ReadAsStreamAsync().Result;
            var datareport = JsonConvert.DeserializeObject<ReportsDTO>(stringData);

            return datareport;
        }

    }
}
