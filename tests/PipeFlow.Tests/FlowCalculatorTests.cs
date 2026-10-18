using PipeFlow.Core;

namespace PipeFlow.Tests;

public class FlowCalculatorTests
{
    private static void AssertClose(double expected, double actual)
    {
        Assert.InRange(actual, expected * 0.999, expected * 1.001);
    }

    [Fact]
    public void Area_Value_ShouldPass()
    {
        AssertClose(FlowCalculator.Area(0.1), 0.007854);
    }
}
