using Enums;
using System.Globalization;

namespace JAT;

internal class Program
{


    static void Main()
    {
        var jobman = new JobManager();
        // test data 
        var datetime1 = new DateTime(2025, 11, 5);
        var datetime2 = new DateTime(2025, 4, 5);
        var datetime3 = new DateTime(2025, 7, 5);
        var deg = 43000;
        var test1 = new JobApplication("DonkeyTech", "CodeMonkey", ApplicationStatus.Applied, datetime1, deg);
        var test2 = new JobApplication("CodeMonkeys INC", "Vibe Code CleanUp Specialist", ApplicationStatus.Applied, datetime2, deg);
        var test3 = new JobApplication("Foobar INC", "Dev", ApplicationStatus.Applied, datetime3, deg);

        jobman.AddApplication(test1);
        jobman.AddApplication(test2);
        jobman.AddApplication(test3);
        //// end testdata 


        var menuChoice = MenuSelect.AddApplication;
        var menuChoices = Enum.GetValues<MenuSelect>();
        while (true)
        {
            int selector = 0;
            Console.WriteLine("=====================================");
            Console.WriteLine("Main Menu Job Application Tracker");
            Console.WriteLine("=====================================");
            Console.WriteLine("Make your choice ");
            Console.WriteLine("=====================================");
            foreach (var entry in Enum.GetValues(typeof(MenuSelect)))
            {
                selector++;
                Console.WriteLine($"{selector}.{entry}");
            }
            Console.WriteLine("=====================================");

            bool resolve = false;
            while (!resolve)
            {
                var res = Console.ReadLine();
                resolve = Int32.TryParse(res, out selector);
                if (selector > menuChoices.Length || selector < 1)
                {
                    resolve = false;
                }
                if (!resolve)
                {
                    Console.WriteLine("Couldnt parse your input. It should be a number and not negative nor zero.");

                }
                else
                {
                    menuChoice = menuChoices[selector - 1];
                }
            }
            switch (menuChoice)
            {
                case MenuSelect.AddApplication:
                    var choices = Enum.GetValues<ApplicationStatus>();
                    // get company name
                    Console.WriteLine("Enter company");
                    var CompanyName = Console.ReadLine();

                    // get job title
                    Console.WriteLine("Enter job Title");
                    var jobtitle = Console.ReadLine();

                    // get status
                    var appstatus = ApplicationStatus.Applied;


                    bool looper = false;
                    var StatusSelect = 0;
                    while (!looper)
                    {
                        StatusSelect = 0;
                        Console.WriteLine($"select status:");
                        foreach (var entry in choices)
                        {
                            StatusSelect++;
                            Console.WriteLine($"{StatusSelect}.{entry.ToString()}");
                        }
                        looper = Int32.TryParse(Console.ReadLine(), out StatusSelect);
                        if (StatusSelect > choices.Length || StatusSelect < 1)
                        {
                            looper = false;
                            Console.WriteLine("Erroneous input, try again");
                        }
                        else
                        {
                            {
                                appstatus = choices[StatusSelect - 1];
                            }
                        }
                    }
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

                        Console.WriteLine("wrong format. Try again.\n");
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

                    var newapplication = new JobApplication(CompanyName, jobtitle, appstatus, applicationDate, parsed);
                    jobman.AddApplication(newapplication);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.ShowAllApplications:
                    jobman.ShowAll();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.FilterByStatus:
                    var applicationStatuses = Enum.GetValues<ApplicationStatus>();
                    var status = applicationStatuses[0];
                    while (true)
                    {
                        var statusSelector = 0;
                        Console.WriteLine("==== Select status ====");
                        foreach (var entry in applicationStatuses)
                        {
                            statusSelector++;
                            Console.WriteLine($"{statusSelector}.{entry}");
                        }
                        Console.WriteLine("=========================");
                        var res = Console.ReadLine();
                        var resolved = Int32.TryParse(res, out statusSelector);
                        if (statusSelector > applicationStatuses.Length || statusSelector < 1)
                        {
                            resolved = false;
                            Console.WriteLine("Invalid input, try again");
                        }
                        if (resolved)
                        {
                            status = applicationStatuses[statusSelector - 1];
                            break;
                        }
                    }
                    jobman.FilterByStatus(status);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.SortByDate:
                    jobman.SortByDate();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.ShowStatistics:
                    jobman.ShowStatistics();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.ShowOlderThen14DaysAndNoResponse:
                    jobman.ShowOlderThen14DaysAndNoResponse();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case MenuSelect.UpdateStatus:
                    var SelectIndexToUpdate = 0;
                    var allapplications = jobman.ReturnAllApplications();
                    bool resolvedInput = false;
                    while (!resolvedInput)
                    {
                        SelectIndexToUpdate = 0;
                        Console.WriteLine("====== Update Status ====");
                        Console.WriteLine("==== select Application to update ====");

                        foreach (var a in allapplications)
                        {
                            var indexer = allapplications.IndexOf(a) + 1;
                            Console.WriteLine($"{indexer}.{a.GetSummary()}");
                        }
                        var input = Console.ReadLine();
                        resolvedInput = Int32.TryParse(input, out SelectIndexToUpdate);
                        if (SelectIndexToUpdate > allapplications.Count || SelectIndexToUpdate < 1)
                        {
                            resolvedInput = false;
                            Console.WriteLine("Invalid input, try again");
                        }
                    }

                    bool resolvedStatusInput = false;
                    while (!resolvedStatusInput)
                    {
                        Console.WriteLine("=== Select Status to Update with ====");
                        var statusSelector = 0;
                        var index = 0;
                        var applicationStatuses2 = Enum.GetValues<ApplicationStatus>();
                        foreach (var entry in applicationStatuses2)
                        {
                            index++;
                            Console.WriteLine($"{index}.{entry}");
                        }
                        var statusinput = Console.ReadLine();
                        resolvedStatusInput = Int32.TryParse(statusinput, out statusSelector);
                        if (statusSelector > applicationStatuses2.Length || statusSelector < 1)
                        {
                            resolvedStatusInput = false;
                            Console.WriteLine("Invalid input, try again");
                        }
                        else
                        {
                            var statusToUpdate = applicationStatuses2[statusSelector - 1];
                            var appToUpdate = allapplications[SelectIndexToUpdate - 1];
                            jobman.UpdateStatus(appToUpdate, statusToUpdate);
                            Console.WriteLine("Status updated. Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    }

                    break;
                case MenuSelect.RemoveApplication:
                    Console.WriteLine("========= Select Application to remove =======");
                    var allapps = jobman.ReturnAllApplications();
                    var selectIndexToRemove = 0;
                    var resolvedRemoveInput = false;
                    while (!resolvedRemoveInput)
                    {
                        selectIndexToRemove = 0;
                        foreach (var a in allapps)
                        {
                            var indexer = allapps.IndexOf(a) + 1;
                            Console.WriteLine($"{indexer}.{a.GetSummary()}");
                        }
                        var input = Console.ReadLine();
                        resolvedRemoveInput = Int32.TryParse(input, out selectIndexToRemove);
                        if (selectIndexToRemove > allapps.Count || selectIndexToRemove < 1)
                        {
                            resolvedRemoveInput = false;
                            Console.WriteLine("Invalid input, try again");
                        }
                        else
                        {
                            var appToRemove = allapps[selectIndexToRemove - 1];
                            jobman.RemoveJob(appToRemove);
                            Console.WriteLine("Application removed. Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    }
                    break;
                case MenuSelect.ExitApplication:
                    return;
            }
        }
    }
}