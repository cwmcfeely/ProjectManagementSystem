namespace ProjectManagementSystem
{
    public class QAEngineer : Employee // Inherit from Employee abstract class
    {
        private List<TestCase> TestCases; // List to store TestCases
        private List<Defect> DefectsReported; // List to store DefectsReported

        public QAEngineer(int id, string name)
            : base(id, name) // Constructor that calls the base class constructor
        {
            TestCases = new List<TestCase>();
            DefectsReported = new List<Defect>();
        }
    }

    public class TestCase
    {
        public string TestCaseID;
        public string TestCaseName;
        public string Description;
        public string ExpectedResult;
        public string ActualResult;

        // Constructor for initializing a test case
        public TestCase(
            string testCaseID,
            string testCaseName,
            string description,
            string expectedResult
        )
        {
            TestCaseID = testCaseID;
            TestCaseName = testCaseName;
            Description = description;
            ExpectedResult = expectedResult;
            ActualResult = string.Empty; // ActualResult is empty initially.
        }
    }

    public class Defect
    {
        public string DefectID;
        public string Description;
        public string Severity;
        public string Status;
        public string RelatedTestCaseID;

        // Constructor for initializing a defect
        public Defect(
            string id,
            string description,
            string severity,
            string status,
            string relatedTestCaseID
        )
        {
            DefectID = id;
            Description = description;
            Severity = severity;
            Status = status;
            RelatedTestCaseID = relatedTestCaseID;
        }
    }
}
