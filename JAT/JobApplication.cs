namespace JAT;

public class JobApplication
{
    public JobApplication(string? companyName, string? positionTitle, ApplicationStatus status, DateTime applicationDate, int salaryExpectation)
    {
        CompanyName = companyName;
        PositionTitle = positionTitle;
        Status = status;
        ApplicationDate = applicationDate;
        SalaryExpectation = salaryExpectation;
    }

    private string? CompanyName { get; set; }
    private string? PositionTitle { get; set; }

    private ApplicationStatus Status { get; set; }
    private DateTime ApplicationDate { get; set; }
    private DateTime? ResponseDate { get; set; }
    private int SalaryExpectation { get; set; }

    

    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - ApplicationDate).Days;
    }

    public string GetSummary()
    {
        return $"{PositionTitle} at {CompanyName}, applied on {ApplicationDate.ToShortDateString()}, current status: {Status} Requested Salary:{SalaryExpectation}";
    }

    public string UpdateStatus(ApplicationStatus updatedStatus)
    {
        Status = updatedStatus;
        return $"Status updated to {Status}";
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
