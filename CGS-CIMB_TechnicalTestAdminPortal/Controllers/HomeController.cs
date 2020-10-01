using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CGS_CIMB_TechnicalTestAdminPortal.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CGS_CIMB_TechnicalTestAdminPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static string Baseurl = "https://localhost:44390/api/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var reports = Webservices.GetDataReports();
            return View(reports);
        }

        [Authorize]
        public IActionResult Privacy(string id)
        {
            string localFilePath;

            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            var client = new HttpClient(hndlr) { BaseAddress = new Uri(Baseurl) };

            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("Reports/" + id).Result;

            localFilePath = response.Content.Headers.ContentDisposition.FileNameStar;

            var stream = new FileStream(localFilePath, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
