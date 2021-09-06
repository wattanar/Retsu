using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Modules.User.Dto;
using Web.Modules.User.Interfaces;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;

        public IndexModel(ILogger<IndexModel> logger,
        IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public void OnGet()
        {

        }
    }
}
