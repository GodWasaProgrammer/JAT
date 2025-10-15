using Enums;

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

    public string? CompanyName { get; set; }
    public string? PositionTitle { get; set; }

    public ApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public int SalaryExpectation { get; set; }

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

