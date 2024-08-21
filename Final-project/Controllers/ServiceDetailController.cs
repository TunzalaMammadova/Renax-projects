using System;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class ServiceDetailController : Controller
    {
        private readonly ITransferService _transfer;


        public ServiceDetailController(ITransferService transfer)
        {
            _transfer = transfer;

        }

        public async Task<IActionResult> Index(int? id)
        {
            List<Service> services = await _transfer.GetAllAsync();
            Service transfer = await _transfer.GetByIdAsync((int)id);


            HomeVM model = new()
            {
                Service = transfer,
                Services = services
                
            };

            return View(model);
        }
    }
}


