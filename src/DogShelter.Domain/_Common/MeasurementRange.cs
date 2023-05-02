namespace DogShelter.Domain.Common;

public class MeasurementRange
{
    public string Metric   { get; set; } = null!;
    public string Imperial { get; set; } = null!;

    public MeasurementRange(string metric, string imperial)
    {
        Metric   = metric;
        Imperial = imperial;
    }
}
