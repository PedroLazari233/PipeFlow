namespace PipeFlow.Core;

public class FlowCalculator
{
    public static double Area(double diameter)
    {
        return (Math.PI * Math.Pow(diameter, 2)) / 4;
    }
}
