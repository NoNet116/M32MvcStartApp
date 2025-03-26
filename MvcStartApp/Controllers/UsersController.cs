﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repositories;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

       
        public async Task <ActionResult> Users()
        {
            var authors = await _repo.GetUsers();
            return View(authors.OrderByDescending(x => x.JoinDate));
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.Register(newUser);
            return View(newUser);
        }

    }
}
