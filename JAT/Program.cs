namespace JAT;

internal class Program
{
    static void Main()
    {
        var datetime1 = new DateTime(2025, 11, 5);
        var datetime2 = new DateTime(2025, 4, 5);
        var datetime3 = new DateTime(2025, 7, 5);
        var deg = 43000;
        var test1 = new JobApplication("DonkeyTech","CodeMonkey", ApplicationStatus.Applied,datetime1,deg);
        var test2 = new JobApplication("CodeMonkeys INC", "Vibe Code CleanUp Specialist", ApplicationStatus.Applied, datetime2 ,deg);
        var test3 = new JobApplication("Foobar INC","Dev", ApplicationStatus.Applied, datetime3 ,deg);

        var jobman = new JobManager();
        jobman.AddApplication(test1);
        jobman.AddApplication(test2);
        jobman.AddApplication(test3);
    }
}
