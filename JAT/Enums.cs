namespace Enums;

public enum ApplicationStatus
{
    Applied,
    Interviewing,
    Offer,
    Rejected,
    Accepted
}

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