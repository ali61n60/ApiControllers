﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    public class HomeController:Controller
    {
        private Model.IRepository repository { get; set; }
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Reservations);
        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}
