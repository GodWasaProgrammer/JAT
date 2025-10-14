namespace JAT;

public class JobManager
{
    List<JobApplication> Applications = new List<JobApplication>();

    public void AddApplication(JobApplication application)
    {
        Applications.Add(application);
    }

    public void UpdateStatus(JobApplication jobApplication, ApplicationStatus UpdatedStatus)
    {
        var res = Applications.Find(a => a == jobApplication);
        res?.UpdateStatus(UpdatedStatus);
    }

    public List<string> ShowAll()
    {
        return Applications.Select(a => a.GetSummary()).ToList();
    }

    public void RemoveJob(JobApplication jobApplication)
    {
        Applications.Remove(jobApplication);
    }
}
