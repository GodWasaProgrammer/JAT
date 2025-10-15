namespace Enums;

/// <summary>
/// Status of a job application
/// </summary>
public enum ApplicationStatus
{
    Applied,
    Interviewing,
    Offer,
    Rejected,
    Accepted
}

/// <summary>
/// Our main menu options
/// </summary>
public enum MenuSelect
{
    AddApplication,
    ShowAllApplications,
    FilterByStatus,
    SortByDate,
    ShowStatistics,
    ShowOlderThen14DaysAndNoResponse,
    UpdateStatus,
    RemoveApplication,
    ExitApplication,
}