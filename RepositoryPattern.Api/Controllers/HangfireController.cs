using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public HangfireController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult GetUser()
        {
            var result = _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("RetrieveDataFromAPI")]
        public void RetrieveDataFromAPI()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts"); 

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<UserDTO> items = (List<UserDTO>)JsonConvert.DeserializeObject(jsonString, typeof(List<UserDTO>));
            _userService.Add(items[0]);
            Console.WriteLine(items);
            Console.WriteLine($"API'den data alındı.");
        }

        [HttpGet]
        [Route("RetrieveData")]
        public IActionResult RetrieveData()
        {
            RecurringJob.AddOrUpdate(() => RetrieveDataFromAPI(), _config.GetConnectionString("CronTime"));
            return Ok();
        }
    }
}