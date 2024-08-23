using System;
using Final_project.Data;
using Final_project.Helpers.Enum;
using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Final_project.ViewModels.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class CarDetailController : Controller
    {
        private readonly ICarService _carService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReservationService _reservationService;
        private readonly ITransferService _transferService;


        public CarDetailController(ICarService car,UserManager<AppUser> userManager, IReservationService reservationService,ITransferService transferService)
        {
            _carService = car;
            _userManager = userManager;
            _reservationService = reservationService;
            _transferService = transferService;
        }


        public async Task<IActionResult> Index(int? id)
        {
            Car car = await _carService.GetByIdAsync((int)id);
            var reservDates = await _reservationService.GetAll();
            ViewBag.Services = await _transferService.GetAllBySelectAsync();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserEmail = user.Email;
            }

            HomeVM model = new()
            {
                Car = car,
                ReservDates = reservDates.Where(m => m.CarId == (int)id && m.OrderStatus == OrderStatus.Accepted).Select(m => new ViewModels.Cars.ReservDatesVM { StartDate = m.StartDate.AddMonths(-1).ToString("yyyy,MM,dd"), EndDate = m.EndDate.AddMonths(-1).ToString("yyyy,MM,dd") }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(OrderVM request)
        {
            var car = await _carService.GetByIdAsync(request.CarId);
            var startDate = Convert.ToDateTime(request.StartDate);
            var endDate = Convert.ToDateTime(request.EndDate);

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (request is not null)
                {

                    Reservation reservation = new()
                    {
                        CarId = car.Id,
                        AppUserId = user.Id,
                        EndDate = endDate,
                        ServiceId = request.ServiceId,
                        StartDate = startDate,
                        OrderStatus = OrderStatus.Pending
                    };

                    await _reservationService.Create(reservation);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            if (car is null) return NotFound();

            return Ok();
        }
    }
}

