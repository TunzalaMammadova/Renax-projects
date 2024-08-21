﻿using Final_project.Models;
using Final_project.Services.Interfaces;
using Final_project.ViewModels.HeaderVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly UserManager<AppUser> _userManager;

        public HeaderViewComponent(ISettingService settingService,
                                   UserManager<AppUser> userManager)
        {
            _settingService = settingService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _settingService.GetAll();

            Dictionary<string, string> values = new();

            foreach (KeyValuePair<int, Dictionary<string, string>> item in setting)
            {
                values.Add(item.Value["Key"], item.Value["Value"]);
            }

            HeaderVM response = new()
            {
                Settings = values,
            };


            AppUser user = new();

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            return await Task.FromResult(View(response));
        }
    }
}

