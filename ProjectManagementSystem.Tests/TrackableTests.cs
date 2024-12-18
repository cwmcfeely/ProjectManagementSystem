using Xunit;
using ProjectManagementSystem;

public class TrackableTests
{
    private class MockTrackable : ITrackable
    {
        private List<string> actionHistory = new List<string>();

        public void LogAction(string actionDescription)
        {
            if (string.IsNullOrWhiteSpace(actionDescription))
                return;
            actionHistory.Add($"{DateTime.Now}: {actionDescription}");
        }

        public List<string> GetActionHistory()
        {
            return new List<string>(actionHistory);
        }

        public void ClearActionHistory()
        {
            actionHistory.Clear();
        }
    }

    [Fact]
    public void LogAction_ValidDescription_AddsToHistory()
    {
        // Arrange
        var trackable = new MockTrackable();

        // Act
        trackable.LogAction("Test action");

        // Assert
        Assert.Single(trackable.GetActionHistory());
        Assert.Contains("Test action", trackable.GetActionHistory()[0]);
    }

    [Fact]
    public void LogAction_EmptyDescription_DoesNotAddToHistory()
    {
        // Arrange
        var trackable = new MockTrackable();

        // Act
        trackable.LogAction("");

        // Assert
        Assert.Empty(trackable.GetActionHistory());
    }

    [Fact]
    public void ClearActionHistory_RemovesAllActions()
    {
        // Arrange
        var trackable = new MockTrackable();
        trackable.LogAction("Test action 1");
        trackable.LogAction("Test action 2");

        // Act
        trackable.ClearActionHistory();

        // Assert
        Assert.Empty(trackable.GetActionHistory());
    }

    [Fact]
    public void GetActionHistory_ReturnsNewList()
    {
        // Arrange
        var trackable = new MockTrackable();
        trackable.LogAction("Test action");

        // Act
        var history1 = trackable.GetActionHistory();
        var history2 = trackable.GetActionHistory();

        // Assert
        Assert.NotSame(history1, history2);
    }
}
