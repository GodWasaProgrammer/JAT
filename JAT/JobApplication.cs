namespace JAT;

public class JobApplication
{
    string? CompanyName { get; set; }
    string? PositionTitle { get; set; }

    ApplicationStatus Status { get; set; }
    DateTime ApplicationDate { get; set; }
    DateTime ResponseDate { get; set; }
    int SalaryExpectation { get; set; }

    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - ApplicationDate).Days;
    }

    public string GetSummary()
    {
        return $"{PositionTitle} at {CompanyName}, applied on {ApplicationDate.ToShortDateString()}, current status: {Status}";
    }

}

public enum ApplicationStatus
{
    Applied,
    Interviewing,
    Offer,
    Rejected,
    Accepted
}
