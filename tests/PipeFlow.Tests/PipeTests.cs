using PipeFlow.Core;

namespace PipeFlow.Tests;

public class PipeTests
{
    [Theory]
    [InlineData(-0.1, 100, 4.5e-5)]
    [InlineData(0.1, -100, 4.5e-5)]
    [InlineData(0.1, 100, -4.5e-5)]
    [InlineData(0, 100, 4.5e-5)]
    [InlineData(0.1, 0, 4.5e-5)]
    public void Constructor_InvalidValue_Throws(double diameter, double length, double roughness)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Pipe(diameter, length, roughness));
    }

    [Fact]
    public void Constructor_PipeZeroRoughness_Correct()
    {
        var pipe = new Pipe(0.1, 100, 0);

        Assert.Equal(0, pipe.Roughness);
    }
}
