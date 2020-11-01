using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fptRecruitingExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FptController : ControllerBase
    {
        private readonly IDataService _dataService;

        public FptController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        [Route("getCustomers")]
        public async Task<IActionResult> Customers(Pager pager)
        {
            var customerList = await _dataService.CustomerList(pager);
            return Ok(customerList);
        }

    }
}
