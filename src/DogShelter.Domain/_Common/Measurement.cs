namespace DogShelter.Domain.Common;

public class Measurement
{
    public int Metric   { get; set; }
    public int Imperial { get; set; }

    public Measurement(int metric, int imperial)
    {
        Metric   = metric;
        Imperial = imperial;
    }
}