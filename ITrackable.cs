namespace ProjectManagementSystem
{

    public interface ITrackable
    {

        /// Logs an action with a description and timestamp.
        void LogAction(string actionDescription);

        /// Retrieves the history of logged actions.A list of strings representing the action history
        List<string> GetActionHistory();

        /// Clears all logged actions from the history.
        void ClearActionHistory();
    }
}
