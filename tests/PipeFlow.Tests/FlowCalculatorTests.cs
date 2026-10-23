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

    [Fact]
    public void LaminarFriction_LaminarCase_MatchesReference()
    {
        AssertClose(0.1009, FlowCalculator.LaminarFriction(634.2));
    }

    [Fact]
    public void SwameeJain_TurbulentCase_MatchesReference()
    {
        AssertClose(0.01960, FlowCalculator.SwameeJain(4.5e-5, 0.1, 126841));
    }

    [Fact]
    public void Colebrook_TurbulentCase_MatchesReference()
    {
        AssertClose(0.01951, FlowCalculator.Colebrook(4.5e-5, 0.1, 126841));
    }

    [Fact]
    public void HeadLoss_TurbulentCase_MatchesReference()
    {
        AssertClose(1.612, FlowCalculator.HeadLoss(0.01951, 100, 0.1, 1.2732));
    }

    [Fact]
    public void PressureDrop_TurbulentCase_MatchesReference()
    {
        AssertClose(15787, FlowCalculator.PressureDrop(998.2, 1.612));
    }

    [Theory]
    [InlineData(634.2, 0.1009)]
    [InlineData(126841, 0.01951)]
    public void Friction_TurbulentCase_MatchesReference(double reynolds, double expectedFriction)
    {
        AssertClose(expectedFriction, FlowCalculator.Friction(4.5e-5, 0.1, reynolds));
    }
}
