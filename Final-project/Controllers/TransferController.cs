using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class TransferController : Controller
	{
        private readonly ITransferService _transfer;

        public TransferController(ITransferService transfer)
        {
            _transfer = transfer;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _transfer.GetAllAsync();

            HomeVM model = new()
            {
                Services = services
            };

            return View(model);
        }
    }
}

