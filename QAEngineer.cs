namespace ProjectManagementSystem
{
    public class QAEngineer : Employee // Inherit from Employee abstract class
    {
        private List<TestCase> TestCases; // List to store TestCases
        private List<Defect> DefectsReported; // List to store DefectsReported

        public QAEngineer(int employeeId, string firstName, string lastName)
            : base(employeeId, firstName, lastName, "QA Engineer") // Constructor that calls the base class constructor
        {
            TestCases = new List<TestCase>(); // New list is created to store list of TestCases
            DefectsReported = new List<Defect>(); // New list is created to store list of DefectsReported
        }


    // Filter tasks assigned to this QA Engineer
        public override void ViewTasks()
{
    Console.WriteLine($"QA Engineer {firstName} {lastName}'s Assigned Tasks:");

    // Filter tasks assigned to this QA Engineer
    var qaTasks = Tasks.Where(t => t != null).ToList();

    if (!qaTasks.Any())
    {
        Console.WriteLine("No tasks assigned to this QA Engineer.");
        return;
    }

    foreach (var task in qaTasks)
    {
        Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
    }
}

        // Method to create a new test case
        public TestCase CreateTestCase(int testCaseID, string description, string expectedResult, Task relatedTask)
        {
            if (testCaseID <= 0) // Validate testCase ID
            {
                Console.WriteLine("Error: TestCase ID must be greater than 0."); // Print the statement when the if condition is failed
                return null; // Return null to indicate failure
            }

            if (string.IsNullOrWhiteSpace(description)) // Validate description
            {
                Console.WriteLine("Error: Description cannot be empty."); // print the statement
                return null; // Return null to indicate failure
            }

            if (string.IsNullOrWhiteSpace(expectedResult)) // validate expected result
            {
                Console.WriteLine("Error: Expected result cannot be empty."); // print the statement
                return null; // Return null to indicate failure
            }
            var testCase = new TestCase(testCaseID, description, expectedResult, relatedTask); // create a new testCase object
            TestCases.Add(testCase); // add testcase to the list of testCases
            Console.WriteLine($"QA Engineer {firstName} assign task{relatedTask.ID} created TestCase {testCaseID}: {description}"); // print the statement
            return testCase; //return  created testCase
        }

        // Method to report a defect
        public Defect ReportDefect(int defectID, string description, TestCase relatedTestCase)
        {
            if (defectID <= 0) // Validate defect ID
            {
                Console.WriteLine("Error: Defect ID must be greater than 0."); // print the statement
                return null; // Return null to indicate failure
            }
            if (string.IsNullOrWhiteSpace(description)) // Validate description
            {
                Console.WriteLine("Error: Defect summary cannot be empty."); // print the statement
                return null; // Return null to indicate failure
            }
            if (relatedTestCase == null) // Validate relatedTestCase
            {
                Console.WriteLine("Error: Related test case cannot be null."); // print the statement
                return null; // Return null to indicate failure
            }
            var defect = new Defect(defectID, description, relatedTestCase); // create a new defect
            DefectsReported.Add(defect); // Add the defect to the list of DefectsReported
            Console.WriteLine(
                $"QA Engineer {firstName} reported Defect {defectID}: {description} for TestCase {relatedTestCase.TestCaseID}" // print the statement
            );
            return defect; //Return the newly created defect
        }

        // Method to view all Test Cases
        public void ViewTestCases()
        {
            Console.WriteLine($"Test Cases created by QA Engineer {firstName}:"); // print the statement
            foreach (var testCase in TestCases) // Iterate through each test case in the list of test cases
            {
                testCase.DisplayTestCaseDetails(); // call the method to display testcase details from the list
            }
        }

        // Method to view all defects
        public void ViewDefects()
        {
            foreach (var defect in DefectsReported) // Iterate through each test case in the list of DefectsReported
            {
                defect.DisplayDefectDetails();
            }
        }

        // Implementation of abstract methods
        public override void GenerateReport()
        {
            Console.WriteLine($"Generating report for QA Engineer {firstName}..."); // print the statement
            Console.WriteLine("Test Cases:"); // print the statemnet
            ViewTestCases();// call the method to view testcases from the list
            Console.WriteLine("Defects:"); // print the statement
            ViewDefects();// call the method to view defects from the list
        }

        // Implementation of abstract methods
        public override void ExecuteRole()
        {
            Console.WriteLine(
                $"{firstName} is executing QA Engineer responsibilities: creating test cases and reporting defects." // print the statement
            );
        }
    }
}