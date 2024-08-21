﻿using System;
using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService _subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subscribers = await _subscriberService.GetAll();
            return View(subscribers);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var subscriber = await _subscriberService.GetById((int)id);
            if (subscriber is null) return NotFound();

            await _subscriberService.Delete(subscriber);
            return RedirectToAction(nameof(Index));
        }
    }
}

