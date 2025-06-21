using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using leave_tracker.Data;
using leave_tracker.Models;
using leave_tracker.Services;

namespace leave_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly LeaveService _leaveService;

        public LeaveController(LeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpPost("apply")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ApplyLeave([FromBody] LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _leaveService.ApplyLeaveAsync(leaveRequest);
            if (result)
            {
                return Ok("Leave request submitted successfully.");
            }

            return BadRequest("Failed to submit leave request.");
        }

        [HttpPost("approve/{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var result = await _leaveService.ApproveLeaveAsync(id);
            if (result)
            {
                return Ok("Leave request approved.");
            }

            return NotFound("Leave request not found or already processed.");
        }

        [HttpPost("decline/{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeclineLeave(int id)
        {
            var result = await _leaveService.DeclineLeaveAsync(id);
            if (result)
            {
                return Ok("Leave request declined.");
            }

            return NotFound("Leave request not found or already processed.");
        }

        [HttpGet("requests")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequests()
        {
            var leaveRequests = await _leaveService.GetLeaveRequestsAsync();
            return Ok(leaveRequests);
        }
    }
}