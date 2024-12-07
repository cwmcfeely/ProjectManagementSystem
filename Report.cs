// Abstract report class
public abstract class Report
{
    public DateTime GeneratedDate { get; private set; }

    protected Report()
    {
        GeneratedDate = DateTime.Now;
    }

    // Abstract method to generate the report
    public abstract void Generate();
}