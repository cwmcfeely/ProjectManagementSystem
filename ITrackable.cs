namespace ProjectManagementSystem
{
    public interface ITrackable
    {
        // Property for project status
        string ProjectStatus { get; set; }

        // Methods to be implemented by classes implementing this interface
        void UpdateStatus();
        //void AddTask(); Removed as only the Manager can add a task
        void GetTask();
        void GetTaskById();
        void UpdateProjectStatus();
        void CompleteTask();
    }
}