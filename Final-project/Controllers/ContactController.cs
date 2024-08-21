using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels;
using Final_project.ViewModels.HeaderVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
	public class ContactController : Controller
    {
        private readonly ISettingService _setting;
        private readonly UserManager<AppUser> _userManager;
        private readonly IComplaintService _complaintService;


        public ContactController(ISettingService setting, UserManager<AppUser> userManager, IComplaintService complaintService)
        {
            _setting = setting;
            _userManager = userManager;
            _complaintService = complaintService;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = new();

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            var setting = await _setting.GetAll();

            Dictionary<string, string> values = new();

            foreach (KeyValuePair<int, Dictionary<string, string>> item in setting)
            {
                values.Add(item.Value["Key"], item.Value["Value"]);
            }

            HomeVM response = new()
            {
                Settings = values,
                UserEmail = user.Email,
                UserFullName = user.FullName,
                
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSuggestion(string userFullName, string userEmail, string suggestion,string phoneNumber, string subject)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Problem();
            }
            await _complaintService.Create(new ComplaintSuggest { UserEmail = userEmail, UserFullName = userFullName, UserSuggest = suggestion, Subject = subject, UserPhone = phoneNumber });

            return Ok();
        }

    }
}

