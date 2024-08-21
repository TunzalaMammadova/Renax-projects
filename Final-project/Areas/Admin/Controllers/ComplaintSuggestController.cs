using System.Data;
using Microsoft.AspNetCore.Mvc;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.Complaints;
using Final_project.Helpers.Enum;
using Microsoft.AspNetCore.Authorization;

namespace Final_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ComplaintSuggestController : Controller
    {
        private readonly IComplaintService _complaintService;

        public ComplaintSuggestController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var complaints = await _complaintService.GetAllAsync();

            var datas = complaints.Select(m => new ComplaintVM { Id = m.Id, UserEmail = m.UserEmail, UserPhone = m.UserPhone, Subject = m.Subject, UserFullName = m.UserFullName, UserSuggest = m.UserSuggest }).ToList();

            return View(datas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _complaintService.GetById((int)id);
            if (data is null) return NotFound();

            await _complaintService.Delete(data);
            return RedirectToAction(nameof(Index));
        }
    }
}