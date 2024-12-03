namespace ProjectManagementSystem
{
    public interface ITrackable
    {
        // Property for project status
        string ProjectStatus { get; set; }

        // Methods to be implemented by classes implementing this interface
        void UpdateStatus();
        //void AddTask(); Removed as only the Manager can add a task

                    // Public method to view all tasks (accessible by all subclasses)
        void ViewTasks()
    {
     //   Console.WriteLine($"Tasks for {firstName}:");
       // foreach (var task in Tasks)
        //{
        //    Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
        //}
    }
        Task GetTaskById(int taskId);
        void UpdateProjectStatus();
        void CompleteTask();
    }
}