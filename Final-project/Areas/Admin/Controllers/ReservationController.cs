using Final_project.Helpers.Enum;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _reservationService.GetAll();
            var reservations = datas.Select(m => new ReservationVM { Id = m.Id, UserEmail= m.AppUser.Email, OrderStatus = m.OrderStatus, CarName = m.Car.Name , ServiceName = m.Service.Name}).ToList();
            return View(reservations);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Accept(int? id)
        {
            if (id is null) return BadRequest();
            var existReserv = await _reservationService.GetById((int)id);
            if (existReserv is null) return NotFound();

            existReserv.OrderStatus = OrderStatus.Accepted;

            await _reservationService.Edit((int)id, existReserv);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Reject(int? id)
        {
            if (id is null) return BadRequest();
            var existReserv = await _reservationService.GetById((int)id);
            if (existReserv is null) return NotFound();

            existReserv.OrderStatus = OrderStatus.Rejected;

            await _reservationService.Edit((int)id, existReserv);
            return RedirectToAction("Index");
        }

    }
}

