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
        var color = Status switch
        {
            ApplicationStatus.Accepted => "\u001b[32m", // green
            ApplicationStatus.Rejected => "\u001b[31m", // red
            ApplicationStatus.Applied => "\u001b[33m", // yellow
            _ => "\u001b[37m" // vit/grå
        };

        var reset = "\u001b[0m";
        return $"{PositionTitle} at {CompanyName}, applied on {ApplicationDate.ToShortDateString()}, current status: {color}{Status}{reset} Requested Salary:{SalaryExpectation}";
    }

    public string UpdateStatus(ApplicationStatus updatedStatus)
    {
        Status = updatedStatus;
        return $"Status updated to {Status}";
    }

}

