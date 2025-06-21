using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using leave_tracker.Data;
using leave_tracker.Models;

namespace leave_tracker.Services
{
    public class LeaveService
    {
        private readonly ApplicationDbContext _context;

        public LeaveService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsByUserId(int userId)
        {
            return await _context.LeaveRequests
                .Where(lr => lr.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetAllLeaveRequests()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<bool> ApproveLeaveRequest(int id)
        {
            var leaveRequest = await GetLeaveRequestById(id);
            if (leaveRequest == null) return false;

            leaveRequest.Status = "Approved";
            await UpdateLeaveRequest(leaveRequest);
            return true;
        }

        public async Task<bool> DeclineLeaveRequest(int id)
        {
            var leaveRequest = await GetLeaveRequestById(id);
            if (leaveRequest == null) return false;

            leaveRequest.Status = "Declined";
            await UpdateLeaveRequest(leaveRequest);
            return true;
        }
    }
}