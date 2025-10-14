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

        var menuChoice = MenuSelect.Init;

        while (true)
        {
            var selector = -1;
            Console.WriteLine("Make your choice ");
            foreach (var entry in Enum.GetValues(typeof(MenuSelect)))
            {
                selector++;
                if (selector == 0)
                    continue;
                Console.WriteLine($"{selector}.{entry}");
            }
            bool resolve = false;
            while (!resolve)
            {
                var res = Console.ReadLine();
                resolve = Int32.TryParse(res, out selector);
                if (!resolve)
                {
                    Console.WriteLine("Couldnt parse your input. It should be a number.");
                }
            }

            if (selector == 1)
                menuChoice = MenuSelect.AddApplication;
            if (selector == 2)
                menuChoice = MenuSelect.ShowAllApplications;
            if (selector == 3)
                menuChoice = MenuSelect.FilterByStatus;
            if (selector == 4)
                menuChoice = MenuSelect.ShowStatistics;
            if (selector == 5)
                menuChoice = MenuSelect.UpdateStatus;
            if (selector == 6)
                menuChoice = MenuSelect.RemoveApplication;
            if (selector == 7)
                menuChoice = MenuSelect.ExitApplication;

            switch (menuChoice)
            {
                case MenuSelect.AddApplication:
                    jobman.MenuAddApplication();
                    break;
                case MenuSelect.ShowAllApplications:
                    jobman.ShowAll();
                    break;
                case MenuSelect.FilterByStatus:
                    jobman.FilterByStatus(ApplicationStatus.Applied);
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
                    break;
            }
        }
    }
}