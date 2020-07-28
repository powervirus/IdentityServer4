using ABACClient.myCustom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABACClient.Controllers
{
    [PowerAuthorize("Usermanagement")]
    public class UserController:Controller
    {
        public UserController() { }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [PowerAuthorize("Usermanagement_Edit")]
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [PowerAuthorize("Usermanagement_Delete")]
        public async Task<IActionResult> Delete()
        {
            return View();
        }
        [PowerAuthorize("Usermanagement_Add")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

    }
}
