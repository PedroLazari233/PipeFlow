namespace PipeFlow.Core;

public record Pipe
{
    public double Diameter { get; }
    public double Length { get; }
    public double Roughness { get; }

    public Pipe(double diameter, double length, double roughness)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(diameter);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        ArgumentOutOfRangeException.ThrowIfNegative(roughness);

        Diameter = diameter;
        Length = length;
        Roughness = roughness;
    }
}
