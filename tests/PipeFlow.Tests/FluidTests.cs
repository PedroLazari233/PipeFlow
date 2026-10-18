using PipeFlow.Core;

namespace PipeFlow.Tests;

public class FluidTests
{
    [Theory]
    [InlineData(-1, 1e3)]
    [InlineData(0, 1e3)]
    [InlineData(0.5, -1e3)]
    [InlineData(0.5, 0)]
    public void Constructor_NegativeDensity_Throw(double density, double viscosity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Fluid(density, viscosity);
        });
    }
}
