using Enums;

namespace JAT;

internal class Program
{
    static void Main()
    {
        var datetime1 = new DateTime(2025, 11, 5);
        var datetime2 = new DateTime(2025, 4, 5);
        var datetime3 = new DateTime(2025, 7, 5);
        var deg = 43000;
        var test1 = new JobApplication("DonkeyTech", "CodeMonkey", ApplicationStatus.Applied, datetime1, deg);
        var test2 = new JobApplication("CodeMonkeys INC", "Vibe Code CleanUp Specialist", ApplicationStatus.Applied, datetime2, deg);
        var test3 = new JobApplication("Foobar INC", "Dev", ApplicationStatus.Applied, datetime3, deg);

        var jobman = new JobManager();
        jobman.AddApplication(test1);
        jobman.AddApplication(test2);
        jobman.AddApplication(test3);

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
                    jobman.MenuAddApplication();
                    break;
                case MenuSelect.ShowAllApplications:
                    jobman.ShowAll();
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
                    break;
                case MenuSelect.SortByDate:
                    break;
                case MenuSelect.ShowStatistics:
                    break;
                case MenuSelect.UpdateStatus:
                    break;
                case MenuSelect.RemoveApplication:
                    break;
                case MenuSelect.ExitApplication:
                    return;
            }
        }
    }
}