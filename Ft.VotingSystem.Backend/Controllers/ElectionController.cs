using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ft.VotingSystem.Backend.Controllers
{
    [Route("api/[controller]")]
    public class ElectionsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            return await Task.FromResult(new OkResult());
        }
    }
}
