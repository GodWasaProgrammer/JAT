using Enums;

namespace JAT;

public class JobManager
{
    private List<JobApplication> Applications = [];

    public List<JobApplication> ReturnAllApplications()
    {
        return Applications;
    }

    public void AddApplication(JobApplication application)
    {
        Applications.Add(application);
    }

    public void UpdateStatus(JobApplication jobApplication, ApplicationStatus UpdatedStatus)
    {
        var res = Applications.Find(a => a == jobApplication);
        res?.UpdateStatus(UpdatedStatus);
    }

    public void ShowAll()
    {
        var res = Applications.Select(a => a.GetSummary()).ToList();
        foreach (var entry in res)
        {
            Console.WriteLine(entry);
        }
    }

    public void FilterByStatus(ApplicationStatus StatusToSearch)
    {
        var res = Applications.FindAll(a => a.Status == StatusToSearch);
        foreach (var entry in res)
        {
            Console.WriteLine(entry.GetSummary());
        }
        if (res.Count == 0)
        {
            Console.WriteLine("No applications found with that status.");
        }
    }

    public void SortByDate()
    {
        var res = Applications.OrderBy(a => a.GetDaysSinceApplied()).ToList();
        foreach (var entry in res)
        {
            Console.WriteLine(entry.GetSummary());
        }
    }

    public void ShowStatistics()
    {
        if (Applications.Count == 0)
        {
            Console.WriteLine("No job applications found.");
            return;
        }

        // total number
        int total = Applications.Count;

        // Group by status
        var byStatus = Applications
            .GroupBy(a => a.Status)
            .Select(g => new { Status = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

        // average salary
        double avgSalary = Applications.Average(a => a.SalaryExpectation);

        var OlderThan14Days = Applications.Count(a => a.GetDaysSinceApplied() > 14);

        // Newest application
        var latest = Applications.OrderByDescending(a => a.ApplicationDate).First();

        // Oldest application
        var oldest = Applications.OrderBy(a => a.ApplicationDate).First();

        // show results
        Console.WriteLine("=== Job Application Statistics ===\n");
        Console.WriteLine($"Total applications: {total}");
        Console.WriteLine($"Average requested salary: {avgSalary:F0} SEK\n");
    
        var responded = Applications.Where(a => a.ResponseDate != null).ToList();
        if (responded.Any())
        {
            var avgResponseDays = responded
                .Average(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);
            Console.WriteLine($"Average response time: {avgResponseDays:F1} days");
        }
        else
        {
            Console.WriteLine("Average response time: N/A (no responses yet)");
        }
        Console.WriteLine($"Applications older than 14 days:{OlderThan14Days}");

        Console.WriteLine("Applications by status:");
        foreach (var group in byStatus)
        {
            // Välj färg baserat på status
            switch (group.Status)
            {
                case ApplicationStatus.Accepted:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ApplicationStatus.Rejected:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.WriteLine($"  {group.Status}: {group.Count}");

            // Återställ färgen till standard
            Console.ResetColor();
        }



        Console.WriteLine($"\nNewest application: {latest.GetSummary()}");
        Console.WriteLine($"Oldest application: {oldest.GetSummary()}");
        ShowOlderThen14DaysAndNoResponse();
    }

    public void ShowOlderThen14DaysAndNoResponse()
    {
        var pendingOlderThan14Days = Applications.Where(a => a.ResponseDate == null && a.GetDaysSinceApplied() > 14)
                                                 .ToList();
        Console.WriteLine($"\nApplications without response older than 14 days: {pendingOlderThan14Days.Count}");

        foreach (var app in pendingOlderThan14Days)
        {
            Console.WriteLine($"  - {app.GetSummary()} ({app.GetDaysSinceApplied()} days ago)");
        }
    }

    public void RemoveJob(JobApplication jobApplication)
    {
        Applications.Remove(jobApplication);
    }
}
