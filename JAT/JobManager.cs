using Enums;
using System.Globalization;

namespace JAT;

public class JobManager
{
    private List<JobApplication> Applications = new List<JobApplication>();

    public void MenuAddApplication()
    {
        // get company name
        Console.WriteLine("Enter company");
        var CompanyName = Console.ReadLine();

        // get job title
        Console.WriteLine("Enter job Title");
        var jobtitle = Console.ReadLine();

        // get status
        var selector = -1;
        var appstatus = ApplicationStatus.Init;


        bool looper = false;
        while (!looper)
        {
            Console.WriteLine($"select status:");
            foreach (var entry in Enum.GetValues(typeof(ApplicationStatus)))
            {
                selector++;
                if(selector == 0)
                    continue;
                Console.WriteLine($"{selector}.{entry.ToString()}");
            }
            looper = Int32.TryParse(Console.ReadLine(), out selector);
        }
        if (selector == 1)
            appstatus = ApplicationStatus.Applied;
        if (selector == 2)
            appstatus = ApplicationStatus.Interviewing;
        if (selector == 3)
            appstatus = ApplicationStatus.Offer;
        if (selector == 4)
            appstatus = ApplicationStatus.Rejected;
        if (selector == 5)
            appstatus = ApplicationStatus.Accepted;


        // parse date
        DateTime applicationDate;
        while (true)
        {
            Console.WriteLine("Enter application date in the format of: 2025/01/25");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "yyyy/MM/dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out applicationDate))
            {
                break;
            }

            Console.WriteLine("❌ Ogiltigt datumformat. Försök igen.\n");
        }

        // parse salary
        int parsed;
        while (true)
        {
            Console.WriteLine("Enter your salary expecation as a number:");
            var salary = Console.ReadLine();
            var res = Int32.TryParse(salary, out parsed);
            if (res)
            {
                break;
            }
        }

        var newapplication = new JobApplication(CompanyName, jobtitle, appstatus,applicationDate,parsed);
        Applications.Add(newapplication);
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
        foreach(var entry in res)
        {
            Console.WriteLine(entry.GetSummary()); 
        }
    }

    public void RemoveJob(JobApplication jobApplication)
    {
        Applications.Remove(jobApplication);
    }
}
