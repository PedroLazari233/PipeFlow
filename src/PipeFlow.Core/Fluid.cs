namespace PipeFlow.Core;

public record Fluid
{
    public double Density { get; }
    public double Viscosity { get; }

    public Fluid(double density, double viscosity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(density);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(viscosity);

        Density = density;
        Viscosity = viscosity;
    }
}
