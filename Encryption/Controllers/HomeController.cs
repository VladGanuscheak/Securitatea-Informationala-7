using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Encryption.Models;
using EncryptorSync.Encryptor.Interfaces;
using System.Web.Helpers;
using BackgroundScripts.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using MessageBroker.GenericRepository.Interfaces;
using Encryption.Domain.Models;
using Microsoft.AspNet.Http;

namespace Encryption.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEncryptor _encryptor;
        private readonly IBackgroundScripts _backgroundScripts;
        private readonly IGenericRepositoryAsync<ApplicationUser> _repository;

        private static string sysUser = string.Empty;

        public HomeController(IEncryptor encryptor, IBackgroundScripts backgrounfScripts, 
            IGenericRepositoryAsync<ApplicationUser> repository)
        {
            _encryptor = encryptor;
            _backgroundScripts = backgrounfScripts;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(new PasswordModel());
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(PasswordModel model)
        //{
        //    await _backgroundScripts.BanDomain(model.Domain);
        //    ViewBag.Result = $@"Hello, {model?.Name ?? "Unnamed"} !";
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            //var result = new StringBuilder();
            //using (var reader = new StreamReader(file.OpenReadStream()))
            //{
            //    while (reader.Peek() >= 0)
            //        result.AppendLine(reader.ReadLine());
            //}

            using (var stream = new FileStream($"C:\\temp\\TempFiles\\{file.FileName}", FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            try
            {
                var content = await _encryptor.DecryptFromFileAsync($"C:\\temp\\TempFiles\\{file.FileName}");
                var userName = $"{content.Split()[0]} {content.Split()[1]}";
                var password = content.Split()[2];
                var user = await _repository.GetListAsync(x => x.Name.ToLower() == userName.ToLower() && x.Password == password);
                if (user.Count() == 1)
                {
                    ViewBag.Result = $@"Hello, {userName} !";
                }
                sysUser = userName;
            }
            catch(Exception exception)
            {
                sysUser = string.Empty;
                ViewBag.Result = $@"Error!!!";
                Debug.WriteLine(exception.Message);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BanDomain(string domain)
        {
            if (sysUser != string.Empty)
            {
                await _backgroundScripts.BanDomain(domain);
                ViewBag.Result = $@"Dear {sysUser}, you have blocked the {domain}!";
            }
            else ViewBag.Result = "You need to authenticate!";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UnbanDomain(string domain)
        {
            if (sysUser != string.Empty)
            {
                await _backgroundScripts.UnbanDomain(domain);
                ViewBag.Result = $@"Dear {sysUser}, you have unblocked the {domain}!";
            }
            else ViewBag.Result = "You need to authenticate!";

            return RedirectToAction("Index", "Home");
        }
    }
}
