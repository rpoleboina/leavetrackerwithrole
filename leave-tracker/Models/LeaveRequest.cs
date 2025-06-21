public class LeaveRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } // e.g., Pending, Approved, Declined
    public string Reason { get; set; }

    // Navigation property
    public virtual User User { get; set; }
}