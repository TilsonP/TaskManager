namespace TaskManager.Domain.Entities;

public class MyTask
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public MyTask(string title, DateTime date, string description)
    {
        Title = title;
        Date = date;
        Description = description;
    }
}