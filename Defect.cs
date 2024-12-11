namespace ProjectManagementSystem;

public class Defect
{
    public int DefectID { get; private set; }
    public string Description { get; private set; }
    public string Status { get; private set; }
    public string Priority { get; private set; }
    public TestCase RelatedTestCase { get; set; }

    public Defect(int defectID, string description, TestCase relatedTestCase)
    {
        if (defectID <= 0)
        {
            Console.WriteLine("Error: Defect ID must be greater than 0.");
        }
        else if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Error: Defect description cannot be null or empty.");
        }
        else if (relatedTestCase == null)
        {
            Console.WriteLine("Error: Related test case cannot be null.");
        }
        else
        {
            DefectID = defectID;
            Description = description;
            Status = "Open";
            Priority = "Medium";
            RelatedTestCase = relatedTestCase;
        }
    }

    // Method to display defect details
    public void DisplayDefectDetails()
    {
        Console.WriteLine($"Defect {DefectID}: {Description}");
        Console.WriteLine(
            $"Linked to TestCase {RelatedTestCase.TestCaseID}: {RelatedTestCase.Description}"
        );
        Console.WriteLine($"Status: {Status}");
    }
}

