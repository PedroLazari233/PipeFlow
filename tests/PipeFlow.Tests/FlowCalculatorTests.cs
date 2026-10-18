using PipeFlow.Core;

namespace PipeFlow.Tests;

public class FlowCalculatorTests
{
    private static void AssertClose(double expected, double actual)
    {
        Assert.InRange(actual, expected * 0.999, expected * 1.001);
    }

    [Fact]
    public void Area_SteelPipe_MatchesReference()
    {
        AssertClose(0.007854, FlowCalculator.Area(0.1));
    }

    [Fact]
    public void Velocity_SteelPipe_MatchesReference()
    {
        AssertClose(1.2732, FlowCalculator.Velocity(0.01, 0.007854));
    }

    [Fact]
    public void Reynolds_SteelPipe_MatchesReference()
    {
        AssertClose(126841, FlowCalculator.Reynolds(998.2, 1.2732, 0.1, 1.002e-3));
    }
}
