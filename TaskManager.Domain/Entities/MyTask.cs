namespace TaskManager.Domain.Entities;

public class Task
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Task(string title, DateTime date, string description)
    {
        Title = title;
        Date = date;
        Description = description;
    }
}