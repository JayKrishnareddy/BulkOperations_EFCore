using BulkOperations_EFCore.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkOperations_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkOperationsController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public BulkOperationsController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost(nameof(AddBulkData))]
        public async Task<IActionResult> AddBulkData()
        {
            var response = await _employeeService.AddBulkDataAsync();
            return Ok(response);
        }
        [HttpPut(nameof(UpdateBulkData))]
        public async Task<IActionResult> UpdateBulkData()
        {
            var response = await _employeeService.UpdateBulkDataAsync();
            return Ok(response);
        }
        [HttpDelete(nameof(DeleteBulkData))]
        public async Task<IActionResult> DeleteBulkData()
        {
            var response = await _employeeService.DeleteBulkDataAsync();
            return Ok(response);
        }
    }
}
