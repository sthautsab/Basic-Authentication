using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace Basic_Authentication.Controllers
{
    public class basicMvcController : Controller
    {
        // GET: basicMvc
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            List<string> list = new List<string>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes("Utsab:shrestha")));
            var dynamicUrl = Request.Url.ToString();
            string trimmedUrl = dynamicUrl.Replace("basicmvc", "api/");
            client.BaseAddress = new Uri(trimmedUrl);
            var response = client.GetAsync("Values");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var display = result.Content.ReadAsAsync<List<string>>();
                display.Wait();
                list = display.Result;
                ViewBag.message = list;
                //ViewData["message"] = list;
                return View("Index", list);
            }
            else
            {
                List<string> list1 = new List<string>();
                string message = Convert.ToString(result.StatusCode);
                list1.Add(message);
                //ViewBag.message = message;
                return View("Index", list1);
            }

        }
    }
}