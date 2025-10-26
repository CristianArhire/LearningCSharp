using System;


public class TaskItem
{

    // A unique identifier for the task
    public int Id { get; set; }

    //A short description of the task
    public string Description { get; set; }

    //The status of the task (todo, in-progress, done)
    public string Status { get; set; }

    //The date and time when the task was created
    public DateTime CreatedAt { get; set; }

    //The date and time when the task was last updated
    public DateTime UpdatedAt { get; set; }

    public TaskItem() { }

    public TaskItem(int id, string description)
    {

        Id = id;
        Description = description;
        Status = "all";
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}


