namespace PipeFlow.Core;

public static class FlowCalculator
{
    public static double Area(double diameter)
    {
        return (Math.PI * Math.Pow(diameter, 2)) / 4;
    }

    public static double Velocity(double flowRate, double area)
    {
        return flowRate / area;
    }

    public static double Reynolds(double density, double velocity, double diameter, double viscosity)
    {
        return density * velocity * diameter / viscosity;
    }
}
