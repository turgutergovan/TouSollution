﻿using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcContact.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IRepositoryPerson _repository = RepositoryFactory.CreateRepo("PERSON");
            List<Person> liste =_repository.List();
            

            //basit haliyle model görüntüleme
            //KisiTest mdl = new KisiTest() { Soyad="Ad",Ad="Soyad"};
            //mdl.Ad = "Turgut";
            //mdl.Soyad = "Ergovan";
            return View(liste);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            IRepositoryPerson repositoryPerson = new PersonRepositoryJson();
            repositoryPerson.AddOrUpdate(person);
            return RedirectToAction("Index");
            

    
        }


        public IActionResult Privacy(KisiTest kisi)
        {
            return View(kisi);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
